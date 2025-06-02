using InvoiceApp.Interfaces;

namespace InvoiceApp.Cli;

public class InvoiceCli(
  IInvoiceParser invoiceParser,
  IInvoiceCalculator invoiceCalculator,
  IReportFormatter reportFormatter,
  IArgumentValidator validator)
{
  private readonly IInvoiceParser _invoiceParser = invoiceParser;
  private readonly IInvoiceCalculator _invoiceCalculator = invoiceCalculator;
  private readonly IReportFormatter _reportFormatter = reportFormatter;
  private readonly IArgumentValidator _validator = validator;

  public void Run(string[] args)
  {
    // TODO: Create validator, create as a service
    _validator.Validate(args);

    var json = args[0];
    var invoices = _invoiceParser.Parse(json);
    var (total, average) = _invoiceCalculator.Calculate(invoices);
    var report = _reportFormatter.Format(invoices, total, average);

    Console.WriteLine(report);
  }
}