using CrossPlatform.Interfaces;

namespace CrossPlatform.Components;

// TODO: Complete implement interface
public sealed class LinuxTextBox : ITextBox
{
  private string _text = "";
  public string GetFont() => "Ubuntu Mono";

  public string GetText() => _text;

  public void Render()
  {
    Console.WriteLine($"Rendering Linux TextBox with this text: {_text}");
  }

  public void SetText(string text)
  {
    _text = text;
  }
}