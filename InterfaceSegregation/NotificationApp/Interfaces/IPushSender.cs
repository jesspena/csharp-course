namespace NotificationApp.Interfaces;

public interface IPushSender
{
  void SendPush(string deviceToken, string title, string message);
}
