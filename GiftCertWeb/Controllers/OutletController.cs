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
    public class OutletController : Controller
    {
        private readonly GiftCertificateDBContext _context;

        public OutletController(GiftCertificateDBContext context)
        {
            _context = context;
        }

        // GET: Outlet
        public async Task<IActionResult> Index()
        {
            return View(await _context.Outlet.ToListAsync());
        }

        // GET: Outlet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var outlet = await _context.Outlet
                .SingleOrDefaultAsync(m => m.Id == id);
            if (outlet == null)
            {
                return NotFound();
            }

            return View(outlet);
        }

        // GET: Outlet/Create
        public async Task<IActionResult> Create(int? giftCertNo)
        {
            var giftCert = await _context.GiftCert            
             .SingleOrDefaultAsync(m => m.GiftCertNo == giftCertNo);
            if (giftCert == null)
            {
                return NotFound();
            }

            ViewBag.GiftCertNo = giftCert.GiftCertNo;
          
            return View();
        }

        // POST: Outlet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LastModifiedBy,CreatedDate,ModifiedDate,Active")] Outlet outlet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(outlet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(outlet);
        }

        // GET: Outlet/Edit/5
        public async Task<IActionResult> Edit(int? id, int? giftCertNo)
        {
            if (id == null)
            {
                return NotFound();
            }

            var outlet = await _context.Outlet.SingleOrDefaultAsync(m => m.Id == id);
            if (outlet == null)
            {
                return NotFound();
            }

            ViewBag.GiftCertNo = giftCertNo;        

            return View(outlet);
        }

        // POST: Outlet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int giftCertNo, [Bind("Id,Name,LastModifiedBy,CreatedDate,ModifiedDate,Active")] Outlet outlet)
        {
            if (id != outlet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(outlet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OutletExists(outlet.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //   return RedirectToAction(nameof(Index));
               return RedirectToAction("Edit", "GiftCert", new { id = giftCertNo });
            }
            return View(outlet);
        }

        // GET: Outlet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var outlet = await _context.Outlet
                .SingleOrDefaultAsync(m => m.Id == id);
            if (outlet == null)
            {
                return NotFound();
            }

            return View(outlet);
        }

        // POST: Outlet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var outlet = await _context.Outlet.SingleOrDefaultAsync(m => m.Id == id);
            _context.Outlet.Remove(outlet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OutletExists(int id)
        {
            return _context.Outlet.Any(e => e.Id == id);
        }
    }
}
