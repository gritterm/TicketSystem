using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
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

        [Required]
        public int Event_Type_ID { get; set; }

        [Required]
        public int Venue_ID { get; set; }

        [MaxLength(150)]
        public string Venue_Name { get; set; }

        [MaxLength(150)]
        public string Event_Name { get; set; }

        [MaxLength(150)]
        public string Event_Type_Name { get; set; }
        public DateTimeOffset? Event_Date { get; set; }

        [ForeignKey("Event_Type_ID")]
        public virtual EventType EventType { get; set; }
        [ForeignKey("Venue_ID")]
        public virtual Venue Venue { get; set; }

        public override bool PreSave(ModelContext context, EntityState state)
        {
            if(state == EntityState.Deleted)
            {
                //can't delete an event that has had ticket purchases made - set historical instead
                if(context.TicketPurchaseLines.Any(tpl => tpl.Event_ID == this.Event_ID))
                {
                    //set up an error message to return to the front end to set historical
                    //front end should disable deletion based on their being tpls
                    return false;
                }
            }
            if (context.Events.Any(ev => ev.Venue_ID == this.Venue_ID && ev.Event_Date == this.Event_Date))
            {
                //should be a resource for localization... in a hurry
                SetEntityError("Already an event at this venue for that date");
                return false;
            }
            if (!LoadNavigationProperties(context))
                return false;

            //in the future it could be worth checking to see if values changed if state is modified
            //to try and cut down 
            
            return true;
        }
        private bool LoadNavigationProperties(ModelContext context)
        {
            this.Venue = context.Venues.FirstOrDefault(venue => venue.Venue_ID == this.Venue_ID);
            this.EventType = context.EventTypes.FirstOrDefault(eventType => eventType.Event_Type_ID == this.Event_Type_ID);
            if (this.Venue == null)
            {
                SetEntityError("Invalid venue set for this event.");
                return false;
            }
            if(this.EventType == null)
            {
                SetEntityError("Invalid Event Type set for this event.");
                return false;
            }

            this.Venue_Name = this.Venue.Venue_Name;
            this.Event_Type_Name = this.EventType.Event_Type_Name;
            return true;
        }
    }
}
