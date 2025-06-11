using CrossPlatform.Interfaces;

namespace CrossPlatform.Components;

// TODO: Complete implement interface
public sealed class MacOSTextBox : ITextBox
{
  private string _text = "";
  public string GetFont() => "San Francisco";

  public string GetText() => _text;

  public void Render()
  {
    Console.WriteLine($"Rendering macOS TextBox with this text: {_text}");
  }

  public void SetText(string text)
  {
    _text = text;
  }
}