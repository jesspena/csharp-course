using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Problem4
{
    public class OrderReport
    {
        private readonly List<string> _report = new();

        public void Log(string message)
        {
            _report.Add($"[{DateTime.UtcNow}] {message}");
        }

        public void LogReport(string line)
        {
            _report.Add(line);
        }

        public void PrintReport()
        {
            Console.WriteLine("---- Order Report ----");
            foreach (var log in _report)
            {
                Console.WriteLine(log);
            }
        }

        public void Clear() => _report.Clear();
    }
}
