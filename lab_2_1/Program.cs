using lab_2_1.Models;

namespace lab_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*string connString = "Host=localhost;Username=postgres;Password=341841911;Database=postgres";
            NpgsqlConnection conn = new NpgsqlConnection(connString);*/
            using (var context = new ZooContext())
            {

                context.Database.EnsureCreated();

                /*Console.WriteLine("Select an option from the list below");
                Console.WriteLine("0 - Get all tables");*/
                Console.WriteLine("1 - Select Table info");
                /* Console.WriteLine("2 - Insert Value to Tables (select one - zoo.pet,zoo.customer,zoo.employee,zoo.product,zoo.sale)");
                 Console.WriteLine("3 - Execute predefined query");*/

                Selects selector = new Selects(context);

                int swt = Convert.ToInt32(Console.ReadLine());
                //Selects selector = new Selects(context);
                switch (swt)
                {
                    /*case 0:
                        Selects sel = new Selects(context);
                        sel.GetTablesinSchema();
                        break;*/
                    case 1:
                        Console.WriteLine("Enter tablename:");
                        string tablename = Console.ReadLine();
                        selector.DisplayTableData(tablename);
                        break;
                    /*case 2:
                        {
                            Insert ins = new Insert(conn);
                            Console.WriteLine("Enter tablename:");
                            string tableName = Console.ReadLine();
                            Dictionary<string, object> data = new Dictionary<string, object>();
                            Console.WriteLine("Enter column values:");
                            Console.WriteLine("(Enter key-value pairs as column_name=value)");

                            while (true)
                            {
                                string input = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(input))
                                    break;

                                string[] parts = input.Split('=');
                                if (parts.Length == 2)
                                {
                                    string columnName = parts[0].Trim();
                                    string columnValueString = parts[1].Trim();
                                    object columnValue;

                                    if (int.TryParse(columnValueString, out int intValue))
                                    {
                                        columnValue = intValue;
                                    }
                                    else if (double.TryParse(columnValueString, out double doubleValue))
                                    {
                                        columnValue = doubleValue;
                                    }
                                    else if (DateTime.TryParse(columnValueString, out DateTime dateTimeValue))
                                    {
                                        columnValue = dateTimeValue;
                                    }
                                    else
                                    {
                                        columnValue = columnValueString;
                                    }


                                    data[columnName] = columnValue;
                                }

                                else
                                {
                                    Console.WriteLine("Invalid input format. Please enter column_name=value.");
                                }
                            }


                            ins.InsertData(tableName, data);
                            break;
                        }
                    case 3:
                        {
                            Selects sel = new Selects(conn);
                            Console.WriteLine("Enter query option (detailed_sales, total_sales_by_employee):");
                            string option = Console.ReadLine();
                            sel.SelectAllItemsByOption(option);
                            break;
                        }*/

                    default:
                        {
                            Console.WriteLine("Close Program");
                            break;
                        }
                }
            }
        }

    }
}