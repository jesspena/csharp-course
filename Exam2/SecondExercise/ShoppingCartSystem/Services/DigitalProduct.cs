using ShoppingCartSystem.Interfaces;
using ShoppingCartSystem.Models;

namespace ShoppingCartSystem.Services;

public class DigitalProduct : IDigitalProduct
{
  public required string Name { get; set; }
  public required Price Price { get; set; }
  public Quantity Stock { get; set; } 
  public required string DownloadUrl { get; set; }

  public void Download()
  {
    Console.WriteLine($"Downloading {Name} from {DownloadUrl}");
  }
}