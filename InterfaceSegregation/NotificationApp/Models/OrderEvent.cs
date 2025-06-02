namespace NotificationApp.Models;

// TODO: Separate notification methods (you can use an array of enums)
public record OrderEvent(
  int OrderId,
  string Customer,
  string Status,
  bool NotifyEmail,
  bool NotifySms,
  bool NotifyPush,
  string CustomerEmail,
  string CustomerPhone,
  string? DeviceToken);