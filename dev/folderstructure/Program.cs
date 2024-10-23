using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the base path for the Clean Architecture structure:");
        string basePath = Console.ReadLine();

        // Define the folder structure
        string[] folders = new string[]
        {
            "Application/Services",
            "Application/UseCases",
            "Application/Interfaces",
            "Domain/Entities",
            "Domain/ValueObjects",
            "Domain/Interfaces",
            "Infrastructure/Data",
            "Infrastructure/ExternalServices",
            "Presentation/Controllers",
            "Presentation/Models",
            "Tests/ApplicationTests",
            "Tests/DomainTests",
            "Tests/InfrastructureTests"
        };

        // Create the directories
        foreach (var folder in folders)
        {
            string fullPath = Path.Combine(basePath, folder);
            Directory.CreateDirectory(fullPath);
            Console.WriteLine($"Created: {fullPath}");
        }

        // Create .csproj files
        string[] csprojFiles = new string[]
        {
            "Application/Application.csproj",
            "Domain/Domain.csproj",
            "Infrastructure/Infrastructure.csproj",
            "Presentation/Presentation.csproj",
            "Tests/Tests.csproj"
        };

        foreach (var csproj in csprojFiles)
        {
            string fullPath = Path.Combine(basePath, csproj);
            File.Create(fullPath).Close();
            Console.WriteLine($"Created: {fullPath}");
        }

        Console.WriteLine("Clean Architecture folder structure created successfully.");
    }
}
