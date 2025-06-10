namespace ShoppingCartSystem.Models;

public readonly record struct Weight(decimal Kilograms)
{
    public static Weight operator *(Weight w, decimal multiplier) => new(w.Kilograms * multiplier);
    public override string ToString() => Kilograms.ToString("F2") + " kg";
}