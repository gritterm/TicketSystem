using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TicketSystem.Core.Framework;

namespace TicketSystem.Core.Model
{
    public class Venue : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Venue_ID { get; set; }
        public int Address_ID { get; set; }
        public string Venue_Name { get; set; }

        public virtual Address Address { get; set; }
    }
}
