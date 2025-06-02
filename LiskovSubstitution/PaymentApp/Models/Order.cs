namespace PaymentApp.Models;

public record Order(
  string Id,
  string Method,
  decimal Amount,
  string Reference
);