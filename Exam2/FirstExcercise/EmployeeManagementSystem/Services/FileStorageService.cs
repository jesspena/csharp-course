using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Services;

public class FileStorageService
{
    private readonly string _filePath;

    public FileStorageService(string filePath)
    {
        _filePath = filePath;
    }

    public void Save(IEnumerable<Employee> employees)
    {
        Console.WriteLine("\n(Es solo una simulación) Guardando empleados en archivo:");
        foreach (var e in employees)
        {
            Console.WriteLine($"{e.Name} - {e.Type} - Base: {e.SalaryEmployee.BaseSalary}, Bonus: {e.SalaryEmployee.Bonus}");
        }
    }
}