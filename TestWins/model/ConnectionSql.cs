using MySql.Data.MySqlClient;

namespace TestWins.Model
{
    public class ConnectionSql
    {
        private readonly string _connectionString = "server=localhost;database=student;uid=root;pwd=root";

        public MySqlConnection connectSql()
        {
            try
            {
                Console.WriteLine("Connecting to DB");

                MySqlConnection conn = new MySqlConnection(_connectionString);
                conn.Open();

                Console.WriteLine("Database connection successful");

                return conn;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database connection failed: " + ex.Message);
                throw;
            }
        }
    }
}
