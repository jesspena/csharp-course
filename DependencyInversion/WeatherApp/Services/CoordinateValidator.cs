namespace WeatherApp.Services;

public static class CoordinateValidator
{
    public static bool ValidateCoordinates(string input, out string lat, out string lon)
    {
        lat = lon = string.Empty;
        var parts = input.Split(',');
        if (parts.Length != 2)
            return false;

        if (double.TryParse(parts[0], out var latVal) && double.TryParse(parts[1], out var lonVal))
        {
            if (latVal >= -90 && latVal <= 90 && lonVal >= -180 && lonVal <= 180)
            {
                lat = parts[0];
                lon = parts[1];
                return true;
            }
        }

        return false;
    }
}
