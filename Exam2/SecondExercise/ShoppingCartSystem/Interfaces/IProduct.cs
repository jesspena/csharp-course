using ShoppingCartSystem.Models;

namespace ShoppingCartSystem.Interfaces;

public interface IProduct
{
    string Name { get; set; }
    Price Price { get; set; }
    Quantity Stock { get; set; }
}

//solucionando con Liskov Subtitution e Interface Segragation