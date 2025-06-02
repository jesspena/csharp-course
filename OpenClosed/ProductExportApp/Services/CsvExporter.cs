using System.Text;
using ProductExportApp.Interfaces;
using ProductExportApp.Models;

namespace ProductExportApp.Services;

public class CsvExporter : IProductExporter
{
  public FormatType FormatKey => FormatType.Csv;

  public string Export(IEnumerable<Product> products)
  {
    var csv = new StringBuilder();
    csv.AppendLine("Id,Name,Price,Category");

    foreach (var product in products)
    {
      csv.AppendLine($"{product.Id},{product.Name},{product.Price},{product.Category}");
    }

    return csv.ToString();
  }
}