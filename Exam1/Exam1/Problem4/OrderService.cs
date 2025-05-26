namespace Exam1.Problem4
{
    public class OrderService
    {
        private readonly OrderValidator _validarOrder = new();
        private readonly OrderCalculator _calcularOrder = new();
        private readonly OrderReport _report = new();
        private readonly List<Order> _processedOrders = new List<Order>();

        public void ProcessOrders()
        {
            // 1. Inline order data
            var orders = new List<Order>
        {
            new Order("A100", 2, 15.50m),
            new Order("B200", 1, 99.99m),
            new Order("C300", 5, 7.25m)
        };

            foreach (var order in orders)
            {
                if (!_validarOrder.IsValid(order, out var error))
                {
                    _report.Log(error!);
                    continue;
                }

                _calcularOrder.CalculateTotal(order);
                _processedOrders.Add(order);
                _report.LogReport($"Order {order.Id}: {order.Quantity} × {order.UnitPrice:C} = {order.Total:C}");
            }

            _report.PrintReport();
            _report.Clear();
        }
    }
}
