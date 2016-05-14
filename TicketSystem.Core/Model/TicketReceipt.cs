using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TicketSystem.Core.Framework;

namespace TicketSystem.Core.Model
{
    public class TicketReceipt : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Ticket_Receipt_ID { get; set; }

        public int Ticket_Quantity { get; set; }
        public int Venue_ID { get; set; }
        public int Event_ID { get; set; }

        public virtual Venue Venue { get; set; }
        public virtual Event Event { get; set; }

    }
}
