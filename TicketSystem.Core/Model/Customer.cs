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
        public string Customer_Name { get; set; }
        public virtual Address Billing_Address { get; set; }
        public virtual Address Shipping_Address { get; set; }
    }
}
