using System.Net.Http.Json;
using WeatherApp.Interfaces;
using WeatherApp.Models;

namespace WeatherApp.Services;

public class HttpWeatherProvider(HttpClient httpClient) : IWeatherProvider
{
  private readonly HttpClient _httpClient = httpClient;

  // TODO: Create a level of http abstraction for http requests into HttpService with provided url
  public async Task<double> GetTodayAsync(string latitude, string longitude)
  {
    var response = await _httpClient.GetFromJsonAsync<ForecastDto>(
      $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current=temperature_2m,wind_speed_10m&hourly=temperature_2m,relative_humidity_2m,wind_speed_10m");

    // TODO: Apply validators or error handling for response
    return response!.current.temperature_2m;
  }
}