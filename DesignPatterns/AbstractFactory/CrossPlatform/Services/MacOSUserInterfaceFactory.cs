using CrossPlatform.Components;
using CrossPlatform.Interfaces;

namespace CrossPlatform.Services;

public class MacOSUserInterfaceFactory : IUserInterfaceComponentFactory
{
  public IButton CreateButton() => new MacOSButton();
  public ICheckBox CreateCheckBox() => new MacOSCheckBox();
  public ITextBox CreateTextBox() => new MacOSTextBox();
  public string GetPlatformName() => "macOS";
}