using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Interfaces;

public interface IPayrollCalculator
{
    decimal Calculate(Employee employee);
}
