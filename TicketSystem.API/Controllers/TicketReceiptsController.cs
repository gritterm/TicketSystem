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
    public class TicketReceiptsController : ODataController
    {
        private ModelContext _mc = new ModelContext();

        private bool TicketReceiptExists(int key)
        {
            return _mc.TicketReceipts.Any(p => p.Ticket_Receipt_ID == key);
        }

        public IQueryable<TicketReceipt> Get()
        {
            //if i had a multi-tenant db I would filter all results here
            return _mc.TicketReceipts;
        }

        public SingleResult<TicketReceipt> Get([FromODataUri] int key)
        {
            IQueryable<TicketReceipt> result = _mc.TicketReceipts.Where(p => p.Ticket_Receipt_ID == key);
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(TicketReceipt TicketReceipt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _mc.TicketReceipts.Add(TicketReceipt);
            await _mc.SaveChangesAsync();
            return Created(TicketReceipt);
        }

        public async Task<IHttpActionResult> Put([FromODataUri] int key, TicketReceipt update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.Ticket_Receipt_ID)
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
                if (!TicketReceiptExists(key))
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