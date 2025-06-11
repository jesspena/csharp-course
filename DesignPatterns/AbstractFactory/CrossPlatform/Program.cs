using CrossPlatform.Client;
using CrossPlatform.Interfaces;
using CrossPlatform.Services;

namespace CrossPlatform;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Selecciona la platform (windows/macOS/linux):");
        var input = Console.ReadLine()?.ToLowerInvariant();

        IUserInterfaceComponentFactory factory = input switch
        {
            "windows" => new WindowsUserInterfaceFactory(),
            "macos" => new MacOSUserInterfaceFactory(),
            "linux" => new LinuxUserInterfaceFactory(),
            _ => throw new InvalidOperationException("Unsupported platform selected.")
        };

        var app = new UserInterfaceApplication(factory);
        app.CreateLoginForm();
    }
}