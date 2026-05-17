using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using YuNo.Models;

namespace YuNo
{
    public class DiaryRepository
    {
        private readonly DatabaseService _database; 

        public DiaryRepository(DatabaseService database)
        {
            _database = database;
        }

        public async Task<int> GetTotalCountAsync()
        {
            const string sql =
                "SELECT COUNT(*) FROM NoEntries";

            await using var connection =
                _database.CreateConnection();

            return await connection.ExecuteScalarAsync<int>(sql);
        }

        //public async Task<int> GetTodayCountAsync()
        //{
        //    const string sql = """
        //SELECT COUNT(*)
        //FROM NoEntries
        //WHERE date(CreatedAt) = date('now','localtime')
        //""";

        //    await using var connection =
        //        _database.CreateConnection();

        //    return await connection.ExecuteScalarAsync<int>(sql);
        //}

        //public async Task<int> GetWeekCountAsync()
        //{
        //    const string sql = """
        //SELECT COUNT(*)
        //FROM NoEntries
        //WHERE CreatedAt >= datetime(
        //    'now',
        //    '-7 days',
        //    'localtime'
        //)
        //""";

        //    await using var connection =
        //        _database.CreateConnection();

        //    return await connection.ExecuteScalarAsync<int>(sql);
        //}

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
