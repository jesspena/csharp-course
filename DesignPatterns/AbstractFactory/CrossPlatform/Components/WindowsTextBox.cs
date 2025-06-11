using CrossPlatform.Interfaces;

namespace CrossPlatform.Components;

// TODO: Complete implement interface
public sealed class WindowsTextBox : ITextBox
{
  private string _text = "";

  public void SetText(string text)
  {
    _text = text;
  }

  public string GetText() => _text;

  public string GetFont() => "Ubuntu Mono";

  public void Render()
  {
    Console.WriteLine($"Rendering Linux TextBox with text: {_text}");
  }
}