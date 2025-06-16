using SQLQueryBuilder.Interfaces;

namespace SQLQueryBuilder.Builder;

public class StandardSQLQueryBuilder : SQLQueryBuilder
{
  public override ISQLQueryBuilder From(params string[] tables)
  {
    return this;
  }

  public override ISQLQueryBuilder GroupBy(params string[] fields)
  {
    return this;
  }

  public override ISQLQueryBuilder Having(string condition)
  {
    return this;
  }

  public override ISQLQueryBuilder Join(string joinClause)
  {
    return this;
  }

  public override ISQLQueryBuilder Limit(int count)
  {
    return this;
  }

  public override ISQLQueryBuilder OrderBy(params string[] fields)
  {
    return this;
  }

  public override ISQLQueryBuilder Select(params string[] fields)
  {
    if (fields == null || fields.Length == 0)
    {
      throw new ArgumentException("At least one field is required for SELECT");
    }

    foreach (var field in fields)
    {
      if (string.IsNullOrWhiteSpace(field))
      {
        throw new ArgumentException("Field cannot be null or whitespace");
      }

      _query.AddSelectField(field.Trim());
    }

    return this;
  }

  public override ISQLQueryBuilder Where(string condition)
  {
    return this;
  }
}