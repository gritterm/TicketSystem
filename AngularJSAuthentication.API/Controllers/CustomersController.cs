using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.OData;
using TicketSystem.Core;
using TicketSystem.Core.Model;

namespace AngularJSAuthentication.API.Controllers
{
    [EnableQuery]
    public class CustomersController : ODataController
    {
        private ModelContext _mc = new ModelContext();

        private bool ProductExists(int key)
        {
            return _mc.Customers.Any(p => p.Customer_ID == key);
        }

        public IQueryable<Customer> Get()
        {
            //if i had a multi-tenant db I would filter all results here
            return _mc.Customers;
        }

        public SingleResult<Customer> Get([FromODataUri] int key)
        {
            IQueryable<Customer> result = _mc.Customers.Where(p => p.Customer_ID == key);
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(Customer product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _mc.Customers.Add(product);
            await _mc.SaveChangesAsync();
            return Created(product);
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