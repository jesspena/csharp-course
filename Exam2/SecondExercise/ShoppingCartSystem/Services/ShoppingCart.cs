using ShoppingCartSystem.Interfaces;
using ShoppingCartSystem.Constants;
using ShoppingCartSystem.Models;

namespace ShoppingCartSystem.Services;

public class ShoppingCart
{
  private readonly List<IProduct> _items = new();

  public void AddItem(IProduct product, Quantity quantity)
  {
    for (int i = 0; i < quantity.Value; i++)
    {
      _items.Add(product);
    }
    Console.WriteLine($"Added {quantity.Value} x {product.Name} to cart");
  }

  public decimal CalculateTotal()
  {
    var subtotal = _items.Sum(p => p.Price.Amount);
    var shipping = _items.OfType<IPhysicalProduct>().Sum(p => p.CalculateShippingCost().Amount);

    decimal discount = 0;

    if (subtotal > CartConfiguration.DiscountThreshold)
    {
      discount += subtotal * CartConfiguration.DiscountPercentage;
    }

    if (_items.Count > CartConfiguration.ExtraDiscountQuantity)
    {
      discount += CartConfiguration.ExtraDiscount;
    }

    return subtotal + shipping - discount;
  }

  public void Checkout()
  {
    Console.WriteLine("\n=== Checkout Process ===");

    var physicalItems = _items.OfType<IPhysicalProduct>();
    var digitalItems = _items.OfType<IDigitalProduct>();

    Console.WriteLine("Physical Items:");
    foreach (var item in physicalItems)
    {
      try
      {
        item.Ship();
        Console.WriteLine($"- {item.Name}: Shipped (Weight: {item.Weight})");
      }
      catch (Exception ex)
      {
          Console.WriteLine($"- {item.Name}: Shipping failed - {ex.Message}");
      }
    }

    Console.WriteLine("\nDigital Items:");
    foreach (var item in digitalItems)
    {
      try
        {
            item.Download();
            Console.WriteLine($"- {item.Name}: Downloaded");
        }
      catch (Exception ex)
      {
          Console.WriteLine($"- {item.Name}: Download failed - {ex.Message}");
      }
    }

    Console.WriteLine($"\nTotal Amount: ${CalculateTotal():F2}");
    Console.WriteLine("Payment processed successfully!");
    Console.WriteLine("Order confirmation sent to customer email.");
  }

  public void DisplayCart()
  {
    Console.WriteLine("\n=== Shopping Cart ===");
    var grouped = _items.GroupBy(i => i.Name);

    foreach (var group in grouped)
    {
      var product = group.First();
      var count = group.Count();
      Console.WriteLine($"{product.Name} x{count} - ${(product.Price.Amount * count):F2}");
    }

    Console.WriteLine($"Total: ${CalculateTotal():F2}");
  } 
}