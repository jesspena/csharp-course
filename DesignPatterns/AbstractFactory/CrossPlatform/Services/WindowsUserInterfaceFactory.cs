using CrossPlatform.Components;
using CrossPlatform.Interfaces;

namespace CrossPlatform.Services;

public class WindowsUserInterfaceFactory : IUserInterfaceComponentFactory
{
  public IButton CreateButton() => new WindowsButton();
  public ICheckBox CreateCheckBox() => new WindowsCheckBox();
  public ITextBox CreateTextBox() => new WindowsTextBox();
  public string GetPlatformName() => "windows";
}