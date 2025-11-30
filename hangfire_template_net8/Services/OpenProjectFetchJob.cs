using hangfire_template.Models;
using hangfire_template.Data;
using Newtonsoft.Json.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace hangfire_template.Services
{
    public class OpenProjectFetchJob
    {
        private readonly OpenProjectApiService _apiService;
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger<OpenProjectFetchJob> _logger;

        public OpenProjectFetchJob(
            OpenProjectApiService apiService,
            AppDbContext context,
            IConfiguration configuration,
            ILogger<OpenProjectFetchJob> logger)
        {
            _apiService = apiService;
            _context = context;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task FetchAllWorkPackagesAsync()
        {
            try
            {
                var projectId = _configuration["OpenProject:DefaultProjectId"] ?? "demo-project";
                _logger.LogInformation("Starting OpenProject fetch job for project: {ProjectId}", projectId);

                var openProjectWorkPackages = await _apiService.GetAllWorkPackagesAsync(projectId);

                foreach (var wpData in openProjectWorkPackages)
                {
                    try
                    {
                        string? opWorkPackageId = wpData["id"]?.ToString();
                        if (string.IsNullOrEmpty(opWorkPackageId)) continue;

                        var projectData = wpData["_embedded"]?["project"];
                        var statusData = wpData["_embedded"]?["status"];
                        var assigneeData = wpData["_embedded"]?["assignee"];

                        var project = await GetOrCreateProject(projectData);
                        var status = await GetOrCreateStatus(statusData);
                        var assignee = await GetOrCreateUser(assigneeData);

                        var workPackage = await _context.TWorkPackages
                            .FirstOrDefaultAsync(w => w.OpenProjectWorkPackageId == opWorkPackageId);

                        if (workPackage == null)
                        {
                            workPackage = new TWorkPackage
                            {
                                OpenProjectWorkPackageId = opWorkPackageId,
                                Name = wpData["subject"]?.ToString() ?? "Untitled",
                                Description = wpData["description"]?["raw"]?.ToString(),
                                ProjectId = project?.Id,
                                StatusId = status?.Id,
                                AssigneeId = assignee?.Id,
                                CreatedAt = DateTime.Now,
                                LastSyncedAt = DateTime.Now,
                                NeedsOpSync = false,
                                NeedsTrelloSync = true
                            };
                            _context.TWorkPackages.Add(workPackage);
                        }
                        else
                        {
                            workPackage.Name = wpData["subject"]?.ToString() ?? workPackage.Name;
                            workPackage.Description = wpData["description"]?["raw"]?.ToString();
                            workPackage.ProjectId = project?.Id;
                            workPackage.StatusId = status?.Id;
                            workPackage.AssigneeId = assignee?.Id;
                            workPackage.LastSyncedAt = DateTime.Now;
                            workPackage.NeedsOpSync = false;
                            workPackage.NeedsTrelloSync = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error processing work package");
                    }
                }

                await _context.SaveChangesAsync();
                _logger.LogInformation("OpenProject fetch job completed successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in OpenProject fetch job");
                throw;
            }
        }

        private async Task<TProject?> GetOrCreateProject(JToken? projectData)
        {
            if (projectData == null) return null;
            string? opIdentifier = projectData["identifier"]?.ToString();
            if (string.IsNullOrEmpty(opIdentifier)) return null;

            var project = await _context.TProjects.FirstOrDefaultAsync(p => p.OpenProjectIdentifier == opIdentifier);
            if (project == null)
            {
                project = new TProject
                {
                    OpenProjectIdentifier = opIdentifier,
                    Name = projectData["name"]?.ToString()
                };
                _context.TProjects.Add(project);
                await _context.SaveChangesAsync();
            }
            return project;
        }

        private async Task<TStatus?> GetOrCreateStatus(JToken? statusData)
        {
            if (statusData == null) return null;
            string? opStatusId = statusData["id"]?.ToString();
            if (string.IsNullOrEmpty(opStatusId)) return null;

            var status = await _context.TStatuses.FirstOrDefaultAsync(s => s.OpenProjectStatusId == opStatusId);
            if (status == null)
            {
                status = new TStatus
                {
                    OpenProjectStatusId = opStatusId,
                    Name = statusData["name"]?.ToString()
                };
                _context.TStatuses.Add(status);
                await _context.SaveChangesAsync();
            }
            return status;
        }

        private async Task<TUser?> GetOrCreateUser(JToken? userData)
        {
            if (userData == null) return null;
            string? opUserId = userData["id"]?.ToString();
            if (string.IsNullOrEmpty(opUserId)) return null;

            var user = await _context.TUsers.FirstOrDefaultAsync(u => u.OpenProjectUserId == opUserId);
            if (user == null)
            {
                user = new TUser
                {
                    OpenProjectUserId = opUserId,
                    FullName = userData["name"]?.ToString()
                };
                _context.TUsers.Add(user);
                await _context.SaveChangesAsync();
            }
            return user;
        }
    }
}
