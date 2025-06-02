namespace PaymentApp.Interfaces;

public interface IPaymentRouter
{
    void Charge(string method, decimal amount, string reference);
    bool TryRefund(string method, decimal amount, string reference);
}