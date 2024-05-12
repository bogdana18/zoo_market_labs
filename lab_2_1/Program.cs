using lab_2_1.Models;

namespace lab_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ZooContext())
            {

                context.Database.EnsureCreated();

                /*Console.WriteLine("Select an option from the list below");
                Console.WriteLine("0 - Get all tables");*/
                Console.WriteLine("1 - Select Table info");
                Console.WriteLine("2 - Add new Customer");
                Console.WriteLine("3 - Add new Employee");
                Console.WriteLine("4 - Add new Pet");
                Console.WriteLine("5 - Add new Product");
                Console.WriteLine("6 - Add new Sale");
                Console.WriteLine("------Cascade Deleting options------");
                Console.WriteLine("7 - Delete a Customer");
                Console.WriteLine("8 - Delete an Employee");
                Console.WriteLine("9 - Delete a Pet");
                Console.WriteLine("10 - Delete a Product");
                Console.WriteLine("------Updating options------");
                Console.WriteLine("12 - Update a Customer");
                Console.WriteLine("13 - Update an Employee");
                Console.WriteLine("14 - Update a Pet");
                Console.WriteLine("15 - Update a Product");
                Console.WriteLine("16 - Update an Sale");
                Console.WriteLine("------deleter options------");
                Console.WriteLine("17 - delete a Customer");
                Console.WriteLine("18 - delete an Employee");
                Console.WriteLine("19 - delete a Pet");
                Console.WriteLine("20 - delete a Product");
                Console.WriteLine("21 - delete an Sale");

                int swt = Convert.ToInt32(Console.ReadLine());

                Selects selector = new Selects(context);
                Updater updater = new Updater(context);
                Deleter deleter = new Deleter(context);
                CascadeDeleter cascadedDeleter = new CascadeDeleter(context);

                switch (swt)
                {
                    case 1:
                        Console.WriteLine("Enter tablename:");
                        string tablename = Console.ReadLine();
                        selector.DisplayTableData(tablename);
                        break;
                    case 2:
                        selector.AddCustomer();
                        break;
                    case 3:
                        selector.AddEmployee();
                        break;
                    case 4:
                        selector.AddPet();
                        break;
                    case 5:
                        selector.AddProduct();
                        break;
                    case 6:
                        selector.AddSale();
                        break;
                    case 7:
                        Console.WriteLine("Enter Customer ID to delete with related sales:");
                        int customerId = Convert.ToInt32(Console.ReadLine());
                        cascadedDeleter.DeleteCustomer(customerId);
                        break;
                    case 8:
                        Console.WriteLine("Enter Employee ID to delete with related records:");
                        int employeeId = Convert.ToInt32(Console.ReadLine());
                        cascadedDeleter.DeleteEmployee(employeeId);
                        break;
                    case 9:
                        Console.WriteLine("Enter Pet ID to delete with related records:");
                        int petId = Convert.ToInt32(Console.ReadLine());
                        cascadedDeleter.DeletePet(petId);
                        break;
                    case 10:
                        Console.WriteLine("Enter Product ID to delete with related records:");
                        int productId = Convert.ToInt32(Console.ReadLine());
                        cascadedDeleter.DeletePet(productId);
                        break;
                    case 12:
                        updater.UpdateCustomer();
                        break;
                    case 13:
                        updater.UpdateEmployee();
                        break;
                    case 14:
                        updater.UpdatePet();
                        break;
                    case 15:
                        updater.UpdateProduct();
                        break;
                    case 16:
                        updater.UpdateSale();
                        break;
                    case 17:
                        deleter.DeleteCustomer();
                        break;
                    case 18:
                        deleter.DeleteEmployee();
                        break;
                    case 19:
                        deleter.DeletePet();
                        break;
                    case 20:
                        deleter.DeleteProduct();
                        break;
                    case 21:
                        deleter.DeleteSale();
                        break;
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