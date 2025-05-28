using System.Text.Json;
using PaymentApp.Interfaces;
using PaymentApp.Models;

namespace PaymentApp.Cli;

public class PaymentCli(IPaymentRouter paymentRouter)
{
  private readonly IPaymentRouter _paymentRouter = paymentRouter;

  public void Run(string[] args)
  {
    // TODO: Implement validation for input arguments
    var json = args.Length > 0 ? args[0] : SampleData();
    var orders = JsonSerializer.Deserialize<List<Order>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;

    foreach (var order in orders)
    {
      _paymentRouter.Charge(order.Method, order.Amount, order.Reference);
    }

    Console.WriteLine("\n--- Cancel & refund second order ---");

    var cancelledOrder = orders[1];
    _paymentRouter.TryRefund(cancelledOrder.Method, cancelledOrder.Amount, cancelledOrder.Reference);
  }

  // TODO: Delete this method and add validations
  public static string SampleData()
  {
    return """
    [
      {
        "id": "A1",
        "method": "bitcoin",
        "amount": 100.00,
        "reference": "TX1234567890"
      },
      {
        "id": "B2",
        "method": "creditcard",
        "amount": 50.00,
        "reference": "CC1234567890"
      },
      {
        "id": "C3",
        "method": "paypal",
        "amount": 75.00,
        "reference": "PP1234567890"
      }
    ]
    """;
  }
}