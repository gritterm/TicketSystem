using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Core.Model
{
    public class EventType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Event_Type_ID { get; set; }
        public string Event_Type_Name { get; set; }
    }
}
