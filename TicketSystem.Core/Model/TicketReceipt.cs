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
        public int? Venue_ID { get; set; }
        public int? Event_ID { get; set; }
        public int? Vendor_ID { get; set; }

        [ForeignKey("Vendor_ID")]
        public virtual Vendor Vendor { get; set; }
        [ForeignKey("Venue_ID")]
        public virtual Venue Venue { get; set; }
        [ForeignKey("Event_ID")]
        public virtual Event Event { get; set; }

    }
}
