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

        public int? Buy_From_Address_ID { get; set; }
        public int? Pay_To_Address_ID { get; set; }

        [ForeignKey("Buy_From_Address_ID")]
        public virtual Address BuyFromAddress { get; set; }

        [ForeignKey("Pay_To_Address_ID")]
        public virtual Address PayToAddress { get; set; }
    }
}
