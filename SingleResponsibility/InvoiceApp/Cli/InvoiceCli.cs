using InvoiceApp.Interfaces;

namespace InvoiceApp.Cli;

public class InvoiceCli(
  IInvoiceParser invoiceParser,
  IInvoiceCalculator invoiceCalculator,
  IReportFormatter reportFormatter)
{
  private readonly IInvoiceParser _invoiceParser = invoiceParser;
  private readonly IInvoiceCalculator _invoiceCalculator = invoiceCalculator;
  private readonly IReportFormatter _reportFormatter = reportFormatter;

  public void Run(string[] args)
  {
    // TODO: Create validator, create as a service
    if (args.Length == 0)
    {
      throw new ArgumentException("Expecting JSON invoices!");
    }

    var json = args[0];
    var invoices = _invoiceParser.Parse(json);
    var (total, average) = _invoiceCalculator.Calculate(invoices);
    var report = _reportFormatter.Format(invoices, total, average);

    Console.WriteLine(report);
  }
}