using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoice_Management.Models
{
    public class InvoiceLineItem
    {
        [Key]
        public int LineItemId { get; set; }

        public int InvoiceId { get; set; }

        public string? Description { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public decimal LineTotal { get; set; }

        [ForeignKey("InvoiceId")]
        public Invoice? Invoice { get; set; }
    }
}
