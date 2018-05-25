using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GiftCertWeb.Models;
using System.Collections.Generic;
using System;

namespace GiftCertWeb.Controllers
{
    public class GiftCertController : Controller
    {
        private readonly GiftCertificateDBContext _context;

        public GiftCertController(GiftCertificateDBContext context)
        {
            _context = context;
        }

        // GET: GiftCert
        public async Task<IActionResult> Index()
        {
            var GiftCertificateDBContext = _context.GiftCert.Include(g => g.GcType)
                                        .Include(g => g.ServicesType)
                                         .Include(g => g.GcOutlet);

            var giftCerts = await GiftCertificateDBContext.ToListAsync();

            return View(giftCerts);
        }

        // GET: GiftCert/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giftCert = await _context.GiftCert
                .Include(g => g.GcType)
                .Include(g => g.ServicesType)
                .Include(g => g.GcOutlet).ThenInclude(o => o.Outlet)
                .SingleOrDefaultAsync(m => m.GiftCertNo == id);
            if (giftCert == null)
            {
                return NotFound();
            }

            return View(giftCert);
        }

        // GET: GiftCert/Create
        public IActionResult Create()
        {            
            ViewData["GcTypeId"] = new SelectList(_context.GcType, "Id", "Name");
            ViewBag.QrCode = Guid.NewGuid().ToString();
            return View();
        }

        // POST: GiftCert/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GcTypeId,Value,IssuanceDate,DtiPermitNo,ExpirationDate,LastModifiedBy,CreatedDate,ModifiedDate,QrCode,Active,GiftCertNo,Note,Status")] GiftCert giftCert)
        {
            if (ModelState.IsValid)
            {
                _context.Add(giftCert);
                await _context.SaveChangesAsync();
                //   return RedirectToAction(nameof(Index));
                return RedirectToAction("Edit", "GiftCert", new { id = giftCert.GiftCertNo });
            }
            ViewData["GcTypeId"] = new SelectList(_context.GcType, "Id", "Id", giftCert.GcTypeId);
            return View(giftCert);
        }

        // GET: GiftCert/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giftCert = await _context.GiftCert
                  .Include(g => g.ServicesType)
                  .Include(g => g.GcOutlet).ThenInclude(o => o.Outlet)
                  .SingleOrDefaultAsync(m => m.GiftCertNo == id);
            if (giftCert == null)
            {
                return NotFound();
            }
            ViewData["GcTypeId"] = new SelectList(_context.GcType, "Id", "Name", giftCert.GcTypeId);
            return View(giftCert);
        }

        // POST: GiftCert/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GcTypeId,Value,IssuanceDate,DtiPermitNo,ExpirationDate,LastModifiedBy,CreatedDate,ModifiedDate,QrCode,Active,GiftCertNo,Note,Status")] GiftCert giftCert)
        {
            if (id != giftCert.GiftCertNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(giftCert);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GiftCertExists(giftCert.GiftCertNo))
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
            ViewData["GcTypeId"] = new SelectList(_context.GcType, "Id", "Id", giftCert.GcTypeId);
            return View(giftCert);
        }

        // GET: GiftCert/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giftCert = await _context.GiftCert
                .Include(g => g.GcType)
                .SingleOrDefaultAsync(m => m.GiftCertNo == id);
            if (giftCert == null)
            {
                return NotFound();
            }

            return View(giftCert);
        }

        // POST: GiftCert/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var giftCert = await _context.GiftCert.SingleOrDefaultAsync(m => m.GiftCertNo == id);
            _context.GiftCert.Remove(giftCert);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GiftCertExists(int id)
        {
            return _context.GiftCert.Any(e => e.GiftCertNo == id);
        }
    }
}
