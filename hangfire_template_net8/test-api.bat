@echo off
REM Test OpenProject API connections
setlocal enabledelayedexpansion

set OPENPROJECT_URL=http://localhost:8080
set API_KEY=f827f0fe0eb3c0a3bed98464982a53eac9c90b3373d953fa999636125b504dd1
set PROJECT_ID=demo-project

echo ===============================================
echo Testing OpenProject API Connection
echo ===============================================
echo.

echo [TEST 1] Authentication - GET /api/v3/users/me
echo.
curl -u apikey:%API_KEY% -H "Accept: application/json" "%OPENPROJECT_URL%/api/v3/users/me"
echo.
echo.

echo [TEST 2] List Projects - GET /api/v3/projects
echo.
curl -u apikey:%API_KEY% -H "Accept: application/json" "%OPENPROJECT_URL%/api/v3/projects?pageSize=100"
echo.
echo.

echo [TEST 3] List Work Packages - GET /api/v3/projects/%PROJECT_ID%/work_packages
echo.
curl -u apikey:%API_KEY% -H "Accept: application/json" "%OPENPROJECT_URL%/api/v3/projects/%PROJECT_ID%/work_packages?pageSize=100"
echo.
echo.

echo Test Complete
pause
