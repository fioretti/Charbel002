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
    public class GcTypeController : Controller
    {
        private readonly GiftCertificateDBContext _context;

        public GcTypeController(GiftCertificateDBContext context)
        {
            _context = context;
        }

        // GET: GcType
        public async Task<IActionResult> Index()
        {
            return View(await _context.GcType.ToListAsync());
        }

        // GET: GcType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gcType = await _context.GcType
                .SingleOrDefaultAsync(m => m.Id == id);
            if (gcType == null)
            {
                return NotFound();
            }

            return View(gcType);
        }

        // GET: GcType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GcType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LastModifiedBy,CreatedDate,ModifiedDate,Name,Active")] GcType gcType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gcType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gcType);
        }

        // GET: GcType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gcType = await _context.GcType.SingleOrDefaultAsync(m => m.Id == id);
            if (gcType == null)
            {
                return NotFound();
            }
            return View(gcType);
        }

        // POST: GcType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LastModifiedBy,CreatedDate,ModifiedDate,Name,Active")] GcType gcType)
        {
            if (id != gcType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gcType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GcTypeExists(gcType.Id))
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
            return View(gcType);
        }

        // GET: GcType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gcType = await _context.GcType
                .SingleOrDefaultAsync(m => m.Id == id);
            if (gcType == null)
            {
                return NotFound();
            }

            return View(gcType);
        }

        // POST: GcType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gcType = await _context.GcType.SingleOrDefaultAsync(m => m.Id == id);
            _context.GcType.Remove(gcType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GcTypeExists(int id)
        {
            return _context.GcType.Any(e => e.Id == id);
        }
    }
}
