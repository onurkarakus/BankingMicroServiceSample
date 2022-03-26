using BankingMicroServiceSample.Common.Entities.Customers;
using BankingMicroServiceSample.CustomerService.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankingMicroServiceSample.CustomerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerServiceContext customerServiceContext;

        public CustomerController(CustomerServiceContext customerServiceContext)
        {
            this.customerServiceContext = customerServiceContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await customerServiceContext.Customers.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            customerServiceContext.Add(customer);
            await customerServiceContext.SaveChangesAsync();

            return CreatedAtAction("PostCustomer", new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(Customer customer)
        {
            customerServiceContext.Entry(customer).State = EntityState.Modified;
            await customerServiceContext.SaveChangesAsync();

            return NoContent();
        }

    }
}
