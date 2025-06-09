using Microsoft.Extensions.DependencyInjection;
using WeatherApp.Cli;
using WeatherApp.Interfaces;
using WeatherApp.Services;

namespace WeatherApp.Extensions;

public static class ServiceExtensions
{
  public static IServiceCollection AddCliServices(this IServiceCollection services, string useDefault = "true")
  {
    services.AddSingleton<HttpClient>();
    services.AddSingleton<HttpService>();
    services.AddWeatherProviders(useDefault);
    services.AddSingleton<WeatherCli>();

    return services;
  }

  private static IServiceCollection AddWeatherProviders(this IServiceCollection services, string useDefault)
  {
    if (useDefault == "true")
    {
      services.AddSingleton<IHttpService, HttpService>();
      services.AddSingleton<IWeatherProvider, HttpWeatherProvider>();
    }
    else
    {
      services.AddSingleton<IHttpService, HttpService>();
      services.AddSingleton<IWeatherProvider, SecondHttpWeatherProvider>();
    }

    return services;
  }
}