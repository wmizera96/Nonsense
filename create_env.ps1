# Define the output file name
$envFile = ".env"

# Prompt the user for the connection string
$connectionString = Read-Host "Enter the database connection string (or press Enter to use a default value)"
if (-not $connectionString) {
    $connectionString = "Server=localhost,1433;Database=Nonsense;User Id=sa;Password=YourStrongPassword!;"
}

# Define key-value pairs for the .env file
$envEntries = @(
    "Database__ConnectionString=$connectionString"
    "Database__Strategy=Container"
)

# Write the content to the .env file
Set-Content -Path $envFile -Value $envEntries

# Inform the user
Write-Host "Generated .env file" -ForegroundColor Green
$envEntries | ForEach-Object { Write-Host $_ -ForegroundColor Yellow }