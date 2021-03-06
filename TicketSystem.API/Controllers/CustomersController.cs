﻿using System;
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

namespace TicketSystem.API.Controllers
{
    [EnableQuery]
    public class CustomersController : ODataController
    {
        private ModelContext _mc = new ModelContext();

        private bool CustomerExists(int key)
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

        public async Task<IHttpActionResult> Post(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _mc.Customers.Add(customer);
            await _mc.SaveChangesAsync();
            return Created(customer);
        }

        public async Task<IHttpActionResult> Put([FromODataUri] int key, Customer update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.Customer_ID)
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
                if (!CustomerExists(key))
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