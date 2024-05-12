using System;
using lab_2_1.Models;
using Microsoft.EntityFrameworkCore;

namespace lab_2_1
{
    internal class Updater
    {
        private readonly ZooContext _context;

        public Updater(ZooContext context)
        {
            _context = context;
        }

        public void UpdateCustomer()
        {
            Console.WriteLine("Enter Customer ID to update:");
            int id = Convert.ToInt32(Console.ReadLine());
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                Console.WriteLine("Customer not found.");
                return;
            }

            Console.WriteLine("Enter new Name (leave empty to keep current):");
            string name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name)) customer.Name = name;

            Console.WriteLine("Enter new Email (leave empty to keep current):");
            string email = Console.ReadLine();
            if (!string.IsNullOrEmpty(email)) customer.Email = email;

            Console.WriteLine("Enter new Phone (leave empty to keep current):");
            string phone = Console.ReadLine();
            if (!string.IsNullOrEmpty(phone)) customer.Phone = phone;

            Console.WriteLine("Enter new Address (leave empty to keep current):");
            string address = Console.ReadLine();
            if (!string.IsNullOrEmpty(address)) customer.Address = address;

            _context.SaveChanges();
            Console.WriteLine("Customer updated successfully.");
        }

        public void UpdateEmployee()
        {
            Console.WriteLine("Enter Employee ID to update:");
            int id = Convert.ToInt32(Console.ReadLine());
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                Console.WriteLine("Employee not found.");
                return;
            }

            Console.WriteLine("Enter new Name (leave empty to keep current):");
            string name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name)) employee.Name = name;

            Console.WriteLine("Enter new Position (leave empty to keep current):");
            string position = Console.ReadLine();
            if (!string.IsNullOrEmpty(position)) employee.Position = position;

            Console.WriteLine("Enter new Email (leave empty to keep current):");
            string email = Console.ReadLine();
            if (!string.IsNullOrEmpty(email)) employee.Email = email;

            Console.WriteLine("Enter new Salary (leave empty to keep current):");
            if (double.TryParse(Console.ReadLine(), out double salary) && salary > 0) employee.Salary = salary;

            _context.SaveChanges();
            Console.WriteLine("Employee updated successfully.");
        }

        public void UpdatePet()
        {
            Console.WriteLine("Enter Pet ID to update:");
            int id = Convert.ToInt32(Console.ReadLine());
            var pet = _context.Pets.Find(id);
            if (pet == null)
            {
                Console.WriteLine("Pet not found.");
                return;
            }

            Console.WriteLine("Enter new Species (leave empty to keep current):");
            string species = Console.ReadLine();
            if (!string.IsNullOrEmpty(species)) pet.Species = species;

            Console.WriteLine("Enter new Name (leave empty to keep current):");
            string name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name)) pet.Name = name;

            Console.WriteLine("Enter new Breed (leave empty to keep current):");
            string breed = Console.ReadLine();
            if (!string.IsNullOrEmpty(breed)) pet.Breed = breed;

            Console.WriteLine("Enter new Health Status (leave empty to keep current):");
            string healthStatus = Console.ReadLine();
            if (!string.IsNullOrEmpty(healthStatus)) pet.Healthstatus = healthStatus;

            _context.SaveChanges();
            Console.WriteLine("Pet updated successfully.");
        }

        public void UpdateProduct()
        {
            Console.WriteLine("Enter Product ID to update:");
            int id = Convert.ToInt32(Console.ReadLine());
            var product = _context.Products.Find(id);
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            Console.WriteLine("Enter new Name (leave empty to keep current):");
            string name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name)) product.Name = name;

            Console.WriteLine("Enter new Price (leave empty to keep current):");
            if (double.TryParse(Console.ReadLine(), out double price) && price > 0) product.Price = price;

            Console.WriteLine("Enter new Category (leave empty to keep current):");
            string category = Console.ReadLine();
            if (!string.IsNullOrEmpty(category)) product.Category = category;

            Console.WriteLine("Enter new Stock Quantity (leave empty to keep current):");
            if (int.TryParse(Console.ReadLine(), out int stockQuantity) && stockQuantity >= 0) product.Stockquantity = stockQuantity;

            _context.SaveChanges();
            Console.WriteLine("Product updated successfully.");
        }

        public void UpdateSale()
        {
            Console.WriteLine("Enter Sale ID to update:");
            int id = Convert.ToInt32(Console.ReadLine());
            var sale = _context.Sales.Include(s => s.Customer).Include(s => s.Employee).Include(s => s.Pet).Include(s => s.Product).FirstOrDefault(s => s.Saleid == id);
            if (sale == null)
            {
                Console.WriteLine("Sale not found.");
                return;
            }

            Console.WriteLine("Enter new Total Amount (leave empty to keep current):");
            if (double.TryParse(Console.ReadLine(), out double totalAmount) && totalAmount > 0) sale.Totalamount = totalAmount;

            Console.WriteLine("Enter new Payment Method (leave empty to keep current):");
            string paymentMethod = Console.ReadLine();
            if (!string.IsNullOrEmpty(paymentMethod)) sale.Paymentmethod = paymentMethod;

            _context.SaveChanges();
            Console.WriteLine("Sale updated successfully.");
        }
    }
}
