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
    public class VendorsController : ODataController
    {
        private ModelContext _mc = new ModelContext();

        private bool VendorExists(int key)
        {
            return _mc.Vendors.Any(p => p.Vendor_ID == key);
        }

        public IQueryable<Vendor> Get()
        {
            //if i had a multi-tenant db I would filter all results here
            return _mc.Vendors;
        }

        public SingleResult<Vendor> Get([FromODataUri] int key)
        {
            IQueryable<Vendor> result = _mc.Vendors.Where(p => p.Vendor_ID == key);
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(Vendor Vendor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _mc.Vendors.Add(Vendor);
            await _mc.SaveChangesAsync();
            return Created(Vendor);
        }

        public async Task<IHttpActionResult> Put([FromODataUri] int key, Vendor update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.Vendor_ID)
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
                if (!VendorExists(key))
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