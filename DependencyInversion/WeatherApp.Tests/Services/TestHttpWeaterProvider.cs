using WeatherApp.Interfaces;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Tests.Services;
public class FakeHttpService : IHttpService
{
    public ForecastDto? ForecastToReturn { get; set; }

    public Task<T?> GetFromJsonAsyncCorrect<T>(string url)
    {
        if (typeof(T) == typeof(ForecastDto))
        {
            return Task.FromResult((T?)(object?)ForecastToReturn);
        }

        return Task.FromResult<T?>(default);
    }
}

public class TestHttpWeatherProvider
{
    [Fact]
    public async Task GetTodayAsync_WhenValidResponse()
    {
        var fakeHttp = new FakeHttpService
        {
            ForecastToReturn = new ForecastDto(
                latitude: -16.5,
                longitude: -68.0,
                current: new CurrentDto("10:00", 1, 22.5))
        };

        var provider = new HttpWeatherProvider(fakeHttp);

        var temp = await provider.GetTodayAsync("-16.5", "-68.0");

        Assert.Equal(22.5, temp);
    }

    [Fact]
    public async Task GetTodayAsync_WhenResponseIsNull()
    {
        var fakeHttp = new FakeHttpService
        {
            ForecastToReturn = null
        };

        var provider = new HttpWeatherProvider(fakeHttp);

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            provider.GetTodayAsync("-16.5", "-68.0"));
    }
}