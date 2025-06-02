using ProductExportApp.Models;

namespace ProductExportApp.Interfaces;

public interface IExporterFactory
{
  string Export(IEnumerable<Product> products, FormatType formatType);
}