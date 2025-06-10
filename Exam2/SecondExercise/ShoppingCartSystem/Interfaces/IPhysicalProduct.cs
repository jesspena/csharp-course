using ShoppingCartSystem.Models;

namespace ShoppingCartSystem.Interfaces;

public interface IPhysicalProduct : IProduct
{
    Weight Weight { get; }
    void Ship();
    Price CalculateShippingCost();
}