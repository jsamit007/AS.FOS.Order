# Navigate to the Order.Domain project directory
cd .\AS.FOS.Order.Domain

# Define the list of folders to create
$folders = @(
    "Aggregates",
    "Entities",
    "ValueObjects",
    "Enums",
    "Events",
    "Abstractions"
)

# Create each folder
foreach ($folder in $folders) {
    New-Item -Path $folder -ItemType Directory -Force
}
