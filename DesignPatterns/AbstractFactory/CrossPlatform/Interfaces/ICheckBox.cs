namespace CrossPlatform.Interfaces;

public interface ICheckBox : IComponent
{
  void Check(bool isChecked);
  bool IsChecked();
  string GetStyle();
}