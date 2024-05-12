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
    }
}
