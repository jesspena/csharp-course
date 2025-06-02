# Open/Closed Principle (OCP)

## Definition

Software entities, classes, modules, functions, etc. **should be open for extension but closed for modification**. This means that you can add new behavior but cannot alter existing, tested code.
When we use the open/closed principle, we can add new functionality without changing the existing code.

## Scenario

A CLI that converts an in-memory product catalog into different export formats (JSON, CSV, XML, etc.). The first implementation will centralize all formats.

## Example (problem)

Every time that someone asks for new file type like: YAML, PDF. We must edit this class, risking regressions.

```csharp
using System.Text.Json;
using ProductExportApp.Models;

namespace ProductExportApp;

public class Exporter
{
  public string Export(IEnumerable<Product> products, FormatType format)
  {
    return format switch
    {
      FormatType.Json => ToJson(products),
      FormatType.Xml => ToXml(products),
      FormatType.Csv => ToCsv(products),
      _ => throw new NotSupportedException($"Format {format} is not supported.")
    };
  }

  private string ToJson(IEnumerable<Product> products)
  {
    return JsonSerializer.Serialize(products);
  }

  private string ToXml(IEnumerable<Product> products)
  {
    throw new NotImplementedException("XML serialization is not implemented yet.");
  }

  private string ToCsv(IEnumerable<Product> products)
  {
    throw new NotImplementedException("CSV serialization is not implemented yet.");
  }
}
```

## Example (solution)

With the solution the core application classes stay closed to change, yet we can extend with new exporters risk free.

