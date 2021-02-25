
public class SqlBulkDbContext<T> where T : class
{
  private readonly string _connectionString;
  public SqlClientDbContext(string connectionString)
  {
    _connectionString = connectionString;
  }

  public void QuickBulkUpdate(List<T> entityList, string tableName = null)
  {
    Console.WriteLine("Quick Bulk Update Called");

    try
    {
      var datatable = ToDataTable(entityList);
      var tempTableName = "TempBulkTable";
      string tempTableTxtCmd = GetTempTableCreateCmd(datatable, tempTableName);

      using (SqlConnection conn = new SqlConnection(_connectionString))
      {
        conn.Open();

        var originalTableName = tableName ?? typeof(T).Name;

        ExecuteCmd(tempTableTxtCmd, conn);

        Console.WriteLine($"Created Temp Table");

        Console.WriteLine("Bulk Insert Started");

        var transaction = conn.BeginTransaction();
        using (var bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, transaction))
        {
          bulkCopy.DestinationTableName = tempTableName;
          bulkCopy.WriteToServer(datatable);
        }
        transaction.Commit();

        Console.WriteLine("Bulk Insert Completed");

        var updateFromTempTableCmd = GetOriginalTblToTempTableUpdateCmd(datatable, originalTableName, tempTableName);
        ExecuteCmd(updateFromTempTableCmd, conn);

        Console.WriteLine("Updating from Temp Table Completed");

        var dropTempTableCmd = $"DROP TABLE {tempTableName}";
        ExecuteCmd(dropTempTableCmd, conn);

        Console.WriteLine("Drop that temp table");

      }
    }
    catch (Exception)
    {
      throw;
    }

    Console.WriteLine("Quick Bulk Update Ended");

    string GetTempTableCreateCmd(DataTable dataTable, string tempTable)
    {
      StringBuilder columnTxt = new StringBuilder();
      columnTxt.Append($"CREATE TABLE {tempTable}(");
      int columnCount = dataTable.Columns.Count;


      for (int i = 0; i < columnCount; i++)
      {
        string dataType = dataTable.Columns[i].DataType == Type.GetType("System.String") ? "VARCHAR(100) " : dataTable.Columns[i].DataType.ToString();
        string colum = $"{dataTable.Columns[i]} {dataType}";

        columnTxt.Append($"{colum}");

        if (i != columnCount - 1)
          columnTxt.Append(", ");
      }
      columnTxt.Append(");");

      return columnTxt.ToString();
    }

    string GetOriginalTblToTempTableUpdateCmd(DataTable dataTable, string originalTable, string tempTable)
    {
      StringBuilder updateTblCmd = new StringBuilder();
      updateTblCmd.Append("UPDATE ORGI SET ");
      for (int i = 1; i < dataTable.Columns.Count; i++)
      {
        updateTblCmd.Append($"ORGI.{dataTable.Columns[i]} = TEMP.{dataTable.Columns[i]}");

        if (i != dataTable.Columns.Count - 1)
          updateTblCmd.Append(", ");
      }

      updateTblCmd.Append($" FROM {tempTable} TEMP INNER JOIN {originalTable} ORGI ON ORGI.{dataTable.Columns[0]} = TEMP.{dataTable.Columns[0]}");
      return updateTblCmd.ToString();
    }
  }
  private void ExecuteCmd(string cmdTxt, SqlConnection connection)
  {
    using (SqlCommand cmd = new SqlCommand(cmdTxt, connection))
    {
      cmd.ExecuteNonQuery();
    }
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