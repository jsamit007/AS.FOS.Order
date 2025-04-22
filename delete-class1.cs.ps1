# Clean-Defaults.ps1
$filesToDelete = @(
    "Class1.cs",
    "UnitTest1.cs",
    "WeatherForecast.cs",
    "WeatherForecastController.cs"
)

foreach ($file in $filesToDelete) {
    Get-ChildItem -Path . -Recurse -Filter $file | ForEach-Object {
        Write-Host "Deleting: $($_.FullName)"
        Remove-Item $_.FullName -Force
    }
}
