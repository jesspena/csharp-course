namespace WeatherApp.Models;

public record CurrentDto(
  string time,
  int interval,
  double temperature_2m
);