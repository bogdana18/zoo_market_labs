using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;

namespace lab_2_1
{
    internal class Selects : Connection
    {
        public Selects(NpgsqlConnection conn) : base(conn) { }

        public void SelectAllItems(string tableName)
        {
            Connecting();
            string sql = $"SELECT * FROM zoo.{tableName};";
            ExecuteSql(sql);
        }

        public void GetTablesinSchema()
        {
            Connecting();
            DataTable table = base.Conection.GetSchema("Tables", new string[] { null, "zoo" });
            foreach (DataRow dataRow in table.Rows)
            {
                Console.WriteLine("  {0}", dataRow[2]);
            }
            CloseConnection();
        }

        public void SelectAllItemsByOption(string option)
        {
            Connecting();
            string sql = "";
            switch (option)
            {
                case "detailed_sales":
                    sql = @"SELECT s.saleid, e.name AS employee_name, c.name AS customer_name, p.name AS pet_name, s.totalamount
                            FROM zoo.sale s
                            JOIN zoo.employee e ON s.employeeid = e.employeeid
                            JOIN zoo.customer c ON s.customerid = c.customerid
                            JOIN zoo.pet p ON s.petid = p.petid
                            WHERE s.totalamount > 1000;";
                    break;
                case "total_sales_by_employee":
                    sql = @"SELECT e.name, SUM(s.totalamount) AS total_sales
                            FROM zoo.sale s
                            JOIN zoo.employee e ON s.employeeid = e.employeeid
                            GROUP BY e.name;";
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    return;
            }
            ExecuteSql(sql);
        }

        private void ExecuteSql(string sql)
        {
            try
            {
                NpgsqlCommand command = new NpgsqlCommand(sql, (NpgsqlConnection)base.Conection);
                NpgsqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    List<string> columnNames = new List<string>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        columnNames.Add(reader.GetName(i));
                    }
                    Console.WriteLine(string.Join("\t", columnNames));

                    while (reader.Read())
                    {
                        List<string> values = new List<string>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            values.Add(reader.GetValue(i).ToString());
                        }
                        Console.WriteLine(string.Join("\t", values));
                    }
                }
                else
                {
                    Console.WriteLine("No data found.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops, something went wrong: " + e.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
