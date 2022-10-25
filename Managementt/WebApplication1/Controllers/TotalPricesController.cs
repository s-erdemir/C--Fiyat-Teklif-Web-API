using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TotalPricesController : ControllerBase
    {
        private readonly ContextDb _context;

        public TotalPricesController(ContextDb context)
        {
            _context = context;
        }

        // GET: api/TotalPrices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TotalPrice>>> GetTotalPrices()
        {
            return await _context.TotalPrices.ToListAsync();
        }

        // GET: api/TotalPrices/5
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<IEnumerable<TotalPrice>>> GetTotalPrice(int id)
        {
            var totalPrice = await _context.TotalPrices.OrderBy(x => x.OfferId == id).ToListAsync();

            if (totalPrice == null)
            {
                return NotFound();
            }

            return totalPrice;
        }

        // PUT: api/TotalPrices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> PutTotalPrice(int id, TotalPrice totalPrice)
        {
            if (id != totalPrice.Id)
            {
                return BadRequest();
            }

            _context.Entry(totalPrice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TotalPriceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TotalPrices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("[action]")]
        public async Task<ActionResult<TotalPrice>> PostTotalPrice(TotalPrice totalPrice)
        {
            _context.TotalPrices.Add(totalPrice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTotalPrice", new { id = totalPrice.Id }, totalPrice);
        }

        // DELETE: api/TotalPrices/5
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteTotalPrice(int id)
        {
            var totalPrice = await _context.TotalPrices.FindAsync(id);
            if (totalPrice == null)
            {
                return NotFound();
            }

            _context.TotalPrices.Remove(totalPrice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TotalPriceExists(int id)
        {
            return _context.TotalPrices.Any(e => e.Id == id);
        }
    }
}
