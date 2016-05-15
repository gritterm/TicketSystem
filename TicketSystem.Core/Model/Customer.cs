using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Core.Framework;

namespace TicketSystem.Core.Model
{
    public class Customer : Entity
    {
        //Event ID, name, date, location, price, # of tickets available, special notes 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Customer_ID { get; set; }

        [MaxLength(100)]
        [Required]
        public string Customer_Name { get; set; }

        [MaxLength(100)]
        [Required]
        public string Customer_Email { get; set; }

        public int? Billing_Address_ID { get; set; }

        public int? Shipping_Address_ID { get; set; }

        [ForeignKey("Billing_Address_ID")]
        public virtual Address BillingAddress { get; set; }

        [ForeignKey("Shipping_Address_ID")]
        public virtual Address ShippingAddress { get; set; }
    }
}
