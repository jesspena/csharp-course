namespace WeatherApp.Interfaces;

public interface IHttpService
{
    Task<T?> GetFromJsonAsyncCorrect<T>(string url);
}