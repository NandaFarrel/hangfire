# 🚀 Setup Guide - Hangfire Trello ↔ OpenProject Sync

## 📋 Prerequisites

Pastikan sudah terinstall:
- ✅ **Docker** dan **Docker Compose**

Cek dengan command:
```bash
docker --version
docker-compose --version
```

---

## 🔧 Quick Setup (3 Langkah Mudah!)

### **1. Extract File ZIP**

```bash
# Extract file ZIP yang Anda terima
unzip hangfire-trello-openproject-sync.zip
cd hangfire_template_net8
```

> Atau di Windows: Klik kanan ZIP → Extract All

### **2. Setup Environment Variables**

Copy file `.env.example` menjadi `.env`:

```bash
cp .env.example .env
```

Edit file `.env` dan isi dengan credentials Anda:

```bash
nano .env
# atau
vim .env
# atau buka dengan text editor favorit
```

**Isi yang perlu diubah:**

#### 🔐 **SQL Server**
```env
SQL_SERVER_PASSWORD=YourStrong@Password123
```
> Ganti dengan password strong (minimal 8 karakter)

#### 🔵 **OpenProject API**
```env
OPENPROJECT_API_KEY=your-openproject-api-key-here
OPENPROJECT_PROJECT_ID=demo-project
```

**Cara dapat OpenProject API Key:**
1. Login ke OpenProject
2. Klik **avatar** di kanan atas → **My Account**
3. Tab **Access tokens** → **Generate**
4. Copy token yang muncul

**Cara dapat Project ID:**
- Buka project di OpenProject
- Lihat URL: `http://localhost:8080/projects/DEMO-PROJECT`
- Ambil bagian `demo-project` (lowercase)

#### 🟢 **Trello API**
```env
TRELLO_API_KEY=your-trello-api-key-here
TRELLO_TOKEN=your-trello-token-here
TRELLO_BOARD_ID=your-board-id
```

**Cara dapat Trello API Key & Token:**
1. Buka: https://trello.com/power-ups/admin
2. Pilih workspace atau buat baru
3. Buat **New Power-Up**
4. Klik **API Key** → Copy
5. Klik **Token** link → Authorize → Copy token

**Cara dapat Board ID:**
1. Buka Trello board di browser
2. Lihat URL: `https://trello.com/b/ABC123XYZ/board-name`
3. Ambil bagian `ABC123XYZ`

### **3. Jalankan Aplikasi**

**Opsi A: Otomatis dengan Script (Linux/Mac)**
```bash
./start.sh
```

**Opsi B: Manual dengan Docker Compose (Semua OS)**

```bash
# Jalankan semua services
docker-compose up -d
```

**Tunggu 2-3 menit** untuk semua service siap!

**Opsi C: Setup Manual dari Awal (Tanpa Docker Compose)**

Jika ingin control penuh atau troubleshoot:

```bash
# 1. Start SQL Server
docker run -d \
  --name hangfire-sqlserver \
  --network hangfire-net \
  -e ACCEPT_EULA=Y \
  -e SA_PASSWORD=YourStrong@Password123 \
  -p 1433:1433 \
  mcr.microsoft.com/mssql/server:2022-latest

# 2. Start OpenProject
docker run -d \
  --name hangfire-openproject \
  --network hangfire-net \
  -e OPENPROJECT_HOST__NAME=localhost:8080 \
  -p 8080:80 \
  openproject/openproject:14

# 3. Build aplikasi .NET
docker build -t hangfire-sync-app .

# 4. Run aplikasi
docker run -d \
  --name hangfire-app \
  --network hangfire-net \
  -e ConnectionStrings__DefaultConnection="Server=hangfire-sqlserver,1433;Database=hangfire_sync_db;User Id=sa;Password=YourStrong@Password123;TrustServerCertificate=True;" \
  -e OpenProject__Url="http://hangfire-openproject" \
  -e OpenProject__ApiKey="YOUR_API_KEY" \
  -e Trello__ApiKey="YOUR_TRELLO_KEY" \
  -e Trello__Token="YOUR_TRELLO_TOKEN" \
  -e Trello__BoardId="YOUR_BOARD_ID" \
  -p 5000:5000 \
  hangfire-sync-app
```

> ⚠️ **Catatan**: Ganti `YOUR_API_KEY`, dll dengan nilai sebenarnya dari file `.env` Anda

---

## 📊 Akses Aplikasi

Setelah `docker-compose up` selesai:

| Service | URL | Default Login |
|---------|-----|---------------|
| **Hangfire Dashboard** | http://localhost:5000/hangfire | - |
| **OpenProject** | http://localhost:8080 | `admin` / `admin` |
| **API** | http://localhost:5000 | - |

