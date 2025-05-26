namespace InvoiceApp.Models;

public record Invoice(
  int Id,
  string Customer,
  decimal Amount,
  DateOnly Date
);