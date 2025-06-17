using ReportGenerationSystem.Services;
using ReportGenerationSystem.Factories;

Console.WriteLine("Enter report format (HTML, CSV, JSON):");
string inputFormat = Console.ReadLine() ?? "HTML";

if (!Enum.TryParse<ReportFormat>(inputFormat, true, out var reportFormat))
{
    Console.WriteLine($"❌ Invalid format: {inputFormat}");
    return;
}

var reportService = new ReportService();
reportService.GenerateAllReports();
reportService.GenerateAllReportsInFormat(reportFormat);
