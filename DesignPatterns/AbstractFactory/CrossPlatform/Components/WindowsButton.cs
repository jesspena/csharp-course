using CrossPlatform.Interfaces;

namespace CrossPlatform.Components;

public sealed class WindowsButton : IButton
{
  private bool _isPressed = false;

  public void Click()
  {
    _isPressed = !_isPressed;
    Console.WriteLine($"Windows Button clicked - State: {(_isPressed ? "Pressed" : "Released")}");
  }

  public void Render()
  {
    Console.WriteLine("Rendering Windows Button with Aero glass effect");
  }

  public string GetTheme() => "Windows Aero";
}