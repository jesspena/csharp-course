namespace ShoppingCartSystem;

public interface IProduct
{
    string Name { get; set; }
    decimal Price { get; set; }
    int Stock { get; set; }
    bool IsPhysical { get; }
    decimal Weight { get; set; }
    string DownloadUrl { get; set; }
    void Ship();
    void Download();
    decimal CalculateShippingCost();
}