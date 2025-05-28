namespace PaymentApp.Interfaces;

public interface IRefunder
{
    void Refund(decimal amount, string reference);
}