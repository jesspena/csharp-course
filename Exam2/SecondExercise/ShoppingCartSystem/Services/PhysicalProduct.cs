using ShoppingCartSystem.Interfaces;
using ShoppingCartSystem.Models;
using ShoppingCartSystem.Constants;

namespace ShoppingCartSystem.Services;

public class PhysicalProduct : IPhysicalProduct
{
  public required string Name { get; set; }
  public required Price Price { get; set; }
  public Quantity Stock { get; set; }
  public Weight Weight { get; set; }

  public void Ship()
  {
    if (Stock <= 0)
    {
      throw new InvalidOperationException("Product out of stock!");
    }

    Console.WriteLine($"Shipping {Name}");
    Stock = new Quantity(Stock.Value - 1);
  }

  public Price CalculateShippingCost()
  {
    return new Price(Weight.Kilograms * CartConfiguration.ShippingRate);
  }
}