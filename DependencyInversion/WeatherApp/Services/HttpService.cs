using System.Net.Http.Json;
using WeatherApp.Interfaces;

namespace WeatherApp.Services;

public class HttpService(HttpClient httpClient) : IHttpService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<T?> GetFromJsonAsyncCorrect<T>(string url)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<T>(url);
        }
        catch
        {
            Console.WriteLine($"Error data");
            return default;
        }
    }
}
