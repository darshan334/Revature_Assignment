using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Invoice_Management.Models
{
    public class Quotation
    {
        [Key]
        public int QuoteId { get; set; }
        public string QuoteNumber { get; set; } = string.Empty;
        public int CustomerId { get; set; }
        public DateTime QuoteDate { get; set; }
        public decimal TotalAmount { get; set; }

        public Customer? Customer { get; set; }
    }
}
