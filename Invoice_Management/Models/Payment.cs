using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoice_Management.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        public int InvoiceId { get; set; }

        public decimal PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }

        public int PaymentMethod { get; set; }

        public string? ReferenceNumber { get; set; }
        public DateTime ReceivedDate { get; set; }

        [ForeignKey("InvoiceId")]
        public Invoice? Invoice { get; set; }

        [ForeignKey("PaymentMethod")]
        public PaymentMethod? Method { get; set; }
    }
}
