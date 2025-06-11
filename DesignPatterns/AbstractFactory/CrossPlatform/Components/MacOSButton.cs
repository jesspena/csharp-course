using CrossPlatform.Interfaces;

namespace CrossPlatform.Components;

// TODO: Complete implement interface
public sealed class MacOSButton : IButton
{
  private bool _pressed;
  public void Click()
  {
    _pressed = !_pressed;
    Console.WriteLine($"MacOs Button clicked - State: {(_pressed ? "Pressed" : "Released")}");
    
  }

  public string GetTheme() => "MacOs";

  public void Render()
  {
    Console.WriteLine("Rendering MacOs Button using MacOs theme");
  }
}