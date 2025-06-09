using System.Net.Http.Json;
using WeatherApp.Interfaces;
using WeatherApp.Models;

namespace WeatherApp.Services;

public class SecondHttpWeatherProvider(IHttpService httpService) : IWeatherProvider
{
  private readonly IHttpService _httpService = httpService;

  public async Task<double> GetTodayAsync(string latitude, string longitude)
  {
    // OPTIONAL: Search for a new endpoint to get the weather (refactor scaffolding for models)
    var url = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current=temperature_2m,wind_speed_10m&hourly=temperature_2m,relative_humidity_2m,wind_speed_10m";

    var response = await _httpService.GetFromJsonAsyncCorrect<ForecastDto>(url);

    if (response == null || response.current == null)
    {
      throw new InvalidOperationException("No weather data available.");
    }
    // TODO: Apply validators or error handling for response
    return response.current.temperature_2m;
  }
}