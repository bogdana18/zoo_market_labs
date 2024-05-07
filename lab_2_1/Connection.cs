using Npgsql;

namespace lab_2_1
{
    class Connection
    {
        private NpgsqlConnection _connection;

        public Connection(NpgsqlConnection conn)
        {
            _connection = conn;
        }

        public NpgsqlConnection Conection { get => _connection; set => _connection = value; }

        public void Connecting()
        {
            try
            {
                // Встановлення з'єднання
                _connection.Open();
                Console.WriteLine("Connection Established Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
        }

        public void CloseConnection()
        {
            _connection.Close();
        }
    }
}
