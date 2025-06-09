using System.Text.Json;
using PaymentApp.Interfaces;
using PaymentApp.Models;

namespace PaymentApp.Cli;

public class PaymentCli(IPaymentRouter paymentRouter, IOrderProvider orderProvider, IUserNotifier notifier)
{
  private readonly IPaymentRouter _paymentRouter = paymentRouter;
  private readonly IOrderProvider _orderProvider = orderProvider;
  private readonly IUserNotifier _notifier = notifier;

  public void Run(string[] args)
  {
    var orders = _orderProvider.GetOrders(args);

    foreach (var order in orders)
    {
      _paymentRouter.Charge(order.Method, order.Amount, order.Reference);
    }

    if (orders.Count() >= 2)
    {
        _notifier.Notify("\n--- Cancel & refund second order ---");

        var cancelledOrder = orders.ElementAt(1);
        var refunded = _paymentRouter.TryRefund(cancelledOrder.Method, cancelledOrder.Amount, cancelledOrder.Reference);

        if (refunded)
        {
            _notifier.ShowRefundSuccess(cancelledOrder.Reference);
        }
    }
    else
    {
        _notifier.Notify("Not enough orders to cancel the second one.");
    }
  }

  // TODO: Delete this method and add validations
}