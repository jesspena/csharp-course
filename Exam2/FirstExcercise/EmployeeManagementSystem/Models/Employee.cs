namespace EmployeeManagementSystem.Models;

public class Employee
{
    public string Name { get; }
    public string Type { get; }
    public SalaryEmployee SalaryEmployee { get; }

    public Employee(string name, string type, SalaryEmployee salaryEmployee)
    {
        Name = name;
        Type = type;
        SalaryEmployee = salaryEmployee;
    }
}
