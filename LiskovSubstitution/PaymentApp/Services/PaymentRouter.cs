using PaymentApp.Interfaces;

namespace PaymentApp.Services;

public class PaymentRouter(IEnumerable<ICharger> chargers, IEnumerable<IRefunder> refunders,
        IUserNotifier notifier) : IPaymentRouter
{
  private readonly Dictionary<string, ICharger> _chargers = chargers.ToDictionary(c => c.GetType().Name[..^7].ToLower());
  private readonly Dictionary<string, IRefunder> _refunders = refunders.ToDictionary(r => r.GetType().Name[..^7].ToLower());
  private readonly IUserNotifier _notifier = notifier;

  public void Charge(string method, decimal amount, string reference)
  {
    _chargers[method].Charge(amount, reference);
  }

  // TODO: Enhance this method apply simple Single Responsibility Principle
  public bool TryRefund(string method, decimal amount, string reference)
  {
    if (_refunders.TryGetValue(method, out var refunder))
        {
            refunder!.Refund(amount, reference);
            return true;
        }

        _notifier.ShowRefundNotSupported(method);
        return false;
  }
}