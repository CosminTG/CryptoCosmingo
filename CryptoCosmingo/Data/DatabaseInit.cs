using Microsoft.Data.Sqlite;

namespace CryptoCosmingo.Data
{
    public class DatabaseInit
    {
        public static void CreateTables(string connectionString)
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = 
                @"CREATE TABLE IF NOT EXISTS Symbols(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL);
                ";
            command.ExecuteNonQuery();
        }
    }
}
