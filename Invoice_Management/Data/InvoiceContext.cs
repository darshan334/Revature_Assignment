using Microsoft.EntityFrameworkCore;
using Invoice_Management.Models;

namespace Invoice_Management.Data
{
    public class InvoiceContext : DbContext
    {
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLineItem> InvoiceLineItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=DARSHAN;Database=Invoice_Management;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>().ToTable("Invoice");
            modelBuilder.Entity<InvoiceLineItem>().ToTable("InvoiceLineItem");
            modelBuilder.Entity<Payment>().ToTable("Payment");
            modelBuilder.Entity<PaymentMethod>().ToTable("PaymentMethod");
        }

    }
}
