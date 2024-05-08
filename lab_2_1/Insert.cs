using System.Text;
using Npgsql;

namespace lab_2_1
{
    internal class Insert : Connection
    {
        public Insert(NpgsqlConnection conn) : base(conn)
        {

        }

        private new void Connecting()
        {
            base.Connecting();
        }

        public new void CloseConnection()
        {
            base.CloseConnection();
        }

        public void InsertData(string tableName, Dictionary<string, object> data)
        {
            Connecting();
            try
            {
                // Побудова SQL-виразу для вставки даних
                StringBuilder sqlBuilder = new StringBuilder();
                sqlBuilder.AppendFormat("INSERT INTO {0} (", tableName);
                int count = 0;
                foreach (var item in data)
                {
                    sqlBuilder.AppendFormat("\"{0}\"", item.Key);
                    if (++count < data.Count)
                        sqlBuilder.Append(", ");
                }

                sqlBuilder.Append(") VALUES (");

                count = 0;
                foreach (var item in data)
                {
                    sqlBuilder.AppendFormat("@{0}", item.Key);
                    if (++count < data.Count)
                        sqlBuilder.Append(", ");
                }

                sqlBuilder.Append(")");

                // Виконання запиту
                using (NpgsqlCommand command = new NpgsqlCommand(sqlBuilder.ToString(), Conection))
                {
                    foreach (var item in data)
                    {
                        command.Parameters.AddWithValue("@" + item.Key, item.Value);
                    }

                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Inserting completed");
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
