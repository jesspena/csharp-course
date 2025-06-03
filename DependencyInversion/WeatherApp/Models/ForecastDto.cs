namespace WeatherApp.Models;

public record ForecastDto(
  double latitude,
  double longitude,
  CurrentDto current
);