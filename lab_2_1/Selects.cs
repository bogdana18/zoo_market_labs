using System;
using lab_2_1.Models;
using Microsoft.EntityFrameworkCore;

namespace lab_2_1
{
    internal class Selects
    {
        private readonly ZooContext _context;

        public Selects(ZooContext context)
        {
            _context = context;
        }

        public void DisplayTableData(string tableName)
        {
            switch (tableName.ToLower())
            {
                case "customer":
                    DisplayCustomers();
                    break;
                case "employee":
                    DisplayEmployees();
                    break;
                case "pet":
                    DisplayPets();
                    break;
                case "product":
                    DisplayProducts();
                    break;
                case "sale":
                    DisplaySales();
                    break;
                default:
                    Console.WriteLine("No valid table name provided.");
                    break;
            }
        }

        private void DisplayCustomers()
        {
            foreach (var customer in _context.Customers)
            {
                Console.WriteLine($"ID: {customer.Customerid}, Name: {customer.Name}, Email: {customer.Email}, Phone: {customer.Phone}, Address: {customer.Address}");
            }
        }

        private void DisplayEmployees()
        {
            foreach (var employee in _context.Employees)
            {
                Console.WriteLine($"ID: {employee.Employeeid}, Name: {employee.Name}, Position: {employee.Position}, Email: {employee.Email}, Salary: {employee.Salary}");
            }
        }

        private void DisplayPets()
        {
            foreach (var pet in _context.Pets)
            {
                Console.WriteLine($"ID: {pet.Petid}, Species: {pet.Species}, Name: {pet.Name}, Breed: {pet.Breed}, Birthdate: {pet.Birthdate?.ToShortDateString()}, Health Status: {pet.Healthstatus}");
            }
        }

        private void DisplayProducts()
        {
            foreach (var product in _context.Products)
            {
                Console.WriteLine($"ID: {product.Productid}, Name: {product.Name}, Price: {product.Price}, Category: {product.Category}, Stock Quantity: {product.Stockquantity}");
            }
        }

        private void DisplaySales()
        {
            foreach (var sale in _context.Sales.Include(s => s.Customer).Include(s => s.Employee).Include(s => s.Pet).Include(s => s.Product))
            {
                Console.WriteLine($"Sale ID: {sale.Saleid}, Customer: {sale.Customer?.Name}, Employee: {sale.Employee?.Name}, Pet: {sale.Pet?.Name}, Product: {sale.Product?.Name}, Sale Date: {sale.Saledate?.ToShortDateString()}, Total Amount: {sale.Totalamount}, Payment Method: {sale.Paymentmethod}");
            }
        }

        public void AddCustomer()
        {
            Console.WriteLine("Enter Customer Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Email:");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Phone:");
            string phone = Console.ReadLine();
            Console.WriteLine("Enter Address:");
            string address = Console.ReadLine();

            var customer = new Customer
            {
                Name = name,
                Email = email,
                Phone = phone,
                Address = address
            };

            _context.Customers.Add(customer);
            _context.SaveChanges();
            Console.WriteLine("New customer added successfully.");
        }

        public void AddEmployee()
        {
            Console.WriteLine("Enter Employee Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Position:");
            string position = Console.ReadLine();
            Console.WriteLine("Enter Email:");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Salary:");
            double salary = Convert.ToDouble(Console.ReadLine());

            var employee = new Employee
            {
                Name = name,
                Position = position,
                Email = email,
                Salary = salary
            };

            _context.Employees.Add(employee);
            _context.SaveChanges();
            Console.WriteLine("New employee added successfully.");
        }

        public void AddPet()
        {
            Console.WriteLine("Enter Species:");
            string species = Console.ReadLine();
            Console.WriteLine("Enter Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Breed:");
            string breed = Console.ReadLine();
            Console.WriteLine("Enter Birthdate (yyyy-mm-dd):");
            DateOnly birthdate = DateOnly.Parse(Console.ReadLine());
            Console.WriteLine("Enter Health Status:");
            string healthStatus = Console.ReadLine();

            var pet = new Pet
            {
                Species = species,
                Name = name,
                Breed = breed,
                Birthdate = birthdate,
                Healthstatus = healthStatus
            };

            _context.Pets.Add(pet);
            _context.SaveChanges();
            Console.WriteLine("New pet added successfully.");
        }

        public void AddProduct()
        {
            Console.WriteLine("Enter Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Price:");
            double price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Category:");
            string category = Console.ReadLine();
            Console.WriteLine("Enter Stock Quantity:");
            int stockQuantity = Convert.ToInt32(Console.ReadLine());

            var product = new Product
            {
                Name = name,
                Price = price,
                Category = category,
                Stockquantity = stockQuantity
            };

            _context.Products.Add(product);
            _context.SaveChanges();
            Console.WriteLine("New product added successfully.");
        }

        public void AddSale()
        {
            Console.WriteLine("Enter Customer ID:");
            int customerId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Employee ID:");
            int employeeId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Pet ID:");
            int petId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Product ID:");
            int productId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Sale Date (yyyy-mm-dd):");
            DateOnly saleDate = DateOnly.Parse(Console.ReadLine());
            Console.WriteLine("Enter Total Amount:");
            double totalAmount = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Payment Method:");
            string paymentMethod = Console.ReadLine();

            var sale = new Sale
            {
                Customerid = customerId,
                Employeeid = employeeId,
                Petid = petId,
                Productid = productId,
                Saledate = saleDate,
                Totalamount = totalAmount,
                Paymentmethod = paymentMethod
            };

            _context.Sales.Add(sale);
            _context.SaveChanges();
            Console.WriteLine("New sale added successfully.");
        }
    }
}
