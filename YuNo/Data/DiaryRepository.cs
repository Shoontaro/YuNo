using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using YuNo.Models;

namespace YuNo.Data
{
    internal class DiaryRepository
    {
        private readonly DatabaseService _database; 

        public DiaryRepository(DatabaseService database)
        {
            _database = database;
        }

        public async Task<List<NoEntry>> GetAllAsync()
        {
            const string sql = """
        SELECT *
        FROM NoEntries
        ORDER BY CreatedAt DESC
        """;

            await using var connection =
                _database.CreateConnection();

            var result =
                await connection.QueryAsync<NoEntry>(sql);

            return result.ToList();
        }

        public async Task AddAsync(NoEntry entry)
        {
            const string sql = """
        INSERT INTO NoEntries
        (
            Title,
            Description,
            CreatedAt
        )
        VALUES
        (
            @Title,
            @Description,
            @CreatedAt,
        )
        """;

            await using var connection =
                _database.CreateConnection();

            await connection.ExecuteAsync(sql, entry);
        }
    }
}
