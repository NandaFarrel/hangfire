#!/bin/bash

echo "=================================================="
echo "📦 Preparing ZIP file for distribution"
echo "=================================================="
echo ""

# Get current directory name
PROJECT_NAME=$(basename "$PWD")
ZIP_NAME="${PROJECT_NAME}-$(date +%Y%m%d).zip"

# Clean build artifacts
echo "🧹 Cleaning build artifacts..."
rm -rf bin/ obj/

# Create temporary directory
TEMP_DIR="/tmp/hangfire-zip-prep"
rm -rf "$TEMP_DIR"
mkdir -p "$TEMP_DIR"

# Copy files to temp directory (excluding unnecessary files)
echo "📋 Copying files..."
rsync -av --progress . "$TEMP_DIR/$PROJECT_NAME" \
  --exclude 'bin/' \
  --exclude 'obj/' \
  --exclude '.vs/' \
  --exclude '.vscode/' \
  --exclude '.env' \
  --exclude '*.user' \
  --exclude '*.suo' \
  --exclude '.git/' \
  --exclude '*.zip' \
  --exclude 'prepare-zip.sh'

# Create ZIP file
echo ""
echo "📦 Creating ZIP file: $ZIP_NAME"
cd "$TEMP_DIR"
zip -r "$ZIP_NAME" "$PROJECT_NAME" -q

# Move ZIP to original directory
mv "$ZIP_NAME" "$OLDPWD/"

# Cleanup
rm -rf "$TEMP_DIR"

echo ""
echo "=================================================="
echo "✅ ZIP file created successfully!"
echo "=================================================="
echo ""
echo "📁 File: $ZIP_NAME"
echo "📏 Size: $(du -h "$OLDPWD/$ZIP_NAME" | cut -f1)"
echo ""
echo "📤 Sekarang Anda bisa share file ZIP ini ke teman!"
echo ""
echo "File yang TIDAK disertakan (aman):"
echo "  - bin/, obj/ (build artifacts)"
echo "  - .env (credentials Anda)"
echo "  - .git/ (git history)"
echo "  - .vs/, .vscode/ (IDE settings)"
echo ""
echo "File yang SUDAH disertakan:"
echo "  ✅ Source code (.cs files)"
echo "  ✅ Docker configuration"
echo "  ✅ .env.example (template)"
echo "  ✅ README & SETUP documentation"
echo "  ✅ start.sh script"
echo ""
