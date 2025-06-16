namespace SQLQueryBuilder.Models;

public class SQLQuery
{
  // The complex object we want to build.
  private readonly List<string> _selectFields = [];

  public void AddSelectField(string field) => _selectFields.Add(field);

  public override string ToString() => ToSQL();

  public string ToSQL()
  {
    return string.Empty;
  }

  public bool IsQueryValid()
  {
    return false;
  }
}