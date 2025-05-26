using InvoiceApp.Models;

namespace InvoiceApp.Interfaces;

public interface IReportFormatter
{
    string Format(IEnumerable<Invoice> invoices, decimal total, decimal average);
}