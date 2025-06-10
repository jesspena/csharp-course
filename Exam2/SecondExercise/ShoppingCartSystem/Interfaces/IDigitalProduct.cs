namespace ShoppingCartSystem.Interfaces;

public interface IDigitalProduct : IProduct
{
    string DownloadUrl { get; }
    void Download();
}
