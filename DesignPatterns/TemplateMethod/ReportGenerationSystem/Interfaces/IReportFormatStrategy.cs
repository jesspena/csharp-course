using ReportGenerationSystem.Factories;

namespace ReportGenerationSystem.Interfaces;

public interface IReportFormatStrategy
{
  // TODO: Change to enum
  ReportFormat GetFormatName();
  string FormatReport(List<string> processedData, ReportType reporType);
  string GetFileExtension();
}