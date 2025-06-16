using SQLQueryBuilder.Models;

namespace SQLQueryBuilder.Interfaces;

public interface ISQLQueryBuilder
{
  void Reset();
  ISQLQueryBuilder Select(params string[] fields);
  ISQLQueryBuilder From(params string[] tables);
  ISQLQueryBuilder Where(string condition);
  ISQLQueryBuilder Join(string joinClause);
  ISQLQueryBuilder GroupBy(params string[] fields);
  ISQLQueryBuilder Having(string condition);
  ISQLQueryBuilder OrderBy(params string[] fields);
  ISQLQueryBuilder Limit(int count);
  SQLQuery Build();
}