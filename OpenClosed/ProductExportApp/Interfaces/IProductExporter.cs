using ProductExportApp.Models;

namespace ProductExportApp.Interfaces;

public interface IProductExporter
{
  FormatType FormatKey { get; }
  string Export(IEnumerable<Product> products);
}