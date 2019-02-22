using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain.Entity;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LedgerTypesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LedgerTypesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/LedgerTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LedgerType>>> GetLedgerTypes()
        {
            return await _context.LedgerTypes.ToListAsync();
        }

        // GET: api/LedgerTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LedgerType>> GetLedgerType(int id)
        {
            var ledgerType = await _context.LedgerTypes.FindAsync(id);

            if (ledgerType == null)
            {
                return NotFound();
            }

            return ledgerType;
        }

        // PUT: api/LedgerTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLedgerType(int id, LedgerType ledgerType)
        {
            if (id != ledgerType.Id)
            {
                return BadRequest();
            }

            _context.Entry(ledgerType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LedgerTypeExists(id))
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

        // POST: api/LedgerTypes
        [HttpPost]
        public async Task<ActionResult<LedgerType>> PostLedgerType(LedgerType ledgerType)
        {
            _context.LedgerTypes.Add(ledgerType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLedgerType", new { id = ledgerType.Id }, ledgerType);
        }

        // DELETE: api/LedgerTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LedgerType>> DeleteLedgerType(int id)
        {
            var ledgerType = await _context.LedgerTypes.FindAsync(id);
            if (ledgerType == null)
            {
                return NotFound();
            }

            _context.LedgerTypes.Remove(ledgerType);
            await _context.SaveChangesAsync();

            return ledgerType;
        }

        private bool LedgerTypeExists(int id)
        {
            return _context.LedgerTypes.Any(e => e.Id == id);
        }
    }
}
