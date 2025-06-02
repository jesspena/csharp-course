# Liskov Substitution Principle (LSP)

A subtype must be fully substitutable for its base type without altering the correctness of the program. Relying on the base abstraction should work without surprise when handed any subtype, no raised exceptions, no weakened guarantees, no unexpected behavior.

## Scenario

We have a CLI tool that charges customers and issues refunds when orderes are cancelled.

## Example (problem)

```csharp
public interface IPaymentProcessor
{
  void Charge(decimal amount, string reference);
  void Refund(decimal amount, string reference);
}
```

Concrete classes:

```csharp
public class CreditCardProcessor : IPaymentProcessor
{
  public void Charge(decimal amount, string reference)
  {
    Console.WriteLine($"Charging {amount:C} with reference {reference} using PaymentCardProcessor.");
  }

  public void Refund(decimal amount, string reference)
  {
    Console.WriteLine($"Refunding {amount:C} with reference {reference} using PaymentCardProcessor.");
  }
}

public class BitcoinProcessor : IPaymentProcessor
{
  public void Charge(decimal amount, string reference)
  {
    Console.WriteLine($"Charging {amount:C} with reference {reference} using PaymentCardProcessor.");
  }

  public void Refund(decimal amount, string reference)
  {
    throw new NotSupportedException("Bitcoin is irreversible.");
  }
}
```

High-level policy code expects every processor to refund. `BitcoinProcessor` cannot be substituted for the abstraction because it breaks callers, violating LSP.

## Example (solution)

Now any `ICharger` (including `BitcoinPayment`) can replace another in charging context; refund logic depends only on `IRefunder`, so susbtituability holds and we don't crash the program.
Saitisfies LSP.
