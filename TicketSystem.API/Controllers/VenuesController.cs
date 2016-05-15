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
    public class VenuesController : ODataController
    {
        private ModelContext _mc = new ModelContext();

        private bool VenueExists(int key)
        {
            return _mc.Venues.Any(p => p.Venue_ID == key);
        }

        public IQueryable<Venue> Get()
        {
            //if i had a multi-tenant db I would filter all results here
            return _mc.Venues;
        }

        public SingleResult<Venue> Get([FromODataUri] int key)
        {
            IQueryable<Venue> result = _mc.Venues.Where(p => p.Venue_ID == key);
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(Venue Venue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _mc.Venues.Add(Venue);
            await _mc.SaveChangesAsync();
            return Created(Venue);
        }

        public async Task<IHttpActionResult> Put([FromODataUri] int key, Venue update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.Venue_ID)
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
                if (!VenueExists(key))
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