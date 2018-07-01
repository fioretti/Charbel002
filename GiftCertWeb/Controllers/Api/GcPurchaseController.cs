using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GiftCertWeb.Models;

namespace GiftCertWeb.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/GcPurchase")]
    public class GcPurchaseController : Controller
    {
        private readonly GiftCertificateDBContext _context;

        public GcPurchaseController(GiftCertificateDBContext context)
        {
            _context = context;
        }

        // GET: api/GcPurchase
        [HttpGet]
        public IEnumerable<GcPurchase> GetGcPurchase()
        {
            return _context.GcPurchase
                .Include(g => g.GiftCertNoNavigation);
        }

        // GET: api/GcPurchase/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGcPurchase([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gcPurchase = await _context.GcPurchase
                .Include(g => g.GiftCertNoNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
                 
            if (gcPurchase == null)
            {
                return NotFound();
            }

            return Ok(gcPurchase);
        }

        // PUT: api/GcPurchase/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGcPurchase([FromRoute] int id, [FromBody] GcPurchase gcPurchase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gcPurchase.Id)
            {
                return BadRequest();
            }

            _context.Entry(gcPurchase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GcPurchaseExists(id))
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

        // POST: api/GcPurchase
        [HttpPost]
        public async Task<IActionResult> PostGcPurchase([FromBody] GcPurchase gcPurchase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.GcPurchase.Add(gcPurchase);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGcPurchase", new { id = gcPurchase.Id }, gcPurchase);
        }

        // DELETE: api/GcPurchase/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGcPurchase([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gcPurchase = await _context.GcPurchase.SingleOrDefaultAsync(m => m.Id == id);
            if (gcPurchase == null)
            {
                return NotFound();
            }

            _context.GcPurchase.Remove(gcPurchase);
            await _context.SaveChangesAsync();

            return Ok(gcPurchase);
        }

        private bool GcPurchaseExists(int id)
        {
            return _context.GcPurchase.Any(e => e.Id == id);
        }
    }
}