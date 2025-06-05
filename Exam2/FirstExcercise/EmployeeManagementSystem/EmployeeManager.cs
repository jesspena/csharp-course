namespace EmployeeManagementSystem;

public class EmployeeManager
{
  private List<Employee> employees = new List<Employee>();

  public void AddEmployee(string name, string type, decimal baseSalary, decimal bonus)
  {
    var employee = new Employee
    {
      Name = name,
      Type = type,
      BaseSalary = baseSalary,
      Bonus = bonus
    };
    employees.Add(employee);

    Console.WriteLine($"Employee {name} added successfully!");
  }

  public decimal CalculateSalary(Employee employee)
  {
    decimal salary = 0;

    if (employee.Type == "FullTime")
    {
      salary = employee.BaseSalary + employee.Bonus;
    }
    else if (employee.Type == "PartTime")
    {
      salary = employee.BaseSalary * 0.8m + employee.Bonus;
    }
    else if (employee.Type == "Contractor")
    {
      salary = employee.BaseSalary;
    }

    return salary;
  }

  public void SaveToFile(string fileName)
  {
    try
    {
      using (var writer = new StreamWriter(fileName))
      {
        foreach (var employee in employees)
        {
          writer.WriteLine($"{employee.Name},{employee.Type},{employee.BaseSalary},{employee.Bonus}");
        }
      }
      Console.WriteLine("Data saved successfully!");
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error saving file: {ex.Message}");
    }
  }

  public void LoadFromFile(string fileName)
  {
    try
    {
      if (File.Exists(fileName))
      {
        var lines = File.ReadAllLines(fileName);

        foreach (var line in lines)
        {
          var parts = line.Split(',');

          if (parts.Length == 4)
          {
            AddEmployee(parts[0], parts[1], decimal.Parse(parts[2]), decimal.Parse(parts[3]));
          }
        }
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error loading file: {ex.Message}");
    }
  }

  public void DisplayAllEmployees()
  {
    Console.WriteLine("\n=== Employee List ===");

    foreach (var employee in employees)
    {
      var salary = CalculateSalary(employee);

      Console.WriteLine($"Name: {employee.Name}, Type: {employee.Type}, Salary: ${salary:F2}");
    }
  }

  public void ProcessPayroll()
  {
    Console.WriteLine("\n=== Processing Payroll ===");

    decimal totalPayroll = 0;

    foreach (var employee in employees)
    {
      var salary = CalculateSalary(employee);
      totalPayroll += salary;

      Console.WriteLine($"Paying {employee.Name}: ${salary:F2}");
      File.AppendAllText("payroll_log.txt", $"{DateTime.Now}: Paid {employee.Name} ${salary:F2}\n");
    }

    Console.WriteLine($"Total Payroll: ${totalPayroll:F2}");
  }
}

