using System.Text.Json;
using PaymentApp.Interfaces;
using PaymentApp.Models;

namespace PaymentApp.Services;

public class SampleOrderProvider : IOrderProvider
{
    public IEnumerable<Order> GetOrders(string[] args)
    {
        var json = SampleData();

        return JsonSerializer.Deserialize<List<Order>>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }

    private static string SampleData() => """
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
