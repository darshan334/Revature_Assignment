using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Invoice_Management.Models
{
    public class PaymentMethod
    {
        [Key]
        public int MethodId { get; set; }

        public string? MethodName { get; set; }

        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
