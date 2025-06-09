using EmployeeManagementSystem.Constants;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Processors;
using EmployeeManagementSystem.Interfaces;

namespace EmployeeManagementSystem.Services;

public class PayrollProcessor
{
    public decimal Process(Employee employee)
    {
        IPayrollCalculator calculator = employee.Type switch
        {
            EmployeeTypes.FullTime => new FullTimeCalculator(),
            EmployeeTypes.PartTime => new PartialTimeCalculator(),
            EmployeeTypes.Contractor => new ContractorCalculator(),
            _ => throw new ArgumentException("Unknown employee type")
        };

        return calculator.Calculate(employee);
    }
}