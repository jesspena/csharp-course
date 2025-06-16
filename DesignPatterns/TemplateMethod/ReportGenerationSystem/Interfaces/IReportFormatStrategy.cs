namespace ReportGenerationSystem.Interfaces;

public interface IReportFormatStrategy
{
  // TODO: Change to enum
  string GetFormatName();
  string FormatReport(List<string> processedData, string reporType);
  string GetFileExtension();
}