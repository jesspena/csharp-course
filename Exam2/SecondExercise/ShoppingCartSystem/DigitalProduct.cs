namespace ShoppingCartSystem;

public class DigitalProduct : IProduct
{
  public string Name { get; set; }
  public decimal Price { get; set; }
  public int Stock { get; set; } = int.MaxValue;
  public bool IsPhysical => false;
  public decimal Weight { get; set; }
  public string DownloadUrl { get; set; }

  public void Ship()
  {
    throw new InvalidOperationException("Cannot ship digital products!");
  }

  public void Download()
  {
    Console.WriteLine($"Downloading {Name} from {DownloadUrl}");
  }

  public decimal CalculateShippingCost()
  {
    return 0;
  }
}