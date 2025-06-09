
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Interfaces;

public interface IEmployeeFactory
{
    Employee Create(string name, string type, decimal baseSalary, decimal bonus);
}
