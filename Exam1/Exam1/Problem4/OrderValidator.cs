namespace Exam1.Problem4
{
    public class OrderValidator
    {
        public bool IsValid(Order order, out string? error)
        {
            if (order.Quantity <= 0)
            {
                error = $"Invalid quantity for order {order.Id}";
                return false;
            }
            if (order.UnitPrice <= 0)
            {
                error = $"Invalid price for order {order.Id}";
                return false;
            }

            error = null;
            return true;
        }
    }
}
