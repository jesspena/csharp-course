namespace EmployeeManagementSystem.Models;

public class SalaryEmployee
{
    public decimal BaseSalary { get; }
    public decimal Bonus { get; }

    public SalaryEmployee(decimal baseSalary, decimal bonus)
    {
        BaseSalary = baseSalary;
        Bonus = bonus;
    }
}