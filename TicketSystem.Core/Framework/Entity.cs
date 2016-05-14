using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Core.Interfaces;

namespace TicketSystem.Core.Framework
{
    public abstract class Entity : IEntity
    {
        public virtual bool PreSave(EntityState state)
        {
            return true;
        }
    }
}
