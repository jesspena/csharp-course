# Single Responsibility Principle (SRP)

## Definition

A class, module, function, method should have one and only one reason to change, this means it must be responsible for one thing only.

## Scenario

We are going to have a CLI tool (Command line interface) that will receive a list of customers invoices (JSON string) or (inline data) and prints out a report with totals & averages.

### Example (problem)

One change in any of the five concerns below will make us edit the same class and may increase the complexity of the class.

```csharp
// InvoiceProcessor.cs
using System.Text.Json;
using InvoiceApp.Models;

namespace InvoiceApp;

public class InvoiceProcessor
{
  public void Run(string[] args)
  {
    // 1. Parse arguments
    if (args.Length == 0)
    {
      throw new ArgumentException("Expecting JSON invoices!");
    }

    // 2. Deserialize invoices
    var invoices = JsonSerializer.Deserialize<List<Invoice>>(args[0])!;

    // 3. Calculate totals and averages
    var total = invoices.Sum(i => i.Amount);
    var average = invoices.Average(i => i.Amount);

    // 4. Format an ASCII table
    var report = $"""
      Invoices: {invoices.Count}
      Total: {total:C}
      Average: {average:C}
      """;

    // 5. Output to console
    Console.WriteLine(report);
  }
}
```

### Example (solution)

We split the responsibilities into distinct classes, methods, entities, and wire them together with different approaches. And we are going to use Dependency Injection (DI).

## Project Creation

You can use the following commands in powershell windows.
```bash
# 1. Solution & projects
mkdir SingleResponsibility && cd SingleResponsibility

dotnet new sln -n SingleResponsibility

dotnet new console -n InvoiceApp

dotnet new xunit   -n InvoiceApp.Tests

# 2. Add projects to the solution

dotnet sln add InvoiceApp/InvoiceApp.csproj

dotnet sln add InvoiceApp.Tests/InvoiceApp.Tests.csproj

# 3. Test project references main project

dotnet add InvoiceApp.Tests reference InvoiceApp

# 4. Install dependencies
dotnet add InvoiceApp package Microsoft.Extensions.Hosting
dotnet add InvoiceApp package Microsoft.Extensions.DependencyInjection

# 5. Run the app (uses inline sample data)

dotnet run --project InvoiceApp

# 6. Run tests

dotnet test
```