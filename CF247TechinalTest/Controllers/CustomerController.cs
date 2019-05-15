using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CF247TechinalTest.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CF247TechinalTest.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly CustomerContext _context;

        public CustomerController(CustomerContext context)
        {

            _context = context;

        }

        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerItem>>> GetCustomerItem()
        {
            return await _context.CustomerItems.ToListAsync();
        }

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerItem>> GetCustomerItem(long id)
        {
            var customerItem = await _context.CustomerItems.FindAsync(id);

            if (customerItem == null)
            {
                return NotFound();
            }

            return customerItem;
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<CustomerItem>> PostCustomerItem(CustomerItem item)
        {
            _context.CustomerItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomerItem), new { id = item.Id }, item);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerItem(long id, CustomerItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
