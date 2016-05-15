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
    public class AddressesController : ODataController
    {
        private ModelContext _mc = new ModelContext();

        private bool AddresExists(int key)
        {
            return _mc.Addresses.Any(p => p.Address_ID == key);
        }

        public IQueryable<Address> Get()
        {
            //if i had a multi-tenant db I would filter all results here
            return _mc.Addresses;
        }

        public SingleResult<Address> Get([FromODataUri] int key)
        {
            IQueryable<Address> result = _mc.Addresses.Where(p => p.Address_ID == key);
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(Address Address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _mc.Addresses.Add(Address);
            await _mc.SaveChangesAsync();
            return Created(Address);
        }

        public async Task<IHttpActionResult> Put([FromODataUri] int key, Address update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.Address_ID)
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
                if (!AddresExists(key))
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