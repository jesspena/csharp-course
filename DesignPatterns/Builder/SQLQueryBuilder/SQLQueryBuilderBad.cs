using System.Text;

namespace SQLQueryBuilder;

public class SQLQueryBuilderBad
{
  public string QueryString { get; }

  // NOTE: Create differnt constructors
  // ISSUE: Massive constructor with many optional parameters

  // PROBLEMS WITH THIS APPROACH:
  // 1. No validation or parameter combinations
  // 2. Handle conditions in a general way
  // 3. Easy to mix up parameter order
  // 4. Constructor does too much
  // 5. Hard to add new optional components
  // 6. SRP
  // 7. Open/Closed principle
  // 8. Primitive obsession
  public SQLQueryBuilderBad(
    string selectClause,
    string fromClause,
    string? whereClause = null,
    string? joinClause = null,
    string? groupByClause = null,
    string? havingClause = null,
    string? orderByClause = null,
    int? limitClause = null,
    bool isDistinct = false)
  {
    if (string.IsNullOrWhiteSpace(selectClause))
    {
      throw new ArgumentException("Select clause is required");
    }

    if (string.IsNullOrWhiteSpace(fromClause))
    {
      throw new ArgumentException("From clause is required");
    }

    var query = new StringBuilder();

    query.Append("SELECT ");

    if (isDistinct)
    {
      query.Append("DISTINCT ");
    }

    query.Append(selectClause);
    query.Append(" FROM ").Append(fromClause);

    if (!string.IsNullOrWhiteSpace(joinClause))
    {
      query.Append(' ').Append(joinClause);
    }

    if (!string.IsNullOrWhiteSpace(whereClause))
    {
      query.Append(" WHERE ").Append(whereClause);
    }

    if (!string.IsNullOrWhiteSpace(groupByClause))
    {
      query.Append(" GROUP BY ").Append(groupByClause);
    }

    if (!string.IsNullOrWhiteSpace(havingClause))
    {
      query.Append(" HAVING ").Append(havingClause);
    }

    if (!string.IsNullOrWhiteSpace(orderByClause))
    {
      query.Append(" ORDER BY ").Append(orderByClause);
    }

    if (limitClause.HasValue)
    {
      query.Append($" LIMIT {limitClause.Value}");
    }

    QueryString = query.ToString();
  }
}