using PaymentApp.Interfaces;

namespace PaymentApp.Services;

public class PayPalPayment : ICharger, IRefunder
{
  public void Charge(decimal amount, string reference)
  {
    Console.WriteLine($"Charged {amount:C} to PayPal account with reference {reference}.");
  }

  public void Refund(decimal amount, string reference)
  {
    Console.WriteLine($"Refunded {amount:C} to PayPal account with reference {reference}.");
  }
}