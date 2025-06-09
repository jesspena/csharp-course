namespace CrossPlatform.Interfaces;

public interface ITextBox : IComponent
{
  void SetText(string text);
  string GetText();
  string GetFont();
}