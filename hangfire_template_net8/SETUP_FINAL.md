# 🚀 SETUP LENGKAP - Hangfire Trello ↔ OpenProject Sync

## 📋 Yang Dibutuhkan

1. **Docker** sudah terinstall (cek: `docker --version`)
2. **API Key Trello** (gratis)
3. **API Key OpenProject** (gratis)

---

## 🎯 LANGKAH 1: PERSIAPAN

### 1.1 Extract File ZIP
```bash
# Extract file yang Anda terima
unzip hangfire-trello-openproject-sync.zip
cd hangfire_template_net8
```

Di Windows: Klik kanan ZIP → Extract All

### 1.2 Pastikan Docker Berjalan
```bash
# Cek Docker running
docker ps
```

Jika error, start Docker Desktop dulu.

---

## 🔑 LANGKAH 2: DAPATKAN API KEYS

### 2.1 Trello API Key

**A. Dapatkan API Key dan Token:**
1. Buka: https://trello.com/power-ups/admin
2. Klik **"New"** untuk buat Power-Up baru (atau pilih existing)
3. Beri nama (misal: "My Sync App")
4. Klik **"Generate a new API Key"**
5. **Copy API Key** yang muncul
6. Klik link **"Token"** di samping API Key
7. Klik **"Allow"** untuk authorize
8. **Copy Token** yang muncul

**B. Dapatkan Board ID:**
1. Buka Trello board yang ingin di-sync
2. Lihat URL di browser: `https://trello.com/b/ABC123XYZ/board-name`
3. **Copy bagian `ABC123XYZ`** (Board ID)

### 2.2 OpenProject API Key

**A. Login ke OpenProject:**
```
http://localhost:8080
Username: admin
Password: admin
```

> Jika OpenProject belum running, skip dulu, akan di-setup di langkah 3

**B. Generate API Key:**
1. Klik **avatar** di kanan atas
2. Pilih **"My account"**
3. Tab **"Access tokens"**
4. Klik **"+ API token"**
5. Beri nama (misal: "Hangfire Sync")
6. Klik **"Generate"**
7. **Copy token** yang muncul (hanya muncul sekali!)

**C. Dapatkan Project ID:**
1. Buka project yang ingin di-sync
2. Lihat URL: `http://localhost:8080/projects/demo-project`
3. **Copy bagian `demo-project`** (Project Identifier)

---

## ⚙️ LANGKAH 3: KONFIGURASI

### 3.1 Copy Template Environment
```bash
cp .env.example .env
```

### 3.2 Edit File .env

Buka file `.env` dengan text editor:

```bash
nano .env
# atau
vim .env
# atau gunakan text editor favorit
```

Isi dengan credentials yang sudah didapat:

```env
# SQL Server Password (bisa pakai default atau ganti)
SQL_SERVER_PASSWORD=YourStrong@Password123

# OpenProject Secret (bisa pakai default)
OPENPROJECT_SECRET_KEY=your-secret-key-12345

# WAJIB ISI: OpenProject API (dari langkah 2.2)
OPENPROJECT_API_KEY=f827f0fe0eb3c0a3bed98464982a53eac9c90b3373d953fa999636125b504dd1
OPENPROJECT_PROJECT_ID=demo-project

# WAJIB ISI: Trello API (dari langkah 2.1)
TRELLO_API_KEY=ff571b6e885df6f824a6716393e62b07
TRELLO_TOKEN=ATTA10d3d7f4d4b93ed39e60c86dd0d77ee5f070e9ce22d59806b49d5abb8f925f7cBC4CD527
TRELLO_BOARD_ID=vLKuvCGX
```

**Save dan close** file .env

---

## 🐳 LANGKAH 4: JALANKAN APLIKASI

### Opsi A: Docker Compose (RECOMMENDED)

```bash
docker-compose up -d
```

### Opsi B: Manual Step-by-Step

```bash
# 1. Buat network
docker network create hangfire-net

# 2. Start SQL Server
docker run -d \
  --name hangfire-sqlserver \
  --network hangfire-net \
  -e ACCEPT_EULA=Y \
  -e "SA_PASSWORD=YourStrong@Password123" \
  -p 1433:1433 \
  mcr.microsoft.com/mssql/server:2022-latest

# 3. Start OpenProject
docker run -d \
  --name hangfire-openproject \
  --network hangfire-net \
  -e OPENPROJECT_HOST__NAME=localhost:8080 \
  -p 8080:80 \
  openproject/openproject:14

# Tunggu 2-3 menit untuk OpenProject ready

# 4. Build aplikasi
docker build -t hangfire-sync-app .

# 5. Run aplikasi (ganti YOUR_* dengan nilai dari .env)
docker run -d \
  --name hangfire-app \
  --network hangfire-net \
  -e "ConnectionStrings__DefaultConnection=Server=hangfire-sqlserver,1433;Database=hangfire_sync_db;User Id=sa;Password=YourStrong@Password123;TrustServerCertificate=True;" \
  -e "OpenProject__Url=http://hangfire-openproject" \
  -e "OpenProject__ApiKey=YOUR_OPENPROJECT_API_KEY" \
  -e "OpenProject__DefaultProjectId=YOUR_PROJECT_ID" \
  -e "Trello__ApiKey=YOUR_TRELLO_API_KEY" \
  -e "Trello__Token=YOUR_TRELLO_TOKEN" \
  -e "Trello__BoardId=YOUR_TRELLO_BOARD_ID" \
  -p 5000:5000 \
  hangfire-sync-app
```

**Di Windows PowerShell**, ganti `\` dengan backtick `` ` ``

---

## ⏳ LANGKAH 5: TUNGGU SERVICES SIAP

```bash
# Cek status containers
docker ps

# Lihat logs
docker-compose logs -f
# atau manual: docker logs -f hangfire-app
```

**Tunggu sampai muncul:**
```
Now listening on: http://+:5000
Hangfire Server started successfully
```

**Tekan Ctrl+C** untuk keluar dari logs

---

## ✅ LANGKAH 6: VERIFIKASI & TEST

### 6.1 Akses Aplikasi

Buka di browser:

| Service | URL | Login |
|---------|-----|-------|
| Hangfire Dashboard | http://localhost:5000/hangfire | - |
| OpenProject | http://localhost:8080 | admin / admin |

### 6.2 Cek Hangfire Dashboard

1. Buka: http://localhost:5000/hangfire
2. Klik tab **"Recurring jobs"**
3. Pastikan ada 4 jobs:
   - `fetch-from-openproject` (10 menit)
   - `fetch-from-trello` (10 menit)
   - `sync-to-openproject` (2 menit)
   - `sync-to-trello` (2 menit)

### 6.3 Test Sinkronisasi Trello → OpenProject

1. Buka **Trello board** Anda
2. **Buat card baru** (contoh: "Test Sync Card")
3. **Tunggu maksimal 10 menit**
4. Buka **OpenProject**: http://localhost:8080
5. Login (admin/admin)
6. Klik **"Work packages"** di sidebar
7. Card dari Trello **sudah muncul** sebagai work package!

### 6.4 Test Sinkronisasi OpenProject → Trello

1. Buka **OpenProject**: http://localhost:8080
2. Klik **"+ Create"** → **"Work package"**
3. Isi:
   - Subject: "Test from OpenProject"
   - Type: Task
   - Save
4. **Tunggu maksimal 10 menit**
5. Buka **Trello board**
6. Work package **sudah muncul** sebagai card!

---

## 🔧 COMMANDS BERGUNA

### Kontrol Aplikasi

```bash
# Stop semua
docker-compose down

# Start semua
docker-compose up -d

# Restart aplikasi (setelah ubah .env)
docker-compose restart hangfire-app

# Rebuild (setelah ubah code)
docker-compose up -d --build
```

### Monitoring

```bash
# Lihat logs semua services
docker-compose logs -f

# Lihat logs aplikasi saja
docker-compose logs -f hangfire-app

# Lihat logs OpenProject
docker-compose logs -f openproject

# Cek status containers
docker ps
```

### Cleanup

```bash
# Stop dan hapus containers (data tetap ada)
docker-compose down

# Hapus semua termasuk data (HATI-HATI!)
docker-compose down -v
```

---

## 🐛 TROUBLESHOOTING

