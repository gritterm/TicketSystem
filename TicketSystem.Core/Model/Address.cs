using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TicketSystem.Core.Framework;

namespace TicketSystem.Core.Model
{
    public class Address : Entity
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Address_ID { get; set; }
        [MaxLength(100)]
        public string Address_1 { get; set; }
        [MaxLength(100)]
        public string Address_2 { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
        [MaxLength(100)]
        public string GeographicalRegion { get; set; }
        [MaxLength(100)]
        public string Country { get; set; }

    }
}
