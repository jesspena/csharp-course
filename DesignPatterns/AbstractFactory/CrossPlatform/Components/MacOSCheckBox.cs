using CrossPlatform.Interfaces;

namespace CrossPlatform.Components;

// TODO: Complete implement interface
public sealed class MacOSCheckBox : ICheckBox
{
  private bool _checked;
  public void Check(bool isChecked)
  {
    _checked = isChecked;
  }

  public string GetStyle() => "MacOS+ CheckBox";

  public bool IsChecked() => _checked;

  public void Render()
  {
    Console.WriteLine($"Rendering MacOS CheckBox - Checked: {_checked}");
  }
}