using ProductExportApp.Models;
using ProductExportApp.Interfaces;

namespace ProductExportApp.Services;

public class FormatValidator : IFormatValidator
{
    public void Validate(string format)
    {
        if (!Enum.TryParse<FormatType>(format, true, out _))
        {
            throw new ArgumentException($"Format '{format}' is not supported.");
        }
    }
}
