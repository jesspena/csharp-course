using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Processors;

public class FullTimeCalculator : IPayrollCalculator
{
    public decimal Calculate(Employee employee)
    {
        return employee.SalaryEmployee.BaseSalary + employee.SalaryEmployee.Bonus;
    }
}