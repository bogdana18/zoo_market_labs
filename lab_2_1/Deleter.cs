using System;
using System.Linq;
using lab_2_1.Models;
using Microsoft.EntityFrameworkCore;

namespace lab_2_1
{
    internal class Deleter
    {
        private readonly ZooContext _context;

        public Deleter(ZooContext context)
        {
            _context = context;
        }

        public void DeleteEmployee()
        {
            Console.WriteLine("Enter Employee ID to delete:");
            int id = Convert.ToInt32(Console.ReadLine());
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
                Console.WriteLine("Employee deleted successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        public void DeleteCustomer()
        {
            Console.WriteLine("Enter Customer ID to delete:");
            int id = Convert.ToInt32(Console.ReadLine());
            var customer = _context.Customers.Find(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                Console.WriteLine("Customer deleted successfully.");
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }
        }

        public void DeletePet()
        {
            Console.WriteLine("Enter Pet ID to delete:");
            int id = Convert.ToInt32(Console.ReadLine());
            var pet = _context.Pets.Find(id);
            if (pet != null)
            {
                _context.Pets.Remove(pet);
                _context.SaveChanges();
                Console.WriteLine("Pet deleted successfully.");
            }
            else
            {
                Console.WriteLine("Pet not found.");
            }
        }

        public void DeleteProduct()
        {
            Console.WriteLine("Enter Product ID to delete:");
            int id = Convert.ToInt32(Console.ReadLine());
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                Console.WriteLine("Product deleted successfully.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        public void DeleteSale()
        {
            Console.WriteLine("Enter Sale ID to delete:");
            int id = Convert.ToInt32(Console.ReadLine());
            var sale = _context.Sales.Find(id);
            if (sale != null)
            {
                _context.Sales.Remove(sale);
                _context.SaveChanges();
                Console.WriteLine("Sale deleted successfully.");
            }
            else
            {
                Console.WriteLine("Sale not found.");
            }
        }
    }
}
