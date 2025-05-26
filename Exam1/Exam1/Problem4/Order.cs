using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Problem4
{
    public record Order(
    string Id,
    int Quantity,
    decimal UnitPrice
)
    {
        public decimal Total { get; set; } = 0;
    }
}
