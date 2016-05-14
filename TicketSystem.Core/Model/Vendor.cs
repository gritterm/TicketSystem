using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TicketSystem.Core.Framework;

namespace TicketSystem.Core.Model
{
    public class Vendor : Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Vendor_ID { get; set; }

        [MaxLength(100)]
        public string Vendor_Name { get; set; }

        public virtual Address Buy_From_Address { get; set; }

        public virtual Address Pay_To_Address { get; set; }
    }
}
