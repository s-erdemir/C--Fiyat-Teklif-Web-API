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
    public class PreparedsController : ControllerBase
    {
        private readonly ContextDb _context;

        public PreparedsController(ContextDb context)
        {
            _context = context;
        }

        // GET: api/Prepareds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prepared>>> GetPrepareds()
        {
            return await _context.Prepareds.ToListAsync();
        }

        // GET: api/Prepareds/5
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<IEnumerable<Prepared>>> GetPrepared(int id)
        {
            var prepared = await _context.Prepareds.OrderBy(x => x.OfferId == id).ToListAsync();

            if (prepared == null)
            {
                return NotFound();
            }

            return prepared;
        }

        // PUT: api/Prepareds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> PutPrepared(int id, Prepared prepared)
        {
            if (id != prepared.Id)
            {
                return BadRequest();
            }

            _context.Entry(prepared).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreparedExists(id))
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

        // POST: api/Prepareds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("[action]")]
        public async Task<ActionResult<Prepared>> PostPrepared(Prepared prepared)
        {
            _context.Prepareds.Add(prepared);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrepared", new { id = prepared.Id }, prepared);
        }

        // DELETE: api/Prepareds/5
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeletePrepared(int id)
        {
            var prepared = await _context.Prepareds.FindAsync(id);
            if (prepared == null)
            {
                return NotFound();
            }

            _context.Prepareds.Remove(prepared);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PreparedExists(int id)
        {
            return _context.Prepareds.Any(e => e.Id == id);
        }
    }
}
