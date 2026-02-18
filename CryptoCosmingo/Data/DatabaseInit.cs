using Microsoft.Data.Sqlite;

namespace CryptoCosmingo.Data
{
    public class DatabaseInit
    {
        public static void CreateTables(string connectionString)
        {
            try
            {
                using var connection = new SqliteConnection(connectionString);
                connection.Open();

                using var command = connection.CreateCommand();
                command.CommandText =
                @"CREATE TABLE IF NOT EXISTS symbols(
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    name TEXT NOT NULL,
                    created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
                );

                CREATE TABLE IF NOT EXISTS candles(
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    symbol_id INTEGER NOT NULL,
                    open_time DATETIME NOT NULL,
                    open_price REAL NOT NULL,
                    high_price REAL NOT NULL,
                    low_price REAL NOT NULL,
                    close_price REAL NOT NULL,
                    volume REAL NOT NULL,
                    interval TEXT NOT NULL,
                    created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
                    FOREIGN KEY (symbol_id) REFERENCES symbols(id) ON DELETE CASCADE,
                    UNIQUE(symbol_id, open_time, interval)
                );

                CREATE TABLE IF NOT EXISTS sync_logs(
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    symbol_id INTEGER NOT NULL,
                    last_sync_time DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
                    candles_saved INTEGER NOT NULL,
                    status TEXT NOT NULL,
                    FOREIGN KEY (symbol_id) REFERENCES symbols(id) ON DELETE CASCADE
                );

                CREATE TABLE IF NOT EXISTS bot_status(
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    running INTEGER NOT NULL DEFAULT 0,
                    last_error TEXT,
                    interval TEXT NOT NULL,
                    updated_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
                );
                ";
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
