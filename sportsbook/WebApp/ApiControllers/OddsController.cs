using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain.Entity;
using Domain.Entity.Sportsbook;

namespace WebApp.ApiControllers
{
    [Route("[controller]")]
    [ApiController]
    public class OddsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OddsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Odds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Odds>>> GetOdds()
        {
            return await _context.Odds.ToListAsync();
        }

        // GET: Odds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Odds>> GetOdds(int id)
        {
            var odds = await _context.Odds.FindAsync(id);

            if (odds == null)
            {
                return NotFound();
            }

            return odds;
        }

        // PUT: Odds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOdds(int id, Odds odds)
        {
            if (id != odds.Id)
            {
                return BadRequest();
            }

            _context.Entry(odds).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OddsExists(id))
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

        // POST: Odds
        [HttpPost]
        public async Task<ActionResult<Odds>> PostOdds(Odds odds)
        {
            _context.Odds.Add(odds);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOdds", new { id = odds.Id }, odds);
        }

        // DELETE: Odds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Odds>> DeleteOdds(int id)
        {
            var odds = await _context.Odds.FindAsync(id);
            if (odds == null)
            {
                return NotFound();
            }

            _context.Odds.Remove(odds);
            await _context.SaveChangesAsync();

            return odds;
        }

        private bool OddsExists(int id)
        {
            return _context.Odds.Any(e => e.Id == id);
        }
    }
}
