using NotificationApp.Interfaces;

namespace NotificationApp.Services;

public sealed class SmsSender : ISmsSender
{
  public void SendSms(string to, string text)
  {
    Console.WriteLine($"Sending SMS to {to}: {text}");
  }
}