using System;
using System.Collections.Generic;
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
    public class EventsController : ODataController
    {
        private ModelContext _mc = new ModelContext();

        private bool EventExists(int key)
        {
            return _mc.Events.Any(p => p.Event_ID == key);
        }

        public IQueryable<Event> Get()
        {
            //if i had a multi-tenant db I would filter all results here
            return _mc.Events;
        }

        public SingleResult<Event> Get([FromODataUri] int key)
        {
            IQueryable<Event> result = _mc.Events.Where(p => p.Event_ID == key);
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(Event Event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _mc.Events.Add(Event);
            await _mc.SaveChangesAsync();
            return Created(Event);
        }

        public async Task<IHttpActionResult> Put([FromODataUri] int key, Event update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.Event_ID)
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
                if (!EventExists(key))
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