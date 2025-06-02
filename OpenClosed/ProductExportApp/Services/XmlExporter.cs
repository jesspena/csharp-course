using System.Text;
using ProductExportApp.Interfaces;
using ProductExportApp.Models;

namespace ProductExportApp.Services;

public class XmlExporter : IProductExporter
{
  public FormatType FormatKey => FormatType.Xml;

  public string Export(IEnumerable<Product> products)
  {
    var csv = new StringBuilder();
    csv.AppendLine("<Products>");

    foreach (var product in products)
    {
      csv.AppendLine($"""
        <Product id="{product.Id}">
          <Name>{product.Name}</Name>
          <Price>{product.Price}</Price>
          <Category>{product.Category}</Category>
        </Product>
      """);
    }

    csv.AppendLine("</Products>");

    return csv.ToString();
  }
}