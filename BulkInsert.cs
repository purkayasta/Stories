
public class SqlBulkDbContext<T> where T : class 
{
  private readonly string _connectionString;
  public SqlClientDbContext(string connectionString)
  {
    _connectionString = connectionString;
  }

  public void QuickBulkInsert(List<T> entityList, string tableName = null)
  {
    Console.WriteLine("Quick Bulk Called");
    try
    {
      var entryTableName = tableName ?? typeof(T).Name;

      using (SqlConnection conn = new SqlConnection(_connectionString))
      {
        conn.Open();
        var datatables = ToDataTable(entityList);
        var transaction = conn.BeginTransaction();
        using (var bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, transaction))
        {
          bulkCopy.DestinationTableName = entryTableName;
          bulkCopy.WriteToServer(datatables);
        }
        transaction.Commit();
        }
    }
    catch (Exception)
    {
      throw;
    }
    Console.WriteLine("Quick Bulk Ended");
  }

  private DataTable ToDataTable(List<T> items)
  {
    DataTable dataTable = new DataTable(typeof(T).Name);
    PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
    foreach (PropertyInfo prop in Props)
    {
      dataTable.Columns.Add(prop.Name);
    }
    foreach (T item in items)
    {
      var values = new object[Props.Length];
      for (int i = 0; i < Props.Length; i++)
      {
        values[i] = Props[i].GetValue(item, null);
      }
      dataTable.Rows.Add(values);
    }
    return dataTable;
  }

}