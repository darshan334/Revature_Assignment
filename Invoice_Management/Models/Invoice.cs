using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Invoice_Management.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }

        public string? InvoiceNumber { get; set; }
        public string? Status { get; set; }

        public int CustomerId { get; set; }
        public int QuoteId { get; set; }

        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }

        public decimal SubTotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Discount { get; set; }
        public decimal GrandTotal { get; set; }

        public DateTime CreatedDate { get; set; }

        public ICollection<InvoiceLineItem> LineItems { get; set; } = new List<InvoiceLineItem>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
