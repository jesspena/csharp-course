using InvoiceApp.Interfaces;

namespace InvoiceApp.Services;

public class Validator : IArgumentValidator
{
    public void Validate(string[] args)
    {
        if (args.Length == 0 || string.IsNullOrWhiteSpace(args[0]))
        {
            throw new ArgumentException("Expecting JSON invoices as the first argument!");
        }
    }
}
