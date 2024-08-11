using MySql.Data.MySqlClient;
using Dapper;

public class DataService
{
    private readonly string _connectionString;

    public DataService(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task SaveData(string sql, object parameters)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            await connection.ExecuteAsync(sql, parameters);
        }
    }
}


