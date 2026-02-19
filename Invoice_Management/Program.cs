using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Invoice_Management.Data;

namespace Invoice_Management
{
    class Program
    {
        static void Main()
        {
            using (var context = new InvoiceContext())
            {
                var invoices = context.Invoices
                    .Include(i => i.LineItems)
                    .Include(i => i.Payments)
                    .ToList();

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
