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
    public class GcOutletController : Controller
    {
        private readonly GiftCertificateDBContext _context;

        public GcOutletController(GiftCertificateDBContext context)
        {
            _context = context;
        }

        // GET: GcOutlets
        public async Task<IActionResult> Index()
        {
            var GiftCertificateDBContext = _context.GcOutlet.Include(g => g.GiftCertNoNavigation).Include(g => g.Outlet);
            return View(await GiftCertificateDBContext.ToListAsync());
        }

        // GET: GcOutlets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gcOutlet = await _context.GcOutlet
                .Include(g => g.GiftCertNoNavigation)
                .Include(g => g.Outlet)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (gcOutlet == null)
            {
                return NotFound();
            }

            return View(gcOutlet);
        }

        // GET: GcOutlets/Create
        public async Task<IActionResult> Create(int? giftCertNo)
        {
            var giftCert = await _context.GiftCert
             .Include(g => g.GcOutlet).ThenInclude(o => o.Outlet)
             .SingleOrDefaultAsync(m => m.GiftCertNo == giftCertNo);
            if (giftCert == null)
            {
                return NotFound();
            }

            ViewBag.GiftCertNo = giftCert.GiftCertNo;
            //ViewBag.GiftCertId = giftCert.Id;
           
            return View();
        }

        // POST: GcOutlets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int giftCertNo, [Bind("Id,GiftCertNo,OutletId,Outlet")] GcOutlet gcOutlet)
        {
            if (ModelState.IsValid)
            {
                var outlet = new Outlet();
                outlet.Name = gcOutlet.Outlet.Name;
                outlet.LastModifiedBy = "leila";
                outlet.CreatedDate = DateTime.Now;
                outlet.ModifiedDate = DateTime.Now;
                outlet.Active = true;
               
                gcOutlet.GiftCertNo = giftCertNo;
                gcOutlet.Outlet = outlet;

                _context.Add(gcOutlet);
                await _context.SaveChangesAsync();
                
                return RedirectToAction("Edit", "GiftCert", new { id = giftCertNo });
            }
          
            return View(gcOutlet);
        }

        // GET: GcOutlets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gcOutlet = await _context.GcOutlet.SingleOrDefaultAsync(m => m.Id == id);
            if (gcOutlet == null)
            {
                return NotFound();
            }
            ViewData["GiftCertId"] = new SelectList(_context.GiftCert, "Id", "Id", gcOutlet.GiftCertNo);
            ViewData["OutletId"] = new SelectList(_context.Outlet, "Id", "Id", gcOutlet.OutletId);
            return View(gcOutlet);
        }

        // POST: GcOutlets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GiftCertId,OutletId,LastModifiedBy,CreatedDate,ModifiedDate,Active")] GcOutlet gcOutlet)
        {
            if (id != gcOutlet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gcOutlet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GcOutletExists(gcOutlet.Id))
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
            ViewData["GiftCertId"] = new SelectList(_context.GiftCert, "Id", "Id", gcOutlet.GiftCertNo);
            ViewData["OutletId"] = new SelectList(_context.Outlet, "Id", "Id", gcOutlet.OutletId);
            return View(gcOutlet);
        }

        // GET: GcOutlets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gcOutlet = await _context.GcOutlet
                .Include(g => g.GiftCertNoNavigation)
                .Include(g => g.Outlet)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (gcOutlet == null)
            {
                return NotFound();
            }

            ViewBag.GiftCertNo = gcOutlet.GiftCertNo;

            return View(gcOutlet);
        }

        // POST: GcOutlets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, int giftCertNo)
        {
            var gcOutlet = await _context.GcOutlet
                 .Include(g => g.Outlet)
                .SingleOrDefaultAsync(m => m.Id == id);

            _context.GcOutlet.Remove(gcOutlet);
            _context.Outlet.Remove(gcOutlet.Outlet);
            await _context.SaveChangesAsync();      
            
            return RedirectToAction("Edit", "GiftCert", new { id = giftCertNo });
        }

        private bool GcOutletExists(int id)
        {
            return _context.GcOutlet.Any(e => e.Id == id);
        }
    }
}
