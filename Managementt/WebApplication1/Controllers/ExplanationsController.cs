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
    public class ExplanationsController : ControllerBase
    {
        private readonly ContextDb _context;

        public ExplanationsController(ContextDb context)
        {
            _context = context;
        }

        // GET: api/Explanations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Explanation>>> GetExplanations()
        {
            return await _context.Explanations.ToListAsync();
        }

        // GET: api/Explanations/5
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<IEnumerable<Explanation>>> GetExplanation(int id)
        {
            var explanation = await _context.Explanations.OrderBy(x => x.OfferId == id).ToListAsync();

            if (explanation == null)
            {
                return NotFound();
            }

            return explanation;
        }

        // PUT: api/Explanations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> PutExplanation(int id, Explanation explanation)
        {
            if (id != explanation.Id)
            {
                return BadRequest();
            }

            _context.Entry(explanation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExplanationExists(id))
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

        // POST: api/Explanations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("[action]")]
        public async Task<ActionResult<Explanation>> PostExplanation(Explanation explanation)
        {
            _context.Explanations.Add(explanation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExplanation", new { id = explanation.Id }, explanation);
        }

        // DELETE: api/Explanations/5
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteExplanation(int id)
        {
            var explanation = await _context.Explanations.FindAsync(id);
            if (explanation == null)
            {
                return NotFound();
            }

            _context.Explanations.Remove(explanation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExplanationExists(int id)
        {
            return _context.Explanations.Any(e => e.Id == id);
        }
    }
}
