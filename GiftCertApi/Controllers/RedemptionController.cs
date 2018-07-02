using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GiftCertApi.Models;

namespace GiftCertApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Redemption")]
    public class RedemptionController : Controller
    {
        private readonly GiftCertificateDBContext _context;

        public RedemptionController(GiftCertificateDBContext context)
        {
            _context = context;
        }

        // GET: api/Redemption
        [HttpGet]
        public IEnumerable<Redemption> GetRedemption()
        {
            return _context.Redemption;
        }

        // GET: api/Redemption/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRedemption([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var redemption = await _context.Redemption.SingleOrDefaultAsync(m => m.Id == id);

            if (redemption == null)
            {
                return NotFound();
            }

            return Ok(redemption);
        }

        // PUT: api/Redemption/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRedemption([FromRoute] int id, [FromBody] Redemption redemption)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != redemption.Id)
            {
                return BadRequest();
            }

            _context.Entry(redemption).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RedemptionExists(id))
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

        // POST: api/Redemption
        [HttpPost]
        public async Task<IActionResult> PostRedemption([FromBody] Redemption redemption)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Redemption.Add(redemption);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRedemption", new { id = redemption.Id }, redemption);
        }

        // DELETE: api/Redemption/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRedemption([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var redemption = await _context.Redemption.SingleOrDefaultAsync(m => m.Id == id);
            if (redemption == null)
            {
                return NotFound();
            }

            _context.Redemption.Remove(redemption);
            await _context.SaveChangesAsync();

            return Ok(redemption);
        }

        private bool RedemptionExists(int id)
        {
            return _context.Redemption.Any(e => e.Id == id);
        }
    }
}