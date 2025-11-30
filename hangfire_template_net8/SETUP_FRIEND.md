# Setup Guide - Untuk Teman Yang Dapat Folder Ini

## Error Yang Anda Alami (SOLVED!)

Error "No .NET SDKs were found" sudah diperbaiki di Dockerfile.
Anda tidak perlu install .NET SDK di komputer Anda - cukup Docker saja!

## Cara Menjalankan (SUPER SIMPEL!)

### Step 1: Pastikan Docker Running

```bash
docker --version
```

Jika belum ada, install Docker Desktop dari: https://www.docker.com/products/docker-desktop

### Step 2: Copy File .env

```bash
cd hangfire_template_net8
cp .env.example .env
```

### Step 3: Edit File .env (PENTING!)

Buka file `.env` dan isi dengan credentials Anda:

```bash
nano .env
# atau
code .env
# atau buka dengan text editor apapun
```

Yang WAJIB diisi:
- `SQL_SERVER_PASSWORD` - password SQL Server (bisa pakai default: YourStrong@Password123)
- `TRELLO_API_KEY` - dari https://trello.com/power-ups/admin
- `TRELLO_TOKEN` - dari halaman yang sama
- `TRELLO_BOARD_ID` - dari URL Trello board Anda
- `OPENPROJECT_API_KEY` - dari OpenProject → My Account → Access tokens
- `OPENPROJECT_PROJECT_ID` - nama project di OpenProject (contoh: demo-project)

### Step 4: Jalankan!

```bash
./start.sh
```

ATAU jika start.sh tidak bisa dijalankan:

```bash
chmod +x start.sh
./start.sh
```

ATAU manual:

```bash
docker-compose up -d
```

### Step 5: Tunggu 2-3 Menit

Services butuh waktu untuk start. Cek status dengan:

```bash
docker-compose ps
```

Pastikan semua status "Up" dan healthy.

### Step 6: Akses Aplikasi

- Hangfire Dashboard: http://localhost:5000/hangfire
- OpenProject: http://localhost:8080 (login: admin/admin)
- API: http://localhost:5000

## Troubleshooting

### Error: "port is already allocated"

Port 5000, 8080, atau 1433 sudah dipakai. Stop service yang pakai port itu, atau edit `docker-compose.yml` ubah port-nya.

```bash
# Cek port yang dipakai
sudo lsof -i :5000
sudo lsof -i :8080
sudo lsof -i :1433
```

### Error: "permission denied"

```bash
sudo chmod +x start.sh
./start.sh
```

### Aplikasi tidak bisa connect ke database

Tunggu lebih lama (SQL Server butuh 30-60 detik untuk fully start). Cek logs:

```bash
docker-compose logs sqlserver
```

### Mau lihat logs aplikasi

```bash
# All services
docker-compose logs -f

# Hanya app
docker-compose logs -f hangfire-app

# Hanya database
docker-compose logs -f sqlserver
```

### Mau restart dari awal

```bash
# Stop semua
docker-compose down

# Hapus database (fresh start)
docker-compose down -v

# Start lagi
docker-compose up -d
```

## Struktur File Yang Penting

```
hangfire_template_net8/
├── .env                    ← WAJIB ada & isi ini!
├── .env.example            ← Template untuk .env
├── docker-compose.yml      ← Config Docker
├── Dockerfile              ← Config image (sudah fixed!)
├── start.sh                ← Script otomatis
├── README.md               ← Dokumentasi lengkap
└── SETUP_FRIEND.md         ← File ini (panduan simple)
```

## Kalau Sudah Jalan

1. Buka http://localhost:5000/hangfire - lihat background jobs
2. Buka http://localhost:8080 - setup OpenProject (login: admin/admin)
3. Buat cards di Trello - otomatis sync ke OpenProject
4. Update work packages di OpenProject - otomatis sync ke Trello

## Stop Aplikasi

```bash
docker-compose down
```

## FAQ

**Q: Apakah saya perlu install .NET SDK?**
A: TIDAK! Anda hanya perlu Docker. .NET SDK sudah ada di dalam Docker image.

**Q: Kenapa folder .vs/ dan bin/ tidak ada?**
A: Tidak masalah. Itu akan di-generate otomatis saat Docker build.

**Q: Apakah saya perlu install SQL Server?**
A: TIDAK! SQL Server sudah otomatis jalan di Docker.

**Q: File appsettings.json perlu diubah?**
A: TIDAK! Config sudah diambil dari file .env via docker-compose.

**Q: Error masih muncul?**
A: Kirim screenshot error-nya ke yang kasih folder ini!

---

Selamat mencoba! Jika masih error, kontak yang kasih folder ini ya.
