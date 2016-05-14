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
    public class TicketPurchaseLine : Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Ticket_Purchase_Line_ID { get; set; }
        public int Ticket_Purchase_ID { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Event_ID { get; set; }

        public virtual Event Event { get; set; }
        //Ticket Purchase Line _ID, Ticket_Purchase_ID, Event ID, Qty, Price 
    }
}
