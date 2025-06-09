# Dependency Inversion (DIP)

## Definition

High-level modules must not depend on low-level modules; both should depend on abstractions. Abstractions must not depend on details. Details depend on abstraction therefore, in C# we are talking about interfaces.

## Example

We want a CLI tool that prints today's temperature for a city. The first pass wires the high-level CLI directly to an HTTP-fetching service.

## Solution (bad)

```csharp
namespace WeatherApp;

public class WeatherReporter
{
  private readonly HttpClient _http = new();

  public async Task<double> GetTodayAsync(string coordinates)
  {
    var latitude = coordinates.Split(',')[0];
    var longitude = coordinates.Split(',')[1];
    var url = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current=temperature_2m,wind_speed_10m&hourly=temperature_2m,relative_humidity_2m,wind_speed_10m";
    var response = await _http.GetFromJsonAsync<ForecasDto>(url);

    return response!.current.temperature_2m;
  }
}
```

Problems:

- Unit testing would be difficult because we might need to mock a complex API.
- If we change the API, we must modify the Reporter
- High-level policy (what to do with the api) is coupled to low-level detail (how to fetch the json)

## Solution (enhanced)

Define an abstraction `IWeatherProvider`. The CLI Logic depends only on that interface. Concrete providers `HttpWeatherProvider`. And all via Depedency Injection.


## Difference between Dependency Injection and Dependency Inversion

> Note: To apply Dependency Inversion applying Depedency Injection is not a must.

- Dependency Injection: It is a techinique, it is a way, it is a pattern of using interfaces to apply any concrete classes
- Dependency Inversion: It is a design principle...
