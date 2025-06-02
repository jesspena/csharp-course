using PaymentApp.Interfaces;
using PaymentApp.Services;

namespace PaymentApp.Tests.Services;

public class TestPaymentRouter
{
  public class DummyPayment : ICharger
  {
    public bool Charged { get; private set; }

    public void Charge(decimal amount, string reference)
    {
      Charged = true;
    }
  }

  public class DummyRefunder : IRefunder
  { 
    public bool Refunded { get; private set; }

    public void Refund(decimal amount, string reference)
    {
        Refunded = true;
    }
  }

  public class UserNotifier : IUserNotifier
  {
      public void Notify(string message) => Console.WriteLine(message);
      public void ShowRefundNotSupported(string method) => Console.WriteLine($"Refund not supported for method {method}.");
      public void ShowRefundSuccess(string reference) => Console.WriteLine($"Refund processed for {reference}.");
  }


  [Fact]
  public void TryRefund_ShouldSkip_WhenNotSupported()
  {
    var dummyPayment = new DummyPayment();
    var notifier = new UserNotifier();
    var paymentRouter = new PaymentRouter([dummyPayment], [], notifier);

    var result = paymentRouter.TryRefund("dummy", 100, "ref123");

    Assert.False(result);
  }

  // TODO: Implement a positive scenario for refund
  [Fact]
    public void TryRefund_ShouldSucceed_WhenSupported()
    {
        var dummyRefunder = new DummyRefunder();
        var notifier = new UserNotifier();
        var paymentRouter = new PaymentRouter([], [dummyRefunder], notifier);

        var result = paymentRouter.TryRefund("dummy", 50, "ref456");

        Assert.True(result);
    }
}