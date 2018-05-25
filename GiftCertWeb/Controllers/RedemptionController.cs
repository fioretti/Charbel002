using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GiftCertWeb.Models;

namespace GiftCertWeb.Controllers
{
    public class RedemptionController : Controller
    {
        private readonly GiftCertificateDBContext _context;

        public RedemptionController(GiftCertificateDBContext context)
        {
            _context = context;
        }

        // GET: Redemption
        public async Task<IActionResult> Index()
        {
            var GiftCertificateDBContext = _context.GcRedemption.Include(g => g.GiftCertNoNavigation);
            return View(await GiftCertificateDBContext.ToListAsync());
        }

        // GET: Redemption/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gcRedemption = await _context.GcRedemption
                .Include(g => g.GiftCert)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (gcRedemption == null)
            {
                return NotFound();
            }

            return View(gcRedemption);
        }

        // GET: Redemption/Create
        public IActionResult Create()
        {
            ViewData["GiftCertId"] = new SelectList(_context.GiftCert, "Id", "Id");
            return View();
        }

        // POST: Redemption/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GiftCertId,RedemptionDate,LastModifiedBy,CreatedDate,ModifiedDate,Active,Remarks")] GcRedemption gcRedemption)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gcRedemption);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GiftCertId"] = new SelectList(_context.GiftCert, "Id", "Id", gcRedemption.GiftCertId);
            return View(gcRedemption);
        }

        // GET: Redemption/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gcRedemption = await _context.GcRedemption.SingleOrDefaultAsync(m => m.Id == id);
            if (gcRedemption == null)
            {
                return NotFound();
            }
            ViewData["GiftCertId"] = new SelectList(_context.GiftCert, "Id", "Id", gcRedemption.GiftCertId);
            return View(gcRedemption);
        }

        // POST: Redemption/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GiftCertId,RedemptionDate,LastModifiedBy,CreatedDate,ModifiedDate,Active,Remarks")] GcRedemption gcRedemption)
        {
            if (id != gcRedemption.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gcRedemption);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GcRedemptionExists(gcRedemption.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GiftCertId"] = new SelectList(_context.GiftCert, "Id", "Id", gcRedemption.GiftCertId);
            return View(gcRedemption);
        }

        // GET: Redemption/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gcRedemption = await _context.GcRedemption
                .Include(g => g.GiftCert)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (gcRedemption == null)
            {
                return NotFound();
            }

            return View(gcRedemption);
        }

        // POST: Redemption/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gcRedemption = await _context.GcRedemption.SingleOrDefaultAsync(m => m.Id == id);
            _context.GcRedemption.Remove(gcRedemption);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GcRedemptionExists(int id)
        {
            return _context.GcRedemption.Any(e => e.Id == id);
        }
    }
}
