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
    public class TicketPurchase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Ticket_Purchase_ID { get; set; }
        public int Customer_ID { get; set; }
        public string Customer_Name { get; set; }
        public int Total { get; set; }
        public bool Paid { get; set; }
        public DateTimeOffset Date { get; set; }

        public virtual ObservableListSource<TicketPurchaseLine> TicketPurchaseLines { get; set; }
        // Customer Name, Total, Paid, Date, Credit Card # 
    }
}
