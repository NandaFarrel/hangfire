using Hangfire;
using Hangfire.SqlServer;
using hangfire_template.Data;
using hangfire_template.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(); // For JSON serialization

builder.Services.AddRazorPages();

// Database Context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Hangfire Configuration (added before building app)
builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(builder.Configuration.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions
    {
        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
        QueuePollInterval = TimeSpan.Zero,
        UseRecommendedIsolationLevel = true,
        DisableGlobalLocks = true
    }));

// Add Hangfire Server
builder.Services.AddHangfireServer(options =>
{
    options.WorkerCount = builder.Configuration.GetValue<int>("Hangfire:WorkerCount", 5);
    options.Queues = builder.Configuration.GetSection("Hangfire:Queues").Get<string[]>()
        ?? new[] { "default", "openproject-sync", "trello-sync" };
});

// Register Services
builder.Services.AddHttpClient<OpenProjectApiService>();
builder.Services.AddHttpClient<TrelloApiService>(client =>
{
    client.BaseAddress = new Uri("https://api.trello.com/1/");
    client.Timeout = TimeSpan.FromSeconds(30);
});
builder.Services.AddScoped<OpenProjectFetchJob>();
builder.Services.AddScoped<OpenProjectSyncJob>();
builder.Services.AddScoped<TrelloFetchJob>();
builder.Services.AddScoped<TrelloSyncJob>();

var app = builder.Build();

// Initialize Database BEFORE using Hangfire
// This ensures the database and Hangfire schema exist
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    try
    {
        // Apply pending migrations and ensure database is created
        dbContext.Database.Migrate();
        Console.WriteLine("✅ Database migration completed successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"⚠️ Database migration error: {ex.Message}");
        throw; // Fail startup if database migration fails
    }
}

// Initialize Hangfire schema
using (var scope = app.Services.CreateScope())
{
    var hangfireConnection = builder.Configuration.GetConnectionString("HangfireConnection");
    try
    {
        SqlServerObjectsInstaller.Install(new SqlConnection(hangfireConnection));
        Console.WriteLine("✅ Hangfire schema initialized successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"⚠️ Hangfire schema initialization warning: {ex.Message}");
        // Don't fail startup if schema already exists
    }
}

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Don't redirect to HTTPS in Docker - HTTP is fine for internal communication
// app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Hangfire Dashboard
app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    Authorization = new[] { new HangfireAuthorizationFilter() }
});

// Map Controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "api",
    pattern: "api/{controller}/{action}/{id?}");

// Schedule Recurring Jobs
RecurringJob.AddOrUpdate<OpenProjectFetchJob>(
    "fetch-from-openproject",
    job => job.FetchAllWorkPackagesAsync(),
    builder.Configuration["Hangfire:SyncIntervals:OpenProjectFetch"] ?? "*/5 * * * *");

RecurringJob.AddOrUpdate<OpenProjectSyncJob>(
    "sync-to-openproject",
    job => job.SyncToOpenProjectAsync(),
    builder.Configuration["Hangfire:SyncIntervals:OpenProjectSync"] ?? "*/1 * * * *");

RecurringJob.AddOrUpdate<TrelloFetchJob>(
    "fetch-from-trello",
    job => job.FetchAllCardsAsync(),
    builder.Configuration["Hangfire:SyncIntervals:TrelloFetch"] ?? "*/5 * * * *");

RecurringJob.AddOrUpdate<TrelloSyncJob>(
    "sync-to-trello",
    job => job.SyncToTrelloAsync(),
    builder.Configuration["Hangfire:SyncIntervals:TrelloSync"] ?? "*/1 * * * *");

app.Run();

// Hangfire Authorization Filter (allow all for development)
public class HangfireAuthorizationFilter : Hangfire.Dashboard.IDashboardAuthorizationFilter
{
    public bool Authorize(Hangfire.Dashboard.DashboardContext context) => true;
}
