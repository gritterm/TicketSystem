using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.OData;
using TicketSystem.Core;
using TicketSystem.Core.Model;

namespace TicketSystem.Server.Controllers
{
    [EnableQuery]
    public class EventTypesController : ODataController
    {
        private ModelContext _mc = new ModelContext();

        private bool EventTypeExists(int key)
        {
            return _mc.EventTypes.Any(p => p.Event_Type_ID == key);
        }

        public IQueryable<EventType> Get()
        {
            //if i had a multi-tenant db I would filter all results here
            return _mc.EventTypes;
        }

        public SingleResult<EventType> Get([FromODataUri] int key)
        {
            IQueryable<EventType> result = _mc.EventTypes.Where(p => p.Event_Type_ID == key);
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(EventType EventType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _mc.EventTypes.Add(EventType);
            await _mc.SaveChangesAsync();
            return Created(EventType);
        }

        public async Task<IHttpActionResult> Put([FromODataUri] int key, EventType update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.Event_Type_ID)
            {
                return BadRequest();
            }
            _mc.Entry(update).State = EntityState.Modified;
            try
            {
                await _mc.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventTypeExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(update);
        }
        /// <summary>
        /// Make sure this happens because contexts are huge memory leaks
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            _mc.Dispose();
            base.Dispose(disposing);
        }
    }
}