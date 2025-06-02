namespace PaymentApp.Services;

public class UserNotifier : IUserNotifier
{
    public void Notify(string message)
    {
        Console.WriteLine(message);
    }

    public void ShowRefundNotSupported(string method)
    {
        Console.WriteLine($"Refund not supported for method {method}.");
    }

    public void ShowRefundSuccess(string reference)
    {
        Console.WriteLine($"Refund processed successfully for reference {reference}.");
    }
}