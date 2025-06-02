using ProductExportApp.Interfaces;
using ProductExportApp.Models;

namespace ProductExportApp.Services;

/// <summary>
/// This is a simplified factory example
/// </summary>
/// <param name="exporters"></param>
public class ExporterFactory(IEnumerable<IProductExporter> exporters) : IExporterFactory
{
  private readonly Dictionary<FormatType, IProductExporter> _exporters = exporters.ToDictionary(e => e.FormatKey);

  // This is also a valid example of Open/Closed Principle.
  // private readonly Dictionary<FormatType, IProductExporter> _exporters = new()
  // {
  //   { FormatType.Json, exporters.OfType<JsonProductExporter>().FirstOrDefault() },
  //   { FormatType.Xml, exporters.OfType<XmlProductExporter>().FirstOrDefault() },
  //   { FormatType.Csv, exporters.OfType<CsvProductExporter>().FirstOrDefault() }
  // };

  public string Export(IEnumerable<Product> products, FormatType formatType)
  {
    if (!_exporters.TryGetValue(formatType, out var exporter))
    {
      throw new NotSupportedException($"Export format '{formatType}' is not supported.");
    }

    return exporter.Export(products);
  }
}