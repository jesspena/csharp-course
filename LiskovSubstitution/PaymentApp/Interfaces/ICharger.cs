namespace PaymentApp.Interfaces;

public interface ICharger
{
    void Charge(decimal amount, string reference);
}