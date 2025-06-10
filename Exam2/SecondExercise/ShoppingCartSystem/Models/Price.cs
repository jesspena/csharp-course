namespace ShoppingCartSystem.Models;

public readonly record struct Price(decimal Amount)
{
    public override string ToString() => Amount.ToString("F2");
    public static Price operator +(Price a, Price b) => new(a.Amount + b.Amount);
    public static Price operator -(Price a, Price b) => new(a.Amount - b.Amount);
    public static Price operator *(Price a, decimal multiplier) => new(a.Amount * multiplier);
    public static bool operator >(Price a, Price b) => a.Amount > b.Amount;
    public static bool operator <(Price a, Price b) => a.Amount < b.Amount;
    public static implicit operator decimal(Price p) => p.Amount;
}