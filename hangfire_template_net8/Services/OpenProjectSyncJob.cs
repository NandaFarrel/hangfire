using hangfire_template.Data;
using hangfire_template.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace hangfire_template.Services
{
    public class OpenProjectSyncJob
    {
        private readonly OpenProjectApiService _apiService;
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger<OpenProjectSyncJob> _logger;

        public OpenProjectSyncJob(
            OpenProjectApiService apiService,
            AppDbContext context,
            IConfiguration configuration,
            ILogger<OpenProjectSyncJob> logger)
        {
            _apiService = apiService;
            _context = context;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task SyncToOpenProjectAsync()
        {
            try
            {
                _logger.LogInformation("Starting OpenProject sync job...");

                var workPackagesToSync = await _context.TWorkPackages
                    .Where(w => w.NeedsOpSync == true)
                    .ToListAsync();

                if (workPackagesToSync.Count == 0)
                {
                    _logger.LogInformation("No work packages need OpenProject sync");
                    return;
                }

                _logger.LogInformation("Found {Count} work packages to sync to OpenProject", workPackagesToSync.Count);

                var projectId = _configuration["OpenProject:DefaultProjectId"] ?? "demo-project";
                var successCount = 0;
                var errorCount = 0;

                foreach (var workPackage in workPackagesToSync)
                {
                    try
                    {
                        if (string.IsNullOrEmpty(workPackage.OpenProjectWorkPackageId))
                        {
                            // Create new work package in OpenProject
                            var result = await _apiService.CreateWorkPackageAsync(projectId, workPackage);
                            if (result != null)
                            {
                                workPackage.OpenProjectWorkPackageId = result["id"]?.ToString();
                                workPackage.NeedsOpSync = false;
                                workPackage.LastSyncedAt = DateTime.Now;
                                successCount++;
                                _logger.LogInformation("Created work package in OpenProject: {Id}", workPackage.Id);
                            }
                        }
                        else
                        {
                            // Update existing work package
                            await _apiService.UpdateWorkPackageAsync(workPackage.OpenProjectWorkPackageId, workPackage);
                            workPackage.NeedsOpSync = false;
                            workPackage.LastSyncedAt = DateTime.Now;
                            successCount++;
                            _logger.LogInformation("Updated work package in OpenProject: {Id}", workPackage.Id);
                        }

                        await _context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        errorCount++;
                        _logger.LogError(ex, "Error syncing work package {Id} to OpenProject", workPackage.Id);
                    }
                }

                _logger.LogInformation("OpenProject sync job completed. Success: {Success}, Errors: {Errors}",
                    successCount, errorCount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in OpenProject sync job");
                throw;
            }
        }
    }
}
