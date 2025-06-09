namespace ShoppingCartSystem;

public class PhysicalProduct : IProduct
{
  public string Name { get; set; }
  public decimal Price { get; set; }
  public int Stock { get; set; }
  public bool IsPhysical => true;
  public decimal Weight { get; set; }
  public string DownloadUrl { get; set; }

  public void Ship()
  {
    if (Stock <= 0)
    {
      throw new InvalidOperationException("Product out of stock!");
    }

    Console.WriteLine($"Shipping {Name}");
    Stock--;
  }

  public void Download()
  {
    throw new InvalidOperationException("Cannot download physical products!");
  }

  public decimal CalculateShippingCost()
  {
    return Weight * 2.5m;
  }
}
