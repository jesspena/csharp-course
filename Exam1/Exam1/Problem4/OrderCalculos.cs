using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Problem4
{
    public class OrderCalculator
    {
        public void CalculateTotal(Order order)
        {
            order.Total = order.Quantity * order.UnitPrice;
        }
    }

}
