using CryptoCosmingo.Models;
using CryptoCosmingo.Config;
using Microsoft.Data.Sqlite;

namespace CryptoCosmingo.Repositories
{
    public class SymbolRepository : ISymbolRepository
    {
        private readonly string _connectionString;

        public SymbolRepository(DatabaseConfig dbConfig)
        {
            _connectionString = dbConfig.ConnectionString;
        }

        public async Task<List<Symbol>> GetAllAsync()
        {
            var list = new List<Symbol>();

            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Name FROM Symbols;";

            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                list.Add(new Symbol
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                });
            }

            return list;
        }

        public async Task CreateAsync(Symbol symbol)
        {
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();

            var command = connection.CreateCommand();
            command.CommandText =
                @"INSERT INTO Symbols(Name)
                  VALUES($name);";

            command.Parameters.AddWithValue("$name", symbol.Name);

            await command.ExecuteNonQueryAsync();
        }
    }
}
