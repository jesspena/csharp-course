public interface IUserNotifier
{
    void ShowRefundNotSupported(string method);
    void ShowRefundSuccess(string reference);
    void Notify(string message);
}
