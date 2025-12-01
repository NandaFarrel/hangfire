================================================================================
  HANGFIRE TRELLO-OPENPROJECT SYNC - SETUP INSTRUCTIONS
================================================================================

Terima kasih sudah download aplikasi ini!

LANGKAH SETUP (3 LANGKAH MUDAH):
================================================================================

1. EXTRACT FILE ZIP
   - Extract file ZIP ini ke folder pilihan Anda
   - Contoh: C:\Projects\hangfire-sync atau /home/user/hangfire-sync

2. SETUP API KEYS
   - Buka folder hasil extract
   - Copy file: .env.example → .env
   - Edit file .env dengan text editor
   - Isi API keys Trello dan OpenProject Anda

   Cara dapat API Keys:

   TRELLO:
   - Buka: https://trello.com/power-ups/admin
   - Buat Power-Up baru (atau pilih existing)
   - Copy API Key dan Token
   - Copy Board ID dari URL board Anda

   OPENPROJECT:
   - Login ke OpenProject
   - Klik avatar → My Account → Access tokens
   - Generate token baru → Copy
   - Project ID: lihat URL project (misal: demo-project)

3. JALANKAN APLIKASI

   SEMUA OS (Windows/Linux/Mac):
   - Buka Terminal/Command Prompt
   - cd ke folder ini
   - Jalankan: docker-compose up -d

   Atau di Linux/Mac bisa pakai:
   - Jalankan: ./start.sh

   ============================================================
   PENTING: Pastikan Docker sudah running sebelum jalankan!
   ============================================================

================================================================================

SETELAH RUNNING:
================================================================================

Tunggu 2-3 menit, lalu akses:
- Hangfire Dashboard: http://localhost:5000/hangfire
- OpenProject:        http://localhost:8080 (login: admin/admin)

Untuk cek logs:
  docker-compose logs -f hangfire-app

Untuk stop aplikasi:
  docker-compose down

================================================================================

BUTUH BANTUAN?
================================================================================

Baca file SETUP.md untuk panduan lengkap!

Troubleshooting:
- Pastikan Docker sudah running
- Pastikan port 5000, 8080, 1433 tidak dipakai aplikasi lain
- Cek file .env sudah diisi dengan benar
- Lihat logs untuk error detail: docker-compose logs

================================================================================

Happy Syncing! 🎉

================================================================================
