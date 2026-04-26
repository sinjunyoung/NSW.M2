@echo off
cd /d %~dp0NSW.M2.Avalonia.Android
echo Cleaning...
dotnet clean -c Release
echo Publishing...
dotnet publish -c Release -f net8.0-android
cd bin\Release\net8.0-android\
echo Done!
explorer .
pause