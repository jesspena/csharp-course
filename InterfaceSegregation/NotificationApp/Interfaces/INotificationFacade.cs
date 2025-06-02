using NotificationApp.Models;

namespace NotificationApp.Interfaces;

public interface INotificationFacade
{
  void Notify(OrderEvent orderEvent);
}