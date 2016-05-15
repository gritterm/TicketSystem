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
    public class TicketPurchaseLinesController : ODataController
    {
        private ModelContext _mc = new ModelContext();

        private bool TicketPurchaseLineExists(int key)
        {
            return _mc.TicketPurchaseLines.Any(p => p.Ticket_Purchase_Line_ID == key);
        }

        public IQueryable<TicketPurchaseLine> Get()
        {
            //if i had a multi-tenant db I would filter all results here
            return _mc.TicketPurchaseLines;
        }

        public SingleResult<TicketPurchaseLine> Get([FromODataUri] int key)
        {
            IQueryable<TicketPurchaseLine> result = _mc.TicketPurchaseLines.Where(p => p.Ticket_Purchase_Line_ID == key);
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(TicketPurchaseLine TicketPurchaseLine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _mc.TicketPurchaseLines.Add(TicketPurchaseLine);
            await _mc.SaveChangesAsync();
            return Created(TicketPurchaseLine);
        }

        public async Task<IHttpActionResult> Put([FromODataUri] int key, TicketPurchaseLine update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.Ticket_Purchase_Line_ID)
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
                if (!TicketPurchaseLineExists(key))
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