using CrossPlatform.Interfaces;

namespace CrossPlatform.Components;

// TODO: Complete implement interface
public sealed class LinuxCheckBox : ICheckBox
{
  private bool _checked;
  public void Check(bool isChecked)
  {
    _checked = isChecked;
  }

  public string GetStyle()  => "Linux CheckBox";
  public bool IsChecked() => _checked;

  public void Render()
  {
    Console.WriteLine($"Rendering Linux CheckBox - Checked: {_checked}");
  }
}