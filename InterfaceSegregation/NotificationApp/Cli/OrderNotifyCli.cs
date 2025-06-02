using System.Collections;
using System.Text.Json;
using NotificationApp.Interfaces;
using NotificationApp.Models;

namespace NotificationApp.Cli;

public class OrderNotifyCli(INotificationFacade notifier)
{
  private readonly INotificationFacade _notifier = notifier;

  public void Run(string[] args)
  {
    var json = args.Length > 0 ? args[0] : SampleJson();
    var events = JsonSerializer.Deserialize<List<OrderEvent>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;

    foreach (var ev in events)
    {
      _notifier.Notify(ev);
    }
  }

  public static string SampleJson()
  {
    return """
    [
      {
        "orderId": 1,
        "customer": "Carlos",
        "status": "Shipped",
        "notifyEmail": true,
        "notifySms": false,
        "notifyPush": true,
        "customerEmail": "carlos@jalasoft.com",
        "customerPhone": "-59178945612",
        "deviceToken": "abc"
      },
      {
        "orderId": 1,
        "customer": "Jessica",
        "status": "Received",
        "notifyEmail": false,
        "notifySms": true,
        "notifyPush": false,
        "customerEmail": "jessica@jalasoft.com",
        "customerPhone": "+59178565612",
        "deviceToken": null
      }
    ]
    """;
  }
}