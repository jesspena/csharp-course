namespace EmployeeManagementSystem;

public class Program
{
  public static void Main()
  {
    var manager = new EmployeeManager();

    manager.AddEmployee("John Doe", "FullTime", 5000, 500);
    manager.AddEmployee("Jane Smith", "PartTime", 3000, 200);
    manager.AddEmployee("Bob Johnson", "Contractor", 4000, 0);

    manager.DisplayAllEmployees();
    manager.ProcessPayroll();
    manager.SaveToFile("employees.txt");
  }
}
