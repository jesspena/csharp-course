namespace CrossPlatform.Interfaces;

public interface IUserInterfaceComponentFactory
{
  IButton CreateButton();
  ITextBox CreateTextBox();
  ICheckBox CreateCheckBox();
  string GetPlatformName();
}