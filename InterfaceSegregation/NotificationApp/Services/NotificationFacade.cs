using NotificationApp.Interfaces;
using NotificationApp.Models;

namespace NotificationApp.Services;

// NOTE: This can be MobileNotiicationFacade depends on the context
public class NotificationFacade(IEmailSender email, ISmsSender sms, IPushSender push) : INotificationFacade
{
  private readonly IEmailSender _emailSender = email;
  private readonly ISmsSender _smsSender = sms;
  private readonly IPushSender _pushSender = push;

  // OPTIONAL: Create a high interface INotification for all notification types (BTW, the notifacion types might empty)
  public void Notify(OrderEvent orderEvent)
  {
    var subject = $"Order #{orderEvent.OrderId} status: {orderEvent.Status}";
    var body = $"Hi {orderEvent.Customer}, your order is now {orderEvent.Status}";

    // TODO: Enhance this calls
    if (orderEvent.NotifyEmail)
    {
      _emailSender.SendEmail(orderEvent.CustomerEmail, subject, body);
    }

    if (orderEvent.NotifySms)
    {
      _smsSender.SendSms(orderEvent.CustomerPhone, body);
    }

    if (orderEvent.NotifyPush)
    {
      _pushSender.SendPush(orderEvent.DeviceToken!, "Order Update", body);
    }
  }
}