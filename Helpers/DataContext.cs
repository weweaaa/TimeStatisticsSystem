namespace TimeStatisticsSystem.Helpers;

using System.Data;
using Dapper;
using Microsoft.Data.Sqlite;

public class DataContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IDbConnection CreateConnection()
    {
        return new SqliteConnection(Configuration.GetConnectionString("TimeStatisticsSysDB"));
    }

    public async Task Init()
    {
        // create database tables if they don't exist
        using var connection = CreateConnection();
        await _initUsers();

        async Task _initUsers()
        {
            var sql = """
                CREATE TABLE IF NOT EXISTS 
                DayWork (
                    ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                    日期 TEXT,
                    開始時間 TEXT,
                    主要分類 INTEGER,
                    次要分類 INTEGER,
                    備註 TEXT,
                    花費時間 INTEGER
                );
            """;
            await connection.ExecuteAsync(sql);
        }
    }
}