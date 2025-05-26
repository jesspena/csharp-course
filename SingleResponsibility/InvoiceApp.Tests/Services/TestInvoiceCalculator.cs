using InvoiceApp.Models;
using InvoiceApp.Services;

namespace InvoiceApp.Tests.Services;

public class TestInvoiceCalculator
{
  [Fact]
  public void Calculate_ReturnsZeroes_WhenNoInvoices()
  {
    var calculator = new InvoiceCalculator();
    var (total, average) = calculator.Calculate([]);

    Assert.Equal(0, total);
    Assert.Equal(0, average);
  }

  [Fact]
  public void Calculate_ReturnsTotalAndAverage_WhenInvoicesProvided()
  {
    var calculator = new InvoiceCalculator();
    var invoices = new[]
    {
      new Invoice(1, "A", 100m, new(2025, 5, 1)),
      new Invoice(2, "B", 200m, new(2025, 5, 2)),
      new Invoice(3, "C", 300m, new(2025, 5, 3)),
    };

    var (total, average) = calculator.Calculate(invoices);

    Assert.Equal(600, total);
    Assert.Equal(200, average);
  }

  // TODO: Add negative test cases
}