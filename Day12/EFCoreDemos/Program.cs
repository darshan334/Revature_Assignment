using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using (var context = new CrmContext())
{
    // Insert 5 records only if table is empty
    if (!context.Customer.Any())
    {
        var customers = new List<Customer>
        {
            new Customer { Name = "Rahul", age = 25, Email = "rahul@gmail.com" },
            new Customer { Name = "Amit", age = 30, Email = "amit@gmail.com" },
            new Customer { Name = "Sneha", age = 28, Email = "sneha@gmail.com" },
            new Customer { Name = "Priya", age = 35, Email = "priya@gmail.com" },
            new Customer { Name = "Karan", age = 22, Email = "karan@gmail.com" }
        };

        context.Customer.AddRange(customers);
        context.SaveChanges();

        Console.WriteLine("5 Records Inserted Successfully\n");
    }

    // Update specific customer (Id = 1)
    var customer = context.Customer.FirstOrDefault(c => c.Id == 1);

    if (customer != null)
    {
        customer.Name = "Sai";
        context.SaveChanges();
        Console.WriteLine("Customer with Id 1 Updated Successfully\n");
    }

    // Fetch and display customers where age > 20
    var customersList = context.Customer
        .Where(e => e.age > 20)
        .ToList();

    Console.WriteLine("Customers with Age > 20:\n");

    foreach (var c in customersList)
    {
        Console.WriteLine($"Id: {c.Id} | Name: {c.Name} | Age: {c.age} | Email: {c.Email}");
    }
}

class CrmContext : DbContext
{
    public DbSet<Customer> Customer { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=DARSHAN;Database=CrmDB;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}

public class Order
{
    [Key]
    public int OrderId { get; set; }

    [Required]
    [MaxLength(100)]
    [MinLength(3)]
    public string Product { get; set; }

    [Required]
    [Precision(18, 2)]
    public decimal Price { get; set; }

    public int CustomerId { get; set; }

    [ForeignKey("CustomerId")]
    public Customer Customer { get; set; }
}

public class Customer
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public int age { get; set; }

    public string? Email { get; set; }
}
