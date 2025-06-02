using PaymentApp.Models;
using System.Collections.Generic;

namespace PaymentApp.Interfaces;

public interface IOrderProvider
{
    IEnumerable<Order> GetOrders(string[] args);
}
