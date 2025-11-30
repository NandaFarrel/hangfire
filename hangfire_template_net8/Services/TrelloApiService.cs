using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace hangfire_template.Services;

public class TrelloApiService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly string _token;
    private readonly string _boardId;
    private readonly ILogger<TrelloApiService> _logger;
    private const string BaseUrl = "https://api.trello.com/1";

    public TrelloApiService(HttpClient httpClient, IConfiguration configuration, ILogger<TrelloApiService> logger)
    {
        _httpClient = httpClient;
        _apiKey = configuration["Trello:ApiKey"] ?? throw new Exception("Trello API Key not configured");
        _token = configuration["Trello:Token"] ?? throw new Exception("Trello Token not configured");
        _boardId = configuration["Trello:BoardId"] ?? throw new Exception("Trello Board ID not configured");
        _logger = logger;

        // BaseAddress is configured in Program.cs via DI
    }

    /// <summary>
    /// Get all cards from the configured board
    /// </summary>
    public async Task<List<TrelloCard>> GetAllCardsAsync()
    {
        try
        {
            var url = $"boards/{_boardId}/cards?key={_apiKey}&token={_token}";
            var fullUrl = _httpClient.BaseAddress != null ? new Uri(_httpClient.BaseAddress, url).ToString() : url;
            _logger.LogInformation("Requesting Trello API: {Url}", fullUrl);

            var response = await _httpClient.GetAsync(url);

            var content = await response.Content.ReadAsStringAsync();

            // Log response for debugging
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Trello API returned {StatusCode}: {Content}",
                    response.StatusCode, content.Length > 500 ? content.Substring(0, 500) : content);
            }

            response.EnsureSuccessStatusCode();

            // Check if response is JSON (not HTML error page)
            if (content.TrimStart().StartsWith("<"))
            {
                _logger.LogError("Trello API returned HTML instead of JSON. First 200 chars: {Content}",
                    content.Length > 200 ? content.Substring(0, 200) : content);
                throw new Exception("Trello API returned HTML instead of JSON. Possible rate limit or API error.");
            }

            var cards = JsonSerializer.Deserialize<List<TrelloCard>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            _logger.LogInformation("Successfully fetched {Count} cards from Trello board {BoardId}", cards?.Count ?? 0, _boardId);
            return cards ?? new List<TrelloCard>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching cards from Trello board {BoardId}", _boardId);
            throw;
        }
    }

    /// <summary>
    /// Create a new card on Trello
    /// </summary>
    public async Task<TrelloCard?> CreateCardAsync(string name, string? description = null, string? listId = null, DateTime? dueDate = null)
    {
        try
        {
            // If no listId provided, get the first list
            if (string.IsNullOrEmpty(listId))
            {
                listId = await GetFirstListIdAsync();
            }

            var url = $"/cards?key={_apiKey}&token={_token}";
            url += $"&idList={listId}&name={Uri.EscapeDataString(name)}";

            if (!string.IsNullOrEmpty(description))
                url += $"&desc={Uri.EscapeDataString(description)}";

            if (dueDate.HasValue)
                url += $"&due={dueDate.Value:yyyy-MM-ddTHH:mm:ss.fffZ}";

            var response = await _httpClient.PostAsync(url, null);

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Trello API returned {StatusCode} when creating card '{Name}': {Content}",
                    response.StatusCode, name, content.Length > 500 ? content.Substring(0, 500) : content);
            }

            response.EnsureSuccessStatusCode();

            // Check if response is JSON
            if (content.TrimStart().StartsWith("<"))
            {
                _logger.LogError("Trello API returned HTML instead of JSON when creating '{Name}'. First 200 chars: {Content}",
                    name, content.Length > 200 ? content.Substring(0, 200) : content);
                throw new Exception("Trello API returned HTML instead of JSON. Possible rate limit or API error.");
            }

            var card = JsonSerializer.Deserialize<TrelloCard>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            _logger.LogInformation("Successfully created Trello card: {CardId} - {Name}", card?.Id, name);
            return card;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating Trello card: {Name}", name);
            throw;
        }
    }

    /// <summary>
    /// Update an existing card
    /// </summary>
    public async Task<TrelloCard?> UpdateCardAsync(string cardId, string? name = null, string? description = null, DateTime? dueDate = null)
    {
        try
        {
            var url = $"/cards/{cardId}?key={_apiKey}&token={_token}";

            if (!string.IsNullOrEmpty(name))
                url += $"&name={Uri.EscapeDataString(name)}";

            if (description != null)
                url += $"&desc={Uri.EscapeDataString(description)}";

            if (dueDate.HasValue)
                url += $"&due={dueDate.Value:yyyy-MM-ddTHH:mm:ss.fffZ}";

            var response = await _httpClient.PutAsync(url, null);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var card = JsonSerializer.Deserialize<TrelloCard>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            _logger.LogInformation("Successfully updated Trello card: {CardId}", cardId);
            return card;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating Trello card: {CardId}", cardId);
            throw;
        }
    }

    /// <summary>
    /// Get a single card by ID
    /// </summary>
    public async Task<TrelloCard?> GetCardAsync(string cardId)
    {
        try
        {
            var url = $"/cards/{cardId}?key={_apiKey}&token={_token}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var card = JsonSerializer.Deserialize<TrelloCard>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return card;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching Trello card: {CardId}", cardId);
            throw;
        }
    }

    /// <summary>
    /// Get all lists in the board
    /// </summary>
    public async Task<List<TrelloList>> GetBoardListsAsync()
    {
        try
        {
            var url = $"boards/{_boardId}/lists?key={_apiKey}&token={_token}";
            var fullUrl = _httpClient.BaseAddress != null ? new Uri(_httpClient.BaseAddress, url).ToString() : url;
            _logger.LogInformation("Requesting Trello Lists API: {Url}", fullUrl);

            var response = await _httpClient.GetAsync(url);

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Trello API returned {StatusCode} when fetching lists: {Content}",
                    response.StatusCode, content.Length > 500 ? content.Substring(0, 500) : content);
            }

            response.EnsureSuccessStatusCode();

            // Check if response is JSON
            if (content.TrimStart().StartsWith("<"))
            {
                _logger.LogError("Trello API returned HTML instead of JSON when fetching lists. First 200 chars: {Content}",
                    content.Length > 200 ? content.Substring(0, 200) : content);
                throw new Exception("Trello API returned HTML instead of JSON. Possible rate limit or API error.");
            }

            var lists = JsonSerializer.Deserialize<List<TrelloList>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return lists ?? new List<TrelloList>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching lists from Trello board {BoardId}", _boardId);
            throw;
        }
    }

    /// <summary>
    /// Get the first list ID (for default card creation)
    /// </summary>
    private async Task<string> GetFirstListIdAsync()
    {
        var lists = await GetBoardListsAsync();
        if (lists.Count == 0)
            throw new Exception($"No lists found in Trello board {_boardId}");

        return lists[0].Id!;
    }

    /// <summary>
    /// Create webhook for real-time updates
    /// </summary>
    public async Task<bool> CreateWebhookAsync(string callbackUrl)
    {
        try
        {
            var url = $"/webhooks?key={_apiKey}&token={_token}";
            url += $"&idModel={_boardId}";
            url += $"&callbackURL={Uri.EscapeDataString(callbackUrl)}";

            var response = await _httpClient.PostAsync(url, null);
            response.EnsureSuccessStatusCode();

            _logger.LogInformation("Successfully created Trello webhook for board {BoardId}", _boardId);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating Trello webhook");
            return false;
        }
    }
}

// DTOs for Trello API responses
public class TrelloCard
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Desc { get; set; }
    public DateTime? Due { get; set; }
    public string? IdList { get; set; }
    public List<string>? IdMembers { get; set; }
    public List<TrelloChecklist>? Checklists { get; set; }
    public DateTime? DateLastActivity { get; set; }
}

public class TrelloList
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public bool? Closed { get; set; }
}

public class TrelloChecklist
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public List<TrelloCheckItem>? CheckItems { get; set; }
}

public class TrelloCheckItem
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? State { get; set; } // "complete" or "incomplete"
}