### Problem: "Cannot connect to Docker daemon"
```bash
# Pastikan Docker running
sudo systemctl start docker  # Linux
# atau start Docker Desktop (Windows/Mac)
```

### Problem: Port sudah dipakai (1433, 5000, 8080)
```bash
# Cek port yang dipakai
sudo lsof -i :5000
sudo lsof -i :8080
sudo lsof -i :1433

# Ganti port di docker-compose.yml jika perlu
```

### Problem: SQL Server tidak bisa start
```bash
# Cek logs
docker logs hangfire-sqlserver

# Password harus strong (min 8 char, huruf besar, kecil, angka, simbol)
# Edit .env, ganti SQL_SERVER_PASSWORD
```

### Problem: OpenProject stuck di "Loading..."
```bash
# OpenProject butuh waktu 2-3 menit pertama kali
# Tunggu, atau cek logs:
docker logs hangfire-openproject

# Tunggu sampai muncul: "Assets precompilation completed"
```

### Problem: Sync tidak jalan
```bash
# 1. Cek Hangfire Dashboard
http://localhost:5000/hangfire

# 2. Tab "Failed Jobs" → lihat error
# 3. Biasanya karena API Key salah

# 4. Cek logs detail
docker-compose logs -f hangfire-app | grep -i error
```

### Problem: Trello API error "Invalid token"
```bash
# Token Trello expired atau salah
# 1. Generate ulang token di: https://trello.com/power-ups/admin
# 2. Update .env
# 3. Restart: docker-compose restart hangfire-app
```

### Problem: OpenProject API error 401
```bash
# API Key salah atau expired
# 1. Login OpenProject → My Account → Access tokens
# 2. Generate token baru
# 3. Update .env
# 4. Restart: docker-compose restart hangfire-app
```

---

## 📊 SYNC SCHEDULE

| Job | Interval | Keterangan |
|-----|----------|------------|
| Fetch dari Trello | 10 menit | Ambil card baru dari Trello |
| Sync ke OpenProject | 2 menit | Kirim update ke OpenProject |
| Fetch dari OpenProject | 10 menit | Ambil work packages baru |
| Sync ke Trello | 2 menit | Kirim update ke Trello |

**Maksimal delay sync: 10 menit**

---

## 🔐 KEAMANAN

**PENTING:**
- ❌ **JANGAN** commit file `.env` ke git (sudah ada di .gitignore)
- ✅ File `.env.example` aman untuk share (template kosong)
- ✅ Ganti password default di production
- ✅ Gunakan HTTPS untuk production

---

## 📁 STRUKTUR FILE

```
hangfire_template_net8/
├── docker-compose.yml      # Konfigurasi Docker
├── Dockerfile             # Container .NET app
├── .env                   # YOUR CREDENTIALS (jangan share!)
├── .env.example          # Template (aman untuk share)
├── SETUP_FINAL.md        # File ini
├── Program.cs            # Entry point
├── appsettings.json      # App config
├── Services/             # Background jobs
├── Controllers/          # API endpoints
├── Models/              # Database models
└── Data/                # EF Core context
```

---

## ✅ CHECKLIST SELESAI

Pastikan semua ini sudah:
- [ ] Docker running
- [ ] File .env sudah diisi dengan API keys yang benar
- [ ] `docker-compose up -d` sudah dijalankan
- [ ] Semua 3 containers running (`docker ps`)
- [ ] Hangfire Dashboard accessible (http://localhost:5000/hangfire)
- [ ] OpenProject accessible (http://localhost:8080)
- [ ] 4 recurring jobs muncul di Hangfire
- [ ] Test sync berhasil (Trello → OpenProject)
- [ ] Test sync berhasil (OpenProject → Trello)

---

## 🎉 SELESAI!

Aplikasi sekarang running dan otomatis sync setiap:
- **10 menit** untuk fetch data
- **2 menit** untuk push updates

Setiap card baru di Trello akan otomatis muncul di OpenProject, dan sebaliknya!

---

## 📞 BUTUH BANTUAN?

1. Cek Hangfire Dashboard untuk detail error
2. Lihat logs: `docker-compose logs -f`
3. Pastikan API keys benar di file `.env`
4. Cek troubleshooting section di atas

**Happy Syncing! 🚀**
