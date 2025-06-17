using ReportGenerationSystem.Interfaces;
using ReportGenerationSystem.Strategies;
using ReportGenerationSystem.Factories;

namespace ReportGenerationSystem.Factories;

public static class FormatStrategyFactory
{
  // TODO: Implement the missing format (json)
  public static IReportFormatStrategy CreateStrategy(ReportFormat formatName)
  {
    return formatName switch
        {
            ReportFormat.HTML => new HTMLFormatStrategy(),
            ReportFormat.CSV  => new CSVFormatStrategy(),
            ReportFormat.JSON => new JSONFormatStrategy(),
            _ => throw new ArgumentOutOfRangeException(nameof(formatName), $"Unsupported format: {formatName}")
        };
  }

  // TODO: Find a cleaner way to do this
  public static List<string> GetAvailableFormats()
  {
    return Enum.GetNames(typeof(ReportFormat)).ToList();
  }
}