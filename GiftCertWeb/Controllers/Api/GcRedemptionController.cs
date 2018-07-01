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
    [Route("api/GcRedemption")]
    public class GcRedemptionController : Controller
    {
        private readonly GiftCertificateDBContext _context;

        public GcRedemptionController(GiftCertificateDBContext context)
        {
            _context = context;
        }

        // GET: api/GcRedemption
        [HttpGet]
        public IEnumerable<GcRedemption> GetGcRedemption()
        {
            return _context.GcRedemption.Include(g => g.GiftCertNoNavigation);
        }

        // GET: api/GcRedemption/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGcRedemption([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gcRedemption = await _context.GcRedemption
                .Include(g => g.GiftCertNoNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (gcRedemption == null)
            {
                return NotFound();
            }

            return Ok(gcRedemption);
        }

        // PUT: api/GcRedemption/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGcRedemption([FromRoute] int id, [FromBody] GcRedemption gcRedemption)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gcRedemption.Id)
            {
                return BadRequest();
            }

            _context.Entry(gcRedemption).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GcRedemptionExists(id))
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

        // POST: api/GcRedemption
        [HttpPost]
        public async Task<IActionResult> PostGcRedemption([FromBody] GcRedemption gcRedemption)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.GcRedemption.Add(gcRedemption);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGcRedemption", new { id = gcRedemption.Id }, gcRedemption);
        }

        // DELETE: api/GcRedemption/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGcRedemption([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gcRedemption = await _context.GcRedemption.SingleOrDefaultAsync(m => m.Id == id);
            if (gcRedemption == null)
            {
                return NotFound();
            }

            _context.GcRedemption.Remove(gcRedemption);
            await _context.SaveChangesAsync();

            return Ok(gcRedemption);
        }

        private bool GcRedemptionExists(int id)
        {
            return _context.GcRedemption.Any(e => e.Id == id);
        }
    }
}