using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DataAccess.DbAccess;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;

    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }

    // Existing Stored Procedure SELECT
    public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters)
    {
        using IDbConnection connection = GetConnection();
        return await connection.QueryAsync<T>(storedProcedure, parameters,
                     commandType: CommandType.StoredProcedure);
    }

    // Existing Stored Procedure INSERT/UPDATE
    public async Task SaveData<T>(string storedProcedure, T parameters)
    {
        using IDbConnection connection = GetConnection();
        await connection.ExecuteAsync(storedProcedure, parameters,
              commandType: CommandType.StoredProcedure);
    }

    // NEW: Raw SQL SELECT query
    public async Task<IEnumerable<T>> LoadDataQueryAsync<T, U>(string sqlQuery, U parameters)
    {
        using IDbConnection connection = GetConnection();
        return await connection.QueryAsync<T>(sqlQuery, parameters, commandType: CommandType.Text);
    }


    // NEW: Raw SQL INSERT/UPDATE/DELETE query
    public async Task<int> SaveDataExecuteAsync<T>(string sqlQuery, T parameters)
    {
        using IDbConnection connection = GetConnection();
        return await connection.ExecuteAsync(sqlQuery, parameters,
              commandType: CommandType.Text);
    }


    public string DebugFinalSQLQuerry<T>(string sql, T parameters)
    {
        if (parameters == null) return sql;

        var props = typeof(T).GetProperties();

        foreach (var prop in props)
        {
            var name = prop.Name;
            var value = prop.GetValue(parameters);
            string formattedValue = value switch
            {
                null => "NULL",
                string s => $"'{s.Replace("'", "''")}'",
                DateTime dt => $"'{dt:yyyy-MM-dd HH:mm:ss}'",
                bool b => b ? "1" : "0",
                _ => value?.ToString()
            };

            sql = sql.Replace("@" + name, formattedValue);
        }

        return sql;
    }








    public IDbConnection GetConnection(string? connectionId = "MySQL")
    {
        IDbConnection connection;
        switch (connectionId)
        {
            case "SqlServer":
                connection = new SqlConnection(_config.GetConnectionString(connectionId));
                break;
            case "MySQL":
            default:
                connection = new MySqlConnection(_config.GetConnectionString(connectionId));
                break;
        }
        return connection;
    }


}
