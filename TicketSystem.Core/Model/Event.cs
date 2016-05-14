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
    public class Event : Entity
    {
        //Event ID, name, date, location, price, # of tickets available, special notes 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Event_ID { get; set; }
        public int Event_Type_ID { get; set; }
        public int Venue_ID { get; set; }
        [MaxLength(150)]
        public string Event_Name { get; set; }
        public DateTimeOffset Event_Date { get; set; }

        public virtual EventType EventType { get; set; }
        public virtual Venue Venue { get; set; }
    }
}
