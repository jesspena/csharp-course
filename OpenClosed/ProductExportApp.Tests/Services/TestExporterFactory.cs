using ProductExportApp.Interfaces;
using ProductExportApp.Models;
using ProductExportApp.Services;

namespace ProductExportApp.Tests.Services;

public class TestExporterFactory
{
    // TODO: Test that we can add exporters in our simplified factory
    [Fact]
    public void Export_UsesCorrectExporter()
    {
        var exporters = new IProductExporter[]
        {
            new JsonExporter(),
            new XmlExporter()
        };

        var factory = new ExporterFactory(exporters);
        var products = new[] { new Product(1, "Test", 1, "X") };

        var result = factory.Export(products, FormatType.Xml);

        Assert.StartsWith("<Products>", result);
    }
}
