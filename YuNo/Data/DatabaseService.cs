using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace YuNo
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        //private readonly SqliteConnection _connection;

        public DatabaseService()
        {
            var dbPath = Path.Combine(
                FileSystem.AppDataDirectory,
                "yuno.db");

           //_connection = new SqliteConnection(dbPath);

            _connectionString = $"Data Source={dbPath}";
        }

        public SqliteConnection CreateConnection()
            => new(_connectionString);

        public async Task InitializeAsync() //создаем бд, если такой нет
        {
            const string sql = """
        CREATE TABLE IF NOT EXISTS NoEntries
        (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Title TEXT NOT NULL,
            Description TEXT,
            CreatedAt TEXT NOT NULL
        );
        """;

            await using var connection = CreateConnection();

            await connection.OpenAsync();

            await using var command = connection.CreateCommand();
            command.CommandText = sql;

            await command.ExecuteNonQueryAsync();
        }
    }
}
