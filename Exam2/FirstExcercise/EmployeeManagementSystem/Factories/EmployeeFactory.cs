using EmployeeManagementSystem.Constants;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Interfaces;

namespace EmployeeManagementSystem.Factories;

public class EmployeeFactory : IEmployeeFactory
{
    public Employee Create(string name, string type, decimal baseSalary, decimal bonus)
    {
        return new Employee(name, type, new SalaryEmployee(baseSalary, bonus));
    }
}