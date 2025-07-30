
using Dapper;
using System.Data;

namespace DataAccess.DbAccess;

public interface ISqlDataAccess
{
    Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters);
    Task SaveData<T>(string storedProcedure, T parameters);
    Task<IEnumerable<T>> LoadDataQueryAsync<T, U>(string sqlQuery, U parameters);
    Task<int> SaveDataExecuteAsync<T>(string sqlQuery, T parameters);
    string DebugFinalSQLQuerry<T>(string sql, T parameters);


}