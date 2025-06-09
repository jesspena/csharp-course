namespace CrossPlatform.Interfaces;

public interface IButton : IComponent
{
  void Click();
  string GetTheme();
  // string Text { get; set; }
}