using System.Data;
using Microsoft.Data.Sqlite;

namespace App.Atea.Data;
/// <summary>
/// I should use the repository pattern in here, but as it is not very useful for the test
/// </summary>
public class Store
{
    private IDbConnection connection;
    /// <summary>
    /// It can be read from the configuration file
    /// </summary>
    private string _connectionString = "Data Source=:memory:";
    internal static Store _instance;
    public static Store Instance => _instance ??= new Store();

    private Store()
    {
        // Creates the in memory db
        connection = new SqliteConnection(_connectionString);
        // Creates the table required
        ExecuteCommand("CREATE TABLE data (INPUT_DATA TEXT NOT NULL,RESULT INTEGER NOT NULL);");
    }

    ~Store()
    {
        connection.Close();
        connection.Dispose();
    }
    public void Insert(ExecutionItem data)
    {

        ExecuteCommand($"INSERT INTO data VALUES  ('{string.Join(",", data.Source)}',{data.Result});");
    }
    /// <summary>
    /// Count the number of records
    /// </summary>
    /// <returns></returns>
    public int CountRecords()
    {
        var query = "SELECT COUNT(1) FROM data;";
        var command = CreateCommand(query);
        return Convert.ToInt32(command.ExecuteScalar());
    }

    internal IDbCommand CreateCommand(string query, CommandType commandType = CommandType.Text)
    {
        var command = connection.CreateCommand();
        command.CommandType = commandType;
        command.CommandText = query;
        return command;
    }

    internal void ExecuteCommand(string query)
    {
        if (!connection.State.Equals(ConnectionState.Open))
        {
            connection.Open();
        }
        CreateCommand(query).ExecuteNonQuery();
    }
}