using ProductExportApp.Interfaces;
using ProductExportApp.Models;

namespace ProductExportApp.Cli;

public class ProductExportCli(IExporterFactory exporterFactory)
{
  private readonly IExporterFactory _exporterFactory = exporterFactory;

  public void Run(string[] args)
  {
    var format = args.FirstOrDefault() ?? "json";
    var products = SampleData();
    // TODO: Implement format type validation
    var output = _exporterFactory.Export(products, Enum.Parse<FormatType>(format, true));
    Console.WriteLine(output);
  }

  private static IEnumerable<Product> SampleData() => new[]
  {
    new Product(1, "Laptop", 7999.99m, "Electronics"),
    new Product(2, "Desk", 4999.99m, "Furniture"),
    new Product(3, "Fork", 2999.99m, "Kitchen"),
  };
}