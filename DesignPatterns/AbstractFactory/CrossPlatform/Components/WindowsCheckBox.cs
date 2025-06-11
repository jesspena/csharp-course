using CrossPlatform.Interfaces;

namespace CrossPlatform.Components;

// TODO: Complete implement interface
public sealed class WindowsCheckBox : ICheckBox
{
  private bool _checked;
  public void Check(bool isChecked)
  {
    _checked = isChecked;
  }

  public bool IsChecked() => _checked;

  public string GetStyle() => "Windows CheckBox";

  public void Render()
  {
    Console.WriteLine($"Rendering Windows CheckBox - Checked: {_checked}");
  }
}