using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Interfaces;

namespace EmployeeManagementSystem.Processors;

public class PartialTimeCalculator : IPayrollCalculator
{
    public decimal Calculate(Employee employee)
    {
        return employee.SalaryEmployee.BaseSalary * 0.8m + employee.SalaryEmployee.Bonus;
    }
}