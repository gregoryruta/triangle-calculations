using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace triangle_calculations
{
    public class DatabaseConnection
    {
        private SqliteConnection _conn;

        public DatabaseConnection()
        {
            _conn = new SqliteConnection("Data Source=calculation_database.db");
            _conn.Open();
            Debug.WriteLine("Database Connection opened");
        }

        ~DatabaseConnection()
        {
            _conn.Close();
            Debug.WriteLine("Database connection closed");
        }

        // Command for SELECT queries
        public string SelectCommand(string statement, int columnCount)
        {
            SqliteCommand cmd = _conn.CreateCommand();
            cmd.CommandText = statement;
            cmd.ExecuteNonQuery();

            SqliteDataReader reader = cmd.ExecuteReader();

            string output = "";

            // Read each row
            while (reader.Read())
            {
                // Read each column
                for (int i = 0; i < columnCount; i++)
                    output += $"{reader.GetString(i)}\n";

                output += "\n";
            }

            return output;
        }

        // Command for non-returning statements
        public void OtherCommand(string statement)
        {
            SqliteCommand cmd = _conn.CreateCommand();
            cmd.CommandText = statement;
            cmd.ExecuteNonQuery();
        }

        // Create tables
        public void CreateTable()
        {
            string statement = "SELECT name FROM sqlite_master WHERE type='table' AND name='calc_history'";

            // If calc_history table doesn't exist, create it
            if (SelectCommand(statement, 1) == "")
            {
                statement = "CREATE TABLE calc_history (timestamp VARCHAR(30), summary VARCHAR(200))";
                OtherCommand(statement);
            }
        }

        // Drop tables
        public void DropTable()
        {
            OtherCommand("DROP TABLE IF EXISTS calc_history");
        }

        // Insert summary
        public void InsertSummary(string timestamp, string summary)
        {
            OtherCommand($"INSERT INTO calc_history (timestamp, summary) VALUES ('{timestamp}', '{summary}')");
        }

        // Select and return summaries
        public string SelectSummaries()
        {
            return SelectCommand("SELECT timestamp, summary FROM calc_history ORDER BY rowid DESC", 2);
        }
    }
}
