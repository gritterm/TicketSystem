using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Core.Interfaces
{
    public interface IEntity
    {
        bool SaveFailure { get; set; }
        string SaveFailureMessage { get; set; }
        bool PreSave(ModelContext context, EntityState state);

    }
}
