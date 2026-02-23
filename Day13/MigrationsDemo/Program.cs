﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using var context = new CrmDbContext();

// Ensure database + tables are created
context.Database.EnsureCreated();

// Insert sample data only if empty
if (!context.Customer.Any())
{
    var customer = new Customer
    {
        Name = "Rahul",
        Age = 25,
        Email = "rahul@gmail.com",
        Orders = new List<Order>
        {
            new Order { OrderDate = DateTime.Now, TotalAmount = 500 },
            new Order { OrderDate = DateTime.Now, TotalAmount = 1200 }
        }
    };

    context.Customer.Add(customer);
    context.SaveChanges();

    Console.WriteLine("Sample Customer and Orders Inserted.\n");
}

// Fetch customers with their orders
var customers = context.Customer
                       .Include(c => c.Orders)
                       .ToList();

foreach (var customer in customers)
{
    Console.WriteLine($"Customer ID: {customer.Id}");
    Console.WriteLine($"Name: {customer.Name}");
    Console.WriteLine($"Age: {customer.Age}");
    Console.WriteLine($"Email: {customer.Email}");

    foreach (var order in customer.Orders)
    {
        Console.WriteLine($"   Order ID: {order.OrderId}");
        Console.WriteLine($"   Order Date: {order.OrderDate}");
        Console.WriteLine($"   Total Amount: {order.TotalAmount}");
        Console.WriteLine();
    }

    Console.WriteLine("------------------------------------");
}

#region DbContext

class CrmDbContext : DbContext
{
    public DbSet<Customer> Customer { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=DARSHAN;Database=CrmDB_RelationshipDemo;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

#endregion

#region Entities

public class Customer
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public int Age { get; set; }

    public string? Email { get; set; }

    // Navigation property (1 → Many)
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}

public class Order
{
    public int OrderId { get; set; }

    public DateTime OrderDate { get; set; }

    public decimal TotalAmount { get; set; }

    // Foreign key
    public int CustomerId { get; set; }

    // Navigation property
    public Customer Customer { get; set; } = null!;
}

#endregion
