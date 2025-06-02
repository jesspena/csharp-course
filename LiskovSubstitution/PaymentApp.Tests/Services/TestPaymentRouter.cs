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

  [Fact]
  public void TryRefund_ShouldSkip_WhenNotSupported()
  {
    var dummyPayment = new DummyPayment();
    var paymentRouter = new PaymentRouter([dummyPayment], []);

    var result = paymentRouter.TryRefund("dummy", 100, "ref123");

    Assert.False(result);
  }

  // TODO: Implement a positive scenario for refund
}