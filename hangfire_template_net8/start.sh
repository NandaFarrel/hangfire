#!/bin/bash

echo "=================================================="
echo "🚀 Hangfire Trello-OpenProject Sync Setup"
echo "=================================================="
echo ""

# Check if .env exists
if [ ! -f .env ]; then
    echo "❌ File .env tidak ditemukan!"
    echo ""
    echo "📝 Silakan buat file .env terlebih dahulu:"
    echo "   1. Copy file .env.example: cp .env.example .env"
    echo "   2. Edit file .env dan isi dengan API keys Anda"
    echo ""
    echo "Lihat SETUP.md untuk panduan lengkap."
    exit 1
fi

echo "✅ File .env ditemukan"
echo ""

# Check if Docker is running
if ! docker info > /dev/null 2>&1; then
    echo "❌ Docker tidak berjalan!"
    echo "   Silakan start Docker terlebih dahulu."
    exit 1
fi

echo "✅ Docker berjalan"
echo ""

# Start services
echo "🔧 Memulai services..."
echo ""
docker-compose up -d

echo ""
echo "⏳ Tunggu services siap (sekitar 2-3 menit)..."
echo ""

# Wait for services
sleep 10

echo "=================================================="
echo "✅ Setup selesai!"
echo "=================================================="
echo ""
echo "📊 Akses aplikasi:"
echo "   - Hangfire Dashboard: http://localhost:5000/hangfire"
echo "   - OpenProject:        http://localhost:8080 (admin/admin)"
echo ""
echo "🔍 Cek status services:"
echo "   docker-compose ps"
echo ""
echo "📋 Lihat logs:"
echo "   docker-compose logs -f hangfire-app"
echo ""
echo "🛑 Stop services:"
echo "   docker-compose down"
echo ""
echo "Happy Syncing! 🎉"
