# 📤 Panduan Share Kode ke Teman

## Cara Membuat ZIP File untuk Distribusi

### **Opsi 1: Otomatis (Recommended)**

Jalankan script yang sudah disediakan:

```bash
./prepare-zip.sh
```

Script ini akan:
- ✅ Membersihkan file build (`bin/`, `obj/`)
- ✅ Exclude file credentials Anda (`.env`)
- ✅ Exclude git history (`.git/`)
- ✅ Exclude IDE settings (`.vs/`, `.vscode/`)
- ✅ Membuat ZIP file dengan nama: `hangfire_template_net8-YYYYMMDD.zip`

**File ZIP akan dibuat di folder yang sama.**

---

### **Opsi 2: Manual**

Jika tidak bisa run script, buat ZIP manual dengan **WAJIB exclude**:

**Folder/File yang HARUS DIHAPUS sebelum ZIP:**
```
bin/          ← Build artifacts
obj/          ← Build artifacts
.env          ← CREDENTIALS ANDA! (Jangan share!)
.vs/          ← Visual Studio settings
.vscode/      ← VS Code settings
.git/         ← Git history (optional)
```

**File yang HARUS ADA di ZIP:**
```
✅ Source code (*.cs files)
✅ Dockerfile
✅ docker-compose.yml
✅ .env.example         ← Template (BUKAN .env!)
✅ README.md
✅ SETUP.md
✅ README_FIRST.txt
✅ start.sh
✅ appsettings.json
✅ *.csproj
✅ Services/
✅ Controllers/
✅ Models/
✅ Data/
✅ Migrations/
```

**Cara buat ZIP manual:**

**Di Linux/Mac:**
```bash
# Hapus file-file yang tidak perlu
rm -rf bin/ obj/ .env

# Buat ZIP (dari parent directory)
cd ..
zip -r hangfire-sync.zip hangfire_template_net8 \
  -x "*/bin/*" "*/obj/*" "*/.env" "*/.vs/*" "*/.git/*"
```

**Di Windows:**
1. Hapus folder `bin`, `obj`, `.vs`
2. Hapus file `.env` (PENTING!)
3. Klik kanan folder → Send to → Compressed (zipped) folder

---

## 📧 Kirim ke Teman

Setelah ZIP dibuat:

1. **Upload ke cloud storage:**
   - Google Drive
   - Dropbox
   - OneDrive
   - WeTransfer
   - dll.

2. **Share link** ke teman

3. **Kirim instruksi singkat:**

```
Halo!

Ini aplikasi Hangfire untuk sync Trello-OpenProject.

CARA SETUP:
1. Extract ZIP
2. Buka file README_FIRST.txt
3. Ikuti 3 langkah di sana

Yang perlu kamu siapkan:
- Docker sudah terinstall
- API Key Trello (gratis)
- API Key OpenProject (gratis)

Semua panduan lengkap ada di file SETUP.md

Kalau ada masalah, kabarin ya!
```

---

## ⚠️ CHECKLIST Sebelum Share

Pastikan sudah:

- [ ] File `.env` TIDAK ada di ZIP (ini berisi credentials Anda!)
- [ ] File `.env.example` ADA di ZIP (ini template kosong)
- [ ] File `README_FIRST.txt` ada
- [ ] File `SETUP.md` ada
- [ ] File `docker-compose.yml` ada
- [ ] File `Dockerfile` ada
- [ ] File `start.sh` ada (dan executable)
- [ ] Folder `bin/` dan `obj/` tidak ada
- [ ] Test: Extract ZIP di folder lain dan pastikan bisa jalan

---

## 🧪 Test ZIP File

Sebelum share, test dulu:

```bash
# Extract di folder temporary
mkdir /tmp/test-zip
cd /tmp/test-zip
unzip ~/path/to/hangfire-sync.zip

# Cek file .env TIDAK ADA
ls -la hangfire_template_net8/.env
# Harus error: No such file

# Cek .env.example ADA
ls -la hangfire_template_net8/.env.example
# Harus muncul file

# Try run
cd hangfire_template_net8
cp .env.example .env
# Edit .env dengan dummy keys
docker-compose up -d

# Cleanup
cd ~
rm -rf /tmp/test-zip
```

---

## 📊 Size Estimation

ZIP file size (tanpa bin/obj):
- Source code only: ~50-100 KB
- Dengan dokumentasi: ~150-200 KB
- **Total: sekitar 200-300 KB** (sangat kecil!)

Kalau ZIP lebih dari 5 MB, berarti ada folder `bin/` atau `obj/` yang ikut!

---

## 🔒 Keamanan

**PENTING:**

✅ **AMAN untuk share:**
- Source code (*.cs)
- Configuration template (.env.example)
- Docker files
- Documentation

❌ **JANGAN PERNAH share:**
- File `.env` (berisi API keys Anda!)
- Folder `bin/`, `obj/` (tidak perlu)
- Database files (*.db, *.mdf)
- Git history `.git/` (optional, bisa di-share atau tidak)

---

**Semoga membantu! 🎉**