---

## ✅ Verifikasi Setup

### 1. Cek semua container running:
```bash
docker-compose ps
```

Harus muncul 3 services: `sqlserver`, `openproject`, `hangfire-app`

### 2. Cek logs aplikasi:
```bash
docker-compose logs -f hangfire-app
```

Tunggu sampai muncul:
```
Now listening on: http://+:5000
Hangfire Server started successfully
```

### 3. Test sinkronisasi:
1. Buka **Trello** → Buat card baru di board Anda
2. Tunggu **maksimal 10 menit**
3. Buka **OpenProject** → Cek di project → Card sudah muncul sebagai work package!

---

## 🔄 Background Jobs Schedule

| Job | Interval | Deskripsi |
|-----|----------|-----------|
| `fetch-from-trello` | 10 menit | Ambil card baru dari Trello |
| `sync-to-trello` | 2 menit | Kirim update ke Trello |
| `fetch-from-openproject` | 10 menit | Ambil work packages dari OpenProject |
| `sync-to-openproject` | 2 menit | Kirim update ke OpenProject |

---

## 🛠️ Commands

### **Dengan Docker Compose:**

```bash
# Jalankan aplikasi
docker-compose up -d

# Stop aplikasi
docker-compose down

# Restart setelah update .env
docker-compose restart hangfire-app

# Lihat logs semua services
docker-compose logs -f

# Lihat logs aplikasi saja
docker-compose logs -f hangfire-app

# Rebuild setelah ubah code
docker-compose up -d --build

# Hapus semua data (HATI-HATI!)
docker-compose down -v
```

### **Manual (Tanpa Docker Compose):**

```bash
# Create network (hanya sekali)
docker network create hangfire-net

# Stop semua containers
docker stop hangfire-app hangfire-openproject hangfire-sqlserver

# Start semua containers
docker start hangfire-sqlserver hangfire-openproject hangfire-app

# Hapus semua containers
docker rm -f hangfire-app hangfire-openproject hangfire-sqlserver

# Lihat logs aplikasi
docker logs -f hangfire-app

# Lihat logs OpenProject
docker logs -f hangfire-openproject
```

### **Windows PowerShell:**

Jika menggunakan PowerShell di Windows, ganti `\` dengan `` ` `` (backtick):

```powershell
# Contoh: Start SQL Server
docker run -d `
  --name hangfire-sqlserver `
  -e ACCEPT_EULA=Y `
  -e SA_PASSWORD=YourStrong@Password123 `
  -p 1433:1433 `
  mcr.microsoft.com/mssql/server:2022-latest
```

Atau jalankan dalam satu baris tanpa line break

---

## 🐛 Troubleshooting

### Problem: Container tidak bisa start
```bash
# Cek error logs
docker-compose logs

# Restart semua
docker-compose restart
```

### Problem: Database connection error
```bash
# Cek SQL Server sudah ready
docker-compose logs sqlserver | grep "SQL Server is now ready"

# Jika belum ready, tunggu 30 detik lagi
```

### Problem: OpenProject tidak bisa diakses
```bash
# OpenProject butuh waktu 2-3 menit untuk fully ready
# Cek logs:
docker-compose logs openproject

# Tunggu sampai muncul "Assets precompilation completed"
```

### Problem: Sync tidak jalan
1. Cek Hangfire Dashboard: http://localhost:5000/hangfire
2. Lihat tab **"Recurring Jobs"** → pastikan semua job ada
3. Lihat tab **"Failed Jobs"** → cek error message
4. Pastikan API keys di `.env` sudah benar

---

## 📁 File Structure

```
hangfire_template_net8/
├── docker-compose.yml      # Docker orchestration
├── Dockerfile             # .NET app container
├── .env.example          # Template environment variables
├── .env                  # Your actual credentials (gitignored)
├── SETUP.md             # This file
├── README.md            # Documentation
├── Program.cs           # App entry point
├── appsettings.json    # App configuration
├── Services/           # Background jobs
├── Controllers/        # API endpoints
├── Models/            # Database models
└── Data/              # EF Core context
```

---

## 🔐 Security Notes

⚠️ **PENTING:**
- File `.env` berisi credentials rahasia
- **JANGAN** commit file `.env` ke git!
- File `.env.example` adalah template tanpa credentials (aman untuk commit)
- Untuk production, gunakan secrets management (Azure Key Vault, AWS Secrets, dll)

---

## 📞 Support

Jika ada masalah:
1. Cek logs: `docker-compose logs -f`
2. Cek Hangfire Dashboard untuk error details
3. Pastikan semua credentials di `.env` benar

---

**Happy Syncing! 🎉**
