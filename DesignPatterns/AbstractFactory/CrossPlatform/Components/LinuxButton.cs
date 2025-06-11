using CrossPlatform.Interfaces;

namespace CrossPlatform.Components;

// TODO: Complete implement interface
public sealed class LinuxButton : IButton
{
  private bool _pressed;
  public void Click()
  {
    _pressed = !_pressed;
    Console.WriteLine($"Linux Button clicked - State: {(_pressed ? "Pressed" : "Released")}");
  }

  public string GetTheme()
  {
    return "Linux";
  }

  public void Render()
  {
     Console.WriteLine("Rendering Linux Button using Linux theme");
  }
}