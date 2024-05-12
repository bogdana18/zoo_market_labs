using System;
using System.Linq;
using lab_2_1.Models;
using Microsoft.EntityFrameworkCore;

namespace lab_2_1
{
    internal class CascadeDeleter
    {
        private readonly ZooContext _context;

        public CascadeDeleter(ZooContext context)
        {
            _context = context;
        }

        public void DeleteCustomer(int customerId)
        {
            var customer = _context.Customers.Include(c => c.Sales).FirstOrDefault(c => c.Customerid == customerId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                Console.WriteLine("Customer and related sales deleted successfully.");

                DisplayRemaining("Customers");
                DisplayRemaining("Sales");
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }
        }

        public void DeleteEmployee(int employeeId)
        {
            var employee = _context.Employees.Include(e => e.Sales).FirstOrDefault(e => e.Employeeid == employeeId);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
                Console.WriteLine("Employee and related sales deleted successfully.");

                DisplayRemaining("Employees");
                DisplayRemaining("Sales");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        public void DeletePet(int petId)
        {
            var pet = _context.Pets.Include(p => p.Sales).FirstOrDefault(p => p.Petid == petId);
            if (pet != null)
            {
                _context.Pets.Remove(pet);
                _context.SaveChanges();
                Console.WriteLine("Pet and related sales deleted successfully.");

                DisplayRemaining("Pets");
                DisplayRemaining("Sales");
            }
            else
            {
                Console.WriteLine("Pet not found.");
            }
        }

        public void DeleteProduct(int productId)
        {
            var product = _context.Products.Include(p => p.Sales).FirstOrDefault(p => p.Productid == productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                Console.WriteLine("Product and related sales deleted successfully.");

                DisplayRemaining("Products");
                DisplayRemaining("Sales");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        private void DisplayRemaining(string entityName)
        {
            switch (entityName.ToLower())
            {
                case "customers":
                    _context.Customers.ToList().ForEach(c => Console.WriteLine($"Customer ID: {c.Customerid}, Name: {c.Name}"));
                    break;
                case "employees":
                    _context.Employees.ToList().ForEach(e => Console.WriteLine($"Employee ID: {e.Employeeid}, Name: {e.Name}"));
                    break;
                case "pets":
                    _context.Pets.ToList().ForEach(p => Console.WriteLine($"Pet ID: {p.Petid}, Name: {p.Name}"));
                    break;
                case "products":
                    _context.Products.ToList().ForEach(p => Console.WriteLine($"Product ID: {p.Productid}, Name: {p.Name}"));
                    break;
                case "sales":
                    _context.Sales.ToList().ForEach(s => Console.WriteLine($"Sale ID: {s.Saleid}, Total Amount: {s.Totalamount}"));
                    break;
            }
        }
    }
}
