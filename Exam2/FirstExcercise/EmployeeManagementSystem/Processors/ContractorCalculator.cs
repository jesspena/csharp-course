using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Interfaces;

namespace EmployeeManagementSystem.Processors;

public class ContractorCalculator : IPayrollCalculator
{
    public decimal Calculate(Employee employee)
    {
        return employee.SalaryEmployee.BaseSalary + employee.SalaryEmployee.Bonus;///modificar todavia
    }
}