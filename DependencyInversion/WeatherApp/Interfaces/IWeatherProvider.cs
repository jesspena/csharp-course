namespace WeatherApp.Interfaces;

public interface IWeatherProvider
{
  Task<double> GetTodayAsync(string latitude, string longitude);
}