using System.Text.Json;
using ProductExportApp.Interfaces;
using ProductExportApp.Models;

namespace ProductExportApp.Services;

public class JsonExporter : IProductExporter
{
  public FormatType FormatKey => FormatType.Json;

  public string Export(IEnumerable<Product> products)
  {
    return JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });
  }
}