using hangfire_template.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace hangfire_template.Services
{
    public class OpenProjectApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _apiBaseUrl;
        private readonly ILogger<OpenProjectApiService> _logger;

        public OpenProjectApiService(HttpClient httpClient, IConfiguration configuration, ILogger<OpenProjectApiService> logger)
        {
            _apiBaseUrl = configuration["OpenProject:Url"] ?? throw new Exception("OpenProject URL not configured");
            _apiKey = configuration["OpenProject:ApiKey"] ?? throw new Exception("OpenProject API Key not configured");
            _logger = logger;

            _httpClient = httpClient;
            // Ensure BaseAddress ends with / to avoid double slashes
            var baseUrl = _apiBaseUrl.EndsWith("/") ? _apiBaseUrl : _apiBaseUrl + "/";
            _httpClient.BaseAddress = new Uri(baseUrl);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.ASCII.GetBytes($"apikey:{_apiKey}")));
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            _logger.LogInformation("OpenProjectApiService initialized with BaseAddress: {BaseAddress}", _httpClient.BaseAddress);
        }

        public async Task<List<JObject>> GetAllWorkPackagesAsync(string projectId)
        {
            var allWorkPackages = new List<JObject>();
            int pageSize = 100;
            int offset = 1;
            bool hasMore = true;

            while (hasMore)
            {
                try
                {
                    var url = $"api/v3/projects/{projectId}/work_packages?pageSize={pageSize}&offset={offset}";
                    _logger.LogInformation("Fetching work packages from: {Url}", url);
                    
                    var response = await _httpClient.GetAsync(url);
                    
                    if (!response.IsSuccessStatusCode)
                    {
                        var errorContent = await response.Content.ReadAsStringAsync();
                        _logger.LogError("OpenProject API error ({StatusCode}): {ErrorContent}", response.StatusCode, errorContent);
                        throw new HttpRequestException($"OpenProject API error ({response.StatusCode}): {errorContent}");
                    }

                    var content = await response.Content.ReadAsStringAsync();
                    var result = JObject.Parse(content);
                    var elements = result["_embedded"]?["elements"] as JArray;

                    if (elements != null && elements.Count > 0)
                    {
                        foreach (var item in elements)
                        {
                            allWorkPackages.Add((JObject)item);
                        }
                        offset += pageSize;
                    }
                    else
                    {
                        hasMore = false;
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error fetching work packages from OpenProject");
                    throw;
                }
            }

            return allWorkPackages;
        }

        public async Task<JObject?> CreateWorkPackageAsync(string projectId, TWorkPackage workPackage)
        {
            var url = $"api/v3/projects/{projectId}/work_packages";

            var payload = new
            {
                subject = workPackage.Name,
                description = new { raw = workPackage.Description ?? "" },
                _links = new
                {
                    type = new { href = "/api/v3/types/1" }
                }
            };

            var jsonContent = JsonConvert.SerializeObject(payload);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, httpContent);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JObject.Parse(content);
        }

        public async Task<JObject?> UpdateWorkPackageAsync(string workPackageId, TWorkPackage workPackage)
        {
            var url = $"api/v3/work_packages/{workPackageId}";

            var payload = new
            {
                subject = workPackage.Name,
                description = new { raw = workPackage.Description ?? "" },
                dueDate = workPackage.DueDate?.ToString("yyyy-MM-dd")
            };

            var jsonContent = JsonConvert.SerializeObject(payload);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PatchAsync(url, httpContent);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JObject.Parse(content);
        }
    }
}
