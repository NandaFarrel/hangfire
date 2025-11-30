using hangfire_template.Data;
using hangfire_template.Models;
using Microsoft.EntityFrameworkCore;

namespace hangfire_template.Services;

public class TrelloFetchJob
{
    private readonly TrelloApiService _trelloApi;
    private readonly AppDbContext _context;
    private readonly ILogger<TrelloFetchJob> _logger;

    public TrelloFetchJob(TrelloApiService trelloApi, AppDbContext context, ILogger<TrelloFetchJob> logger)
    {
        _trelloApi = trelloApi;
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// Fetch all cards from Trello and sync to database
    /// </summary>
    public async Task FetchAllCardsAsync()
    {
        try
        {
            _logger.LogInformation("Starting Trello fetch job...");

            var cards = await _trelloApi.GetAllCardsAsync();
            var processedCount = 0;
            var createdCount = 0;
            var updatedCount = 0;

            foreach (var card in cards)
            {
                if (string.IsNullOrEmpty(card.Id))
                    continue;

                // Find existing work package by Trello Card ID
                var workPackage = await _context.TWorkPackages
                    .FirstOrDefaultAsync(w => w.TrelloCardId == card.Id);

                if (workPackage == null)
                {
                    // Create new work package
                    workPackage = new TWorkPackage
                    {
                        TrelloCardId = card.Id,
                        Name = card.Name ?? "Untitled",
                        Description = card.Desc,
                        DueDate = card.Due,
                        CreatedAt = DateTime.Now,
                        LastSyncedAt = DateTime.Now,
                        NeedsTrelloSync = false, // Just synced from Trello
                        NeedsOpSync = true  // Need to sync to OpenProject
                    };

                    _context.TWorkPackages.Add(workPackage);
                    createdCount++;
                    _logger.LogInformation("Created new work package from Trello card: {CardId} - {Name}", card.Id, card.Name);
                }
                else
                {
                    // Update existing work package only if data changed
                    var hasChanges = false;

                    if (workPackage.Name != card.Name)
                    {
                        workPackage.Name = card.Name ?? workPackage.Name;
                        hasChanges = true;
                    }

                    if (workPackage.Description != card.Desc)
                    {
                        workPackage.Description = card.Desc;
                        hasChanges = true;
                    }

                    if (workPackage.DueDate != card.Due)
                    {
                        workPackage.DueDate = card.Due;
                        hasChanges = true;
                    }

                    if (hasChanges)
                    {
                        workPackage.LastSyncedAt = DateTime.Now;
                        workPackage.NeedsTrelloSync = false;
                        workPackage.NeedsOpSync = true; // Sync changes to OpenProject

                        updatedCount++;
                        _logger.LogInformation("Updated work package from Trello card: {CardId} - {Name}", card.Id, card.Name);
                    }
                }

                processedCount++;
            }

            await _context.SaveChangesAsync();

            _logger.LogInformation(
                "Trello fetch job completed. Processed: {Processed}, Created: {Created}, Updated: {Updated}",
                processedCount, createdCount, updatedCount);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in Trello fetch job");
            throw;
        }
    }
}
