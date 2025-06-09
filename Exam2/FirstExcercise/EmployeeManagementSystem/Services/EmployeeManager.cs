using EmployeeManagementSystem.Factories;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Interfaces;

namespace EmployeeManagementSystem.Services;

public class EmployeeManager
{
    private readonly List<Employee> _employees = new();
    private readonly EmployeeFactory _factory;
    private readonly PayrollProcessor _payroll;
    private readonly FileStorageService _storage;

    public EmployeeManager(EmployeeFactory factory, PayrollProcessor payroll, FileStorageService storage)
    {
        _factory = factory;
        _payroll = payroll;
        _storage = storage;
    }

    public void AddEmployee(string name, string type, decimal baseSalary, decimal bonus)
    {
        var employee = _factory.Create(name, type, baseSalary, bonus);
        _employees.Add(employee);
        Console.WriteLine($"Employee {name} added successfully!");
    }

    public void DisplayAllEmployees()
    {
        Console.WriteLine("\n=== Employee List ===");
        foreach (var employee in _employees)
        {
            var salary = _payroll.Process(employee);
            Console.WriteLine($"Name: {employee.Name}, Type: {employee.Type}, Salary: ${salary:F2}");
        }
    }

    public void ProcessPayroll()
    {
        Console.WriteLine("\n=== Processing Payroll ===");
        decimal total = 0;
        foreach (var employee in _employees)
        {
            var salary = _payroll.Process(employee);
            total += salary;
            Console.WriteLine($"Paying {employee.Name}: ${salary:F2}");
            File.AppendAllText("payroll_log.txt", $"{DateTime.Now}: Paid {employee.Name} ${salary:F2}\n");
        }
        Console.WriteLine($"Total Payroll: ${total:F2}");
    }

    public void Save() => _storage.Save(_employees);
}