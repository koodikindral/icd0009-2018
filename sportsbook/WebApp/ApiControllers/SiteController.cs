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
    public class SiteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SiteController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Site
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Site>>> GetSites()
        {
            return await _context.Sites.ToListAsync();
        }

        // GET: Site/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Site>> GetSite(int id)
        {
            var site = await _context.Sites.FindAsync(id);

            if (site == null)
            {
                return NotFound();
            }

            return site;
        }

        // PUT: Site/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSite(int id, Site site)
        {
            if (id != site.Id)
            {
                return BadRequest();
            }

            _context.Entry(site).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SiteExists(id))
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

        // POST: Site
        [HttpPost]
        public async Task<ActionResult<Site>> PostSite(Site site)
        {
            _context.Sites.Add(site);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSite", new { id = site.Id }, site);
        }

        // DELETE: Site/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Site>> DeleteSite(int id)
        {
            var site = await _context.Sites.FindAsync(id);
            if (site == null)
            {
                return NotFound();
            }

            _context.Sites.Remove(site);
            await _context.SaveChangesAsync();

            return site;
        }

        private bool SiteExists(int id)
        {
            return _context.Sites.Any(e => e.Id == id);
        }
    }
}
