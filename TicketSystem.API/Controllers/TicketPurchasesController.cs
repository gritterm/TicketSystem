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
    public class TicketPurchasesController : ODataController
    {
        private ModelContext _mc = new ModelContext();

        private bool TicketPurchaseExists(int key)
        {
            return _mc.TicketPurchases.Any(p => p.Ticket_Purchase_ID == key);
        }

        public IQueryable<TicketPurchase> Get()
        {
            //if i had a multi-tenant db I would filter all results here
            return _mc.TicketPurchases;
        }

        public SingleResult<TicketPurchase> Get([FromODataUri] int key)
        {
            IQueryable<TicketPurchase> result = _mc.TicketPurchases.Where(p => p.Ticket_Purchase_ID == key);
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(TicketPurchase TicketPurchase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _mc.TicketPurchases.Add(TicketPurchase);
            await _mc.SaveChangesAsync();
            return Created(TicketPurchase);
        }

        public async Task<IHttpActionResult> Put([FromODataUri] int key, TicketPurchase update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.Ticket_Purchase_ID)
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
                if (!TicketPurchaseExists(key))
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