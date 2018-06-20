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
    public class GcPurchasesController : Controller
    {
        private readonly GiftCertificateDBContext _context;

        public GcPurchasesController(GiftCertificateDBContext context)
        {
            _context = context;
        }

        // GET: GcPurchases
        public async Task<IActionResult> Index()
        {
            var giftCertificateDBContext = _context.GcPurchase.Include(g => g.GiftCertNoNavigation);
            return View(await giftCertificateDBContext.ToListAsync());
        }

        // GET: GcPurchases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gcPurchase = await _context.GcPurchase
                .Include(g => g.GiftCertNoNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (gcPurchase == null)
            {
                return NotFound();
            }

            return View(gcPurchase);
        }

        // GET: GcPurchases/Create
        public IActionResult Create()
        {
            ViewData["GiftCertNo"] = new SelectList(_context.GiftCert, "GiftCertNo", "GiftCertNo");
            return View();
        }

        // POST: GcPurchases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PurchaseDate,LastModifiedBy,CreatedDate,ModifiedDate,Active,Remarks,PaymentMode,CcNumber,ExpirationDate,CardType,GiftCertNo")] GcPurchase gcPurchase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gcPurchase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GiftCertNo"] = new SelectList(_context.GiftCert, "GiftCertNo", "GiftCertNo", gcPurchase.GiftCertNo);
            return View(gcPurchase);
        }

        // GET: GcPurchases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gcPurchase = await _context.GcPurchase.SingleOrDefaultAsync(m => m.Id == id);
            if (gcPurchase == null)
            {
                return NotFound();
            }
            ViewData["GiftCertNo"] = new SelectList(_context.GiftCert, "GiftCertNo", "GiftCertNo", gcPurchase.GiftCertNo);
            return View(gcPurchase);
        }

        // POST: GcPurchases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PurchaseDate,LastModifiedBy,CreatedDate,ModifiedDate,Active,Remarks,PaymentMode,CcNumber,ExpirationDate,CardType,GiftCertNo")] GcPurchase gcPurchase)
        {
            if (id != gcPurchase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gcPurchase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GcPurchaseExists(gcPurchase.Id))
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
            ViewData["GiftCertNo"] = new SelectList(_context.GiftCert, "GiftCertNo", "GiftCertNo", gcPurchase.GiftCertNo);
            return View(gcPurchase);
        }

        // GET: GcPurchases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gcPurchase = await _context.GcPurchase
                .Include(g => g.GiftCertNoNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (gcPurchase == null)
            {
                return NotFound();
            }

            return View(gcPurchase);
        }

        // POST: GcPurchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gcPurchase = await _context.GcPurchase.SingleOrDefaultAsync(m => m.Id == id);
            _context.GcPurchase.Remove(gcPurchase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GcPurchaseExists(int id)
        {
            return _context.GcPurchase.Any(e => e.Id == id);
        }
    }
}
