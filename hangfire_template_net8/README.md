# Hangfire Template .NET 8 - Trello ↔ OpenProject Sync

## 📊 Overview

Aplikasi ini adalah platform **bi-directional synchronization** antara **Trello** dan **OpenProject** menggunakan **Hangfire** background jobs dan **.NET 8**.

## 🚀 Quick Start with Docker

**Hanya 3 langkah untuk menjalankan aplikasi:**

```bash
# 1. Copy environment template
cp .env.example .env

# 2. Edit .env dan isi API keys Anda
nano .env

# 3. Jalankan dengan Docker
./start.sh
# atau
docker-compose up -d
```

**📖 Lihat [SETUP.md](SETUP.md) untuk panduan lengkap setup!**

```
┌──────────┐            ┌──────────────┐            ┌──────────────┐
│  TRELLO  │ ←────────→ │   HANGFIRE   │ ←────────→ │ OPENPROJECT  │
│  Cards   │            │  Background  │            │    Work      │
│          │            │     Jobs     │            │   Packages   │
└──────────┘            └──────────────┘            └──────────────┘
                               ↕
                        ┌──────────────┐
                        │  SQL SERVER  │
                        │   Database   │
                        └──────────────┘
```

## 🚀 Quick Start

### 1. Prerequisites

- ✅ .NET 8 SDK
- ✅ Docker (for SQL Server & OpenProject)
- ✅ Trello account with API credentials
- ✅ OpenProject API key

### 2. Configuration

Edit `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433;Database=hangfire_sync_db;User Id=sa;Password=YourStrong@Password123;TrustServerCertificate=True;"
  },
  "OpenProject": {
    "Url": "http://localhost:8080",
    "ApiKey": "YOUR_OPENPROJECT_API_KEY"
  },
  "Trello": {
    "ApiKey": "YOUR_TRELLO_API_KEY",
    "Token": "YOUR_TRELLO_TOKEN",
    "BoardId": "YOUR_BOARD_ID"
  }
}
```

### 3. Run with Docker (Recommended)

```bash
# Start semua services (SQL Server + OpenProject + App)
docker-compose up -d

# Cek status
docker-compose ps

# Lihat logs
docker-compose logs -f hangfire-app
```

**Atau run manual (without Docker):**

```bash
# Start SQL Server
docker run -d --name sqlserver -p 1433:1433 -e SA_PASSWORD=YourStrong@Password123 mcr.microsoft.com/mssql/server:2022-latest

# Start OpenProject
docker run -d --name openproject -p 8080:80 openproject/openproject:14

# Run migrations
dotnet ef database update

# Run application
dotnet run
```

### 4. Access Hangfire Dashboard

```
http://localhost:5000/hangfire
```

## 🔄 How It Works

### **Sync Flow:**

#### Trello → OpenProject:
1. User updates card di Trello
2. Trello webhook → `/api/webhook/trello`
3. Update database (set `NeedsOpSync = true`)
4. **OpenProjectSyncJob** (every 1 min) detects changes
5. Sync to OpenProject API
6. Mark as synced

#### OpenProject → Trello:
1. User updates work package di OpenProject
2. OpenProject webhook → `/api/webhook/openproject`
3. Update database (set `NeedsTrelloSync = true`)
4. **TrelloSyncJob** (every 1 min) detects changes
5. Sync to Trello API
6. Mark as synced

### **Background Jobs:**

| Job Name | Interval | Purpose |
|----------|----------|---------|
| `fetch-from-openproject` | 5 min | Fetch semua work packages dari OpenProject |
| `sync-to-openproject` | 1 min | Push updates ke OpenProject |
| `fetch-from-trello` | 5 min | Fetch semua cards dari Trello |
| `sync-to-trello` | 1 min | Push updates ke Trello |

## 📁 Project Structure

```
hangfire_template_net8/
├── Program.cs                  # Application entry point
├── appsettings.json           # Configuration
├── Data/
│   └── AppDbContext.cs        # EF Core DbContext
├── Models/
│   ├── TWorkPackage.cs        # Core sync entity
│   ├── TProject.cs
│   ├── TStatus.cs
│   ├── TUser.cs
│   └── ...
├── Services/
│   ├── OpenProjectApiService.cs   # OpenProject HTTP client
│   ├── OpenProjectFetchJob.cs     # Fetch from OpenProject
│   ├── OpenProjectSyncJob.cs      # Sync to OpenProject
│   ├── TrelloApiService.cs        # Trello HTTP client
│   ├── TrelloFetchJob.cs          # Fetch from Trello
│   └── TrelloSyncJob.cs           # Sync to Trello
└── Controllers/
    └── WebhookController.cs       # Webhook endpoints
```

## 🗄️ Database Schema

**Main Table:** `t_work_package`

| Field | Type | Description |
|-------|------|-------------|
| `Id` | int | Primary key |
| `OpenProjectWorkPackageId` | string | OpenProject WP ID (unique) |
| `TrelloCardId` | string | Trello Card ID (unique) |
| `Name` | string | Card/WP name |
| `Description` | text | Description |
| `DueDate` | datetime | Due date |
| `NeedsOpSync` | bool | Flag: needs sync to OpenProject |
| `NeedsTrelloSync` | bool | Flag: needs sync to Trello |
| `LastSyncedAt` | datetime | Last sync timestamp |

## 🔧 Development

```bash
# Build
dotnet build

# Run migrations
dotnet ef migrations add MigrationName
dotnet ef database update

# Run
dotnet run

# Watch mode (auto-reload)
dotnet watch run
```

## 🌐 API Endpoints

| Endpoint | Method | Purpose |
|----------|--------|---------|
| `/hangfire` | GET | Hangfire dashboard |
| `/api/webhook/trello` | POST | Trello webhook |
| `/api/webhook/openproject` | POST | OpenProject webhook |

## 📝 Field Mapping

| Trello | ↔ | OpenProject |
|--------|---|-------------|
| `name` | → | `subject` |
| `desc` | → | `description` |
| `due` | → | `dueDate` |
| `idMembers` | → | `assignee` |
| `idList` | → | `status` (mapped) |

## 🔐 Security Notes

- API keys stored in `appsettings.json` (dev only)
- Production: Use Azure Key Vault atau environment variables
- Hangfire dashboard: No auth (dev only) - implement auth for production

## 📌 TODO

- [ ] Add authentication for Hangfire dashboard
- [ ] Implement conflict resolution strategy
- [ ] Add logging dan monitoring
- [ ] Setup webhooks auto-registration
- [ ] Add unit tests
- [ ] Add Docker Compose untuk easy setup

## 🐛 Troubleshooting

**Problem:** Database connection error
```bash
# Check SQL Server running
docker ps | grep sqlserver

# Test connection
docker exec -it sqlserver /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P 'YourStrong@Password123'
```

**Problem:** OpenProject API error
```bash
# Test API key
curl -u "apikey:YOUR_API_KEY" http://localhost:8080/api/v3/work_packages
```

**Problem:** Trello API error
```bash
# Test Trello credentials
curl "https://api.trello.com/1/boards/YOUR_BOARD_ID/cards?key=YOUR_KEY&token=YOUR_TOKEN"
```

## 📚 References

- [Hangfire Documentation](https://docs.hangfire.io/)
- [OpenProject API v3](https://www.openproject.org/docs/api/)
- [Trello REST API](https://developer.atlassian.com/cloud/trello/rest/)
- [Entity Framework Core](https://docs.microsoft.com/ef/core/)

---

**Generated with Claude Code** 🤖
