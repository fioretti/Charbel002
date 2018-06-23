using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GiftCertWeb.Models;
using System.Collections.Generic;
using System;
using GiftCertWeb.Services;
using Microsoft.AspNetCore.Authorization;

namespace GiftCertWeb.Controllers
{
    [Authorize]
    public class GiftCertController : Controller
    {
        private readonly GiftCertificateDBContext _context;

        public GiftCertController(GiftCertificateDBContext context)
        {
            _context = context;
        }

        //private async Task<GiftCert> SetGcStatus(IQueryable<GiftCert> giftCert)
        //{
        //    if (giftCert.Select(o => o.Name.ToLower().Trim()).Except(outletItems).Any())


        //        //TODO: Voided, manually voided sa system - unsold GC	Basin Audit lng naai rights

        //        if (DateTime.Now > expirationDate)
        //        return (int)StatusEnum.Expired;

        //    var gcRedemption = await _context.GcRedemption.SingleOrDefaultAsync(m => m.GiftCertNo == giftCertNo);
        //    if (gcRedemption != null)
        //        return (int)StatusEnum.Availed;
        //    else
        //    {
        //        var gcPurchase = await _context.GcPurchase.SingleOrDefaultAsync(m => m.GiftCertNo == giftCertNo);
        //        if (gcPurchase == null)
        //            return (int)StatusEnum.Unsold;
        //        else
        //            return (int)StatusEnum.Sold;
        //    }

        //    return giftCert;
        //}

        // GET: GiftCert
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            IQueryable<GiftCert> giftCerts;

            ViewData["GiftCertNoSortParm"] = String.IsNullOrEmpty(sortOrder) ? "gc_no_desc" : "";
            ViewData["ExpDateSortParm"] = sortOrder == "ExpDate" ? "exp_date_desc" : "ExpDate";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            giftCerts = _context.GiftCert.Include(g => g.GcType)
                                       .Include(g => g.ServicesType)
                                        .Include(g => g.GcOutlet);
                      
            if (!String.IsNullOrEmpty(searchString))
            {
                giftCerts = giftCerts.Where(m => m.GiftCertNo.ToString().Contains(searchString));
            }

            switch (sortOrder)
            {
                case "gc_no_desc":
                     giftCerts = giftCerts.OrderByDescending(s => s.GiftCertNo);
                    break;
                case "ExpDate":
                    giftCerts = giftCerts.OrderBy(s => s.ExpirationDate);
                    break;
                case "date_desc":
                    giftCerts = giftCerts.OrderByDescending(s => s.ExpirationDate);
                    break;
                default:
                    giftCerts = giftCerts.OrderBy(s => s.GiftCertNo);
                    break;
            }

          //  giftCerts = SetGcStatus(giftCerts);

            int pageSize = 10;            
            return View(await PaginatedList<GiftCert>.CreateAsync(giftCerts.AsNoTracking(), page ?? 1, pageSize));
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
                  .Include(g => g.GcType)
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
