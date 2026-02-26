using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Invoice_Management.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<Quotation>? Quotations { get; set; }
    }
}
