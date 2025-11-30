using hangfire_template.Data;
using hangfire_template.Models;
using Microsoft.EntityFrameworkCore;

namespace hangfire_template.Services;

public class TrelloSyncJob
{
    private readonly TrelloApiService _trelloApi;
    private readonly AppDbContext _context;
    private readonly ILogger<TrelloSyncJob> _logger;

    public TrelloSyncJob(TrelloApiService trelloApi, AppDbContext context, ILogger<TrelloSyncJob> logger)
    {
        _trelloApi = trelloApi;
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// Sync work packages that need Trello updates (NeedsTrelloSync = true)
    /// </summary>
    public async Task SyncToTrelloAsync()
    {
        try
        {
            _logger.LogInformation("Starting Trello sync job...");

            // Get all work packages that need Trello sync
            var workPackagesToSync = await _context.TWorkPackages
                .Where(w => w.NeedsTrelloSync == true)
                .ToListAsync();

            if (workPackagesToSync.Count == 0)
            {
                _logger.LogInformation("No work packages need Trello sync");
                return;
            }

            _logger.LogInformation("Found {Count} work packages to sync to Trello", workPackagesToSync.Count);

            var successCount = 0;
            var errorCount = 0;

            foreach (var workPackage in workPackagesToSync)
            {
                try
                {
                    if (string.IsNullOrEmpty(workPackage.TrelloCardId))
                    {
                        // Create new card in Trello
                        var newCard = await _trelloApi.CreateCardAsync(
                            name: workPackage.Name ?? "Untitled",
                            description: workPackage.Description,
                            dueDate: workPackage.DueDate
                        );

                        if (newCard != null && !string.IsNullOrEmpty(newCard.Id))
                        {
                            workPackage.TrelloCardId = newCard.Id;
                            workPackage.NeedsTrelloSync = false;
                            workPackage.LastSyncedAt = DateTime.Now;

                            successCount++;
                            _logger.LogInformation("Created new Trello card: {CardId} for work package: {WorkPackageId}",
                                newCard.Id, workPackage.Id);
                        }
                    }
                    else
                    {
                        // Update existing card
                        var updatedCard = await _trelloApi.UpdateCardAsync(
                            cardId: workPackage.TrelloCardId,
                            name: workPackage.Name,
                            description: workPackage.Description,
                            dueDate: workPackage.DueDate
                        );

                        if (updatedCard != null)
                        {
                            workPackage.NeedsTrelloSync = false;
                            workPackage.LastSyncedAt = DateTime.Now;

                            successCount++;
                            _logger.LogInformation("Updated Trello card: {CardId} for work package: {WorkPackageId}",
                                workPackage.TrelloCardId, workPackage.Id);
                        }
                    }

                    // Save changes for each work package
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    errorCount++;
                    _logger.LogError(ex, "Error syncing work package {WorkPackageId} to Trello", workPackage.Id);
                    // Continue with next work package
                }
            }

            _logger.LogInformation(
                "Trello sync job completed. Success: {Success}, Errors: {Errors}",
                successCount, errorCount);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in Trello sync job");
            throw;
        }
    }
}
