using EmployeeManagementSystem.Constants;
using EmployeeManagementSystem.Factories;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Services;

namespace EmployeeManagementSystem;

public class Program
{
    static void Main()
    {
        var factory = new EmployeeFactory();
        var payroll = new PayrollProcessor();
        var storage = new FileStorageService("employees.txt");
        var manager = new EmployeeManager(factory, payroll, storage);

        manager.AddEmployee("John Doe", EmployeeTypes.FullTime, 5000, 500);
        manager.AddEmployee("Jane Smith", EmployeeTypes.PartTime, 3000, 200);
        manager.AddEmployee("Bob Johnson", EmployeeTypes.Contractor, 4000, 0);

        manager.DisplayAllEmployees();
        manager.ProcessPayroll();
        manager.Save();
    }
}
