using PaymentApp.Interfaces;

namespace PaymentApp.Services;

public class BitcoinPayment : ICharger
{
  public void Charge(decimal amount, string reference)
  {
    Console.WriteLine($"Charged {amount:C} to bitcoin wallet with reference {reference}.");
  }
}