using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Invoice_Management.Data;
using Invoice_Management.Models;

namespace Invoice_Management
{
    class Program
    {
        static void Main()
        {
            using (var context = new InvoiceContext())
            {
                // Insert Customer
                var customer = new Customer
                {
                    CustomerName = "Hulk",
                    Email = "hulk@gmail.com",
                    Phone = "9876543210",
                    CreatedDate = DateTime.Now
                };

                context.Customers.Add(customer);
                context.SaveChanges();

                // Insert Quotation linked to Customer
                var quotation = new Quotation
                {
                    QuoteNumber = "Q-1004",
                    CustomerId = customer.CustomerId,
                    QuoteDate = DateTime.Now,
                    TotalAmount = 90000
                };

                context.Quotations.Add(quotation);
                context.SaveChanges();

                Console.WriteLine("Customer and Quotation inserted successfully.");
            }


            using (var context = new InvoiceContext())
            {
                var invoices = context.Invoices
                    .Include(i => i.LineItems)
                    .Include(i => i.Payments);

                foreach (var invoice in invoices)
                {
                    Console.WriteLine($"Invoice: {invoice.InvoiceNumber} | Status: {invoice.Status}");

                    foreach (var item in invoice.LineItems)
                    {
                        Console.WriteLine($"  Item: {item.Description} | Total: {item.LineTotal}");
                    }

                    foreach (var payment in invoice.Payments)
                    {
                        Console.WriteLine($"  Payment: {payment.PaymentAmount}");
                    }

                    Console.WriteLine("----------------------------------");
                }
            }
        }
    }
}
