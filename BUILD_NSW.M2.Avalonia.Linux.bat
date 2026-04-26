@echo off
cd /d %~dp0NSW.M2.Avalonia.Desktop
echo Building Linux...
dotnet publish NSW.M2.Avalonia.Desktop.csproj -c Release -r linux-x64 --self-contained true -p:PublishSingleFile=true -p:PublishTrimmed=true -p:IncludeNativeLibrariesForSelfExtract=true -p:EnableCompressionInSingleFile=true -o bin
echo Done!
explorer bin
pause