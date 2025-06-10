namespace ShoppingCartSystem.Models;

public readonly record struct Quantity(int Value)
{
    public static implicit operator int(Quantity q) => q.Value;
    public override string ToString() => Value.ToString();
}
