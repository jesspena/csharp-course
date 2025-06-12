using ReportGenerationSystem.Interfaces;
using ReportGenerationSystem.Strategies;

namespace ReportGenerationSystem.Factories;

public static class FormatStrategyFactory
{
  // TODO: Implement the missing format (json)
  public static IReportFormatStrategy CreateStrategy(string formatName)
  {
    return formatName.ToUpper() switch
    {
      "HTML" => new HTMLFormatStrategy(),
      "CSV" => new CSVFormatStrategy(),
      _ => throw new ArgumentException($"Unknown format: {formatName}")
    };
  }

  // TODO: Find a cleaner way to do this
  public static List<string> GetAvailableFormats()
  {
    return ["HTML", "CSV", "JSON"];
  }
}