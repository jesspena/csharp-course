using ShoppingCartSystem.Constants;
using ShoppingCartSystem.Services;
using ShoppingCartSystem.Models;
using ShoppingCartSystem;

namespace ShoppingCartSystem;

public class Program
{
  static void Main()
  {
    var cart = new ShoppingCart();

    var laptop = new PhysicalProduct
    {
      Name = "Gaming Laptop",
      Price = new Price(1200),
      Stock = new Quantity(5),
      Weight = new Weight(2.5m)
    };

    var ebook = new DigitalProduct
    {
      Name = "Programming Guide",
      Price = new Price(29.99m),
      DownloadUrl = "http://example.com/download/book.pdf"
    };

    var mouse = new PhysicalProduct
    {
      Name = "Wireless Mouse",
      Price = new Price(25),
      Stock = new Quantity(10),
      Weight = new Weight(0.2m)
    };

    cart.AddItem(laptop, new Quantity(1));
    cart.AddItem(ebook, new Quantity(1));
    cart.AddItem(mouse, new Quantity(2));

    cart.DisplayCart();
    cart.Checkout();
  }
}