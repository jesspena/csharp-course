namespace ShoppingCartSystem;

public class ShoppingCart
{
  private List<IProduct> items = [];

  public void AddItem(IProduct product, int quantity = 1)
  {
    for (int i = 0; i < quantity; i++)
    {
      items.Add(product);
    }

    Console.WriteLine($"Added {quantity} x {product.Name} to cart");
  }

  public decimal CalculateTotal()
  {
    decimal subtotal = items.Sum(item => item.Price);
    decimal shipping = 0;
    decimal discount = 0;

    foreach (var item in items)
    {
      if (item.IsPhysical)
      {
        shipping += item.CalculateShippingCost();
      }
    }

    if (subtotal > 100)
    {
      discount = subtotal * 0.1m;
    }

    if (items.Count > 5)
    {
      discount += 5;
    }

    return subtotal + shipping - discount;
  }

  public void Checkout()
  {
    Console.WriteLine("\n=== Checkout Process ===");

    var physicalItems = items.Where(p => p.IsPhysical).ToList();
    var digitalItems = items.Where(p => !p.IsPhysical).ToList();

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
    var grouped = items.GroupBy(p => p.Name);

    foreach (var group in grouped)
    {
      var product = group.First();
      var quantity = group.Count();
      Console.WriteLine($"{product.Name} x{quantity} - ${product.Price * quantity:F2}");
    }

    Console.WriteLine($"Total: ${CalculateTotal():F2}");
  }
}
