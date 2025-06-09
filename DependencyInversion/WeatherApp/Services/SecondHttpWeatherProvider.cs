using System.Net.Http.Json;
using WeatherApp.Interfaces;
using WeatherApp.Models;

namespace WeatherApp.Services;

public class SecondHttpWeatherProvider(HttpClient httpClient) : IWeatherProvider
{
  private readonly HttpClient _httpClient = httpClient;

  public async Task<double> GetTodayAsync(string latitude, string longitude)
  {
    // OPTIONAL: Search for a new endpoint to get the weather (refactor scaffolding for models)
    var response = await _httpClient.GetFromJsonAsync<ForecastDto>(
      $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current=temperature_2m,wind_speed_10m&hourly=temperature_2m,relative_humidity_2m,wind_speed_10m");

    return response!.current.temperature_2m;
  }
}