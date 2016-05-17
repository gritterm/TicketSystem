using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Core.Interfaces;

namespace TicketSystem.Core.Framework
{
    public abstract class Entity : IEntity
    {
        [NotMapped]
        public bool SaveFailure { get; set; }

        [NotMapped]
        public string SaveFailureMessage { get; set; }

        public void SetEntityError(string errorMessage)
        {
            this.SaveFailureMessage = errorMessage;
            this.SaveFailure = true;
        }

        public virtual bool PreSave(ModelContext context, EntityState state)
        {
            return true;
        }
    }
}
