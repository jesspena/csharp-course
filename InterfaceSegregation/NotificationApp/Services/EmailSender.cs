using NotificationApp.Interfaces;

namespace NotificationApp.Services;

public sealed class EmailSender : IEmailSender
{
  public void SendEmail(string to, string subject, string body)
  {
    Console.WriteLine($"Sending Email to {to}: {subject} -> {body}");
  }
}