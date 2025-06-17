using ReportGenerationSystem.Interfaces;
using ReportGenerationSystem.Factories;
using System.Text.Json;

namespace ReportGenerationSystem.Strategies;

public class JSONFormatStrategy : IReportFormatStrategy
{
  public ReportFormat GetFormatName() => ReportFormat.JSON;

  public string GetFileExtension() => ".html";

  public string FormatReport(List<string> processedData, ReportType reportType)
  {
    Console.WriteLine($"Formatting {reportType} report as JSON...");

    var reportObject = new
        {
            ReportType = reportType.ToString(),
            GeneratedAt = DateTime.UtcNow,
            Items = processedData
        };

    return JsonSerializer.Serialize(reportObject, new JsonSerializerOptions
        {
            WriteIndented = true
        });
  }
}