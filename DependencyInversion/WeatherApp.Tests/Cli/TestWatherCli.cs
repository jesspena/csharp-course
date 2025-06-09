using WeatherApp.Interfaces;
using WeatherApp.Cli;

namespace WeatherApp.Tests.Cli;

public class FakeWeatherProvider : IWeatherProvider
{
  public Task<double> GetTodayAsync(string latitude, string longitude)
  {
    return Task.FromResult(15.0);
  }
}

public class TestWeatherCli
{
  // TODO: Find the best way to test the cli
  [Fact]
  public async Task RunAsync_WhenValidCoordinates()
  {
    var fakeProvider = new FakeWeatherProvider();
    var cli = new WeatherCli(fakeProvider);

    using var sw = new StringWriter();
    Console.SetOut(sw);

    await cli.RunAsync(new[] { "-16.5,-68.05" });

    var output = sw.ToString().Trim();
    Assert.Contains("Today weather is: 15", output);
  }

  [Fact]
  public async Task RunAsync_WhenInvalidCoordinates()
  {
    var fakeProvider = new FakeWeatherProvider();
    var cli = new WeatherCli(fakeProvider);

    using var sw = new StringWriter();
    Console.SetOut(sw);

    await cli.RunAsync(new[] { "sin coordenadas" });

    var output = sw.ToString().Trim();
    Assert.Contains("Invalid coordinates", output);
  }
}