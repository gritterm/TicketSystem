using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Core.Framework
{
    public abstract class Entity
    {
        public abstract bool PreSave();
    }
}
