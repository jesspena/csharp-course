using NotificationApp.Interfaces;

namespace NotificationApp.Services;

public sealed class PushSender : IPushSender
{
  public void SendPush(string deviceToken, string title, string message)
  {
    Console.WriteLine($"Sending Push Notification to {deviceToken}: {title} - {message}");
  }
}