namespace NotificationApp.Interfaces;

public interface ISmsSender
{
  void SendSms(string to, string text);
}
