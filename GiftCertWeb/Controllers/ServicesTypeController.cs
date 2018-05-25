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
    public class ServicesTypeController : Controller
    {
        private readonly GiftCertificateDBContext _context;

        public ServicesTypeController(GiftCertificateDBContext context)
        {
            _context = context;
        }

        // GET: ServicesType
        public async Task<IActionResult> Index()
        {
            return View(await _context.ServicesType.ToListAsync());
        }

        // GET: ServicesType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicesType = await _context.ServicesType
                .SingleOrDefaultAsync(m => m.Id == id);
            if (servicesType == null)
            {
                return NotFound();
            }

            return View(servicesType);
        }

        //// GET: GcServicesTypes/Create
        //public async Task<IActionResult> Create(int? giftCertId)
        //{
        //    var giftCert = await _context.GiftCert
        //      .Include(g => g.GcServicesType).ThenInclude(s => s.ServicesType)
        //      .SingleOrDefaultAsync(m => m.Id == giftCertId);
        //    if (giftCert == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.GiftCertNo = giftCert.GiftCertNo;
        //    ViewBag.GiftCertId = giftCert.Id;

        //    return View();
        //}

        //// POST: GcServicesTypes/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(int giftCertId, string servicesTypeName, [Bind("Id,ServicesTypeId,LastModifiedBy,CreatedDate,ModifiedDate,GiftCertId,Active, ServicesType")] GcServicesType gcServicesType)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var servicesType = new ServicesType();
        //        servicesType.Name = gcServicesType.ServicesType.Name;
        //        servicesType.LastModifiedBy = "leila";
        //        servicesType.CreatedDate = DateTime.Now;
        //        servicesType.ModifiedDate = DateTime.Now;
        //        servicesType.Active = true;

        //        gcServicesType.LastModifiedBy = "leila";
        //        gcServicesType.CreatedDate = DateTime.Now;
        //        gcServicesType.ModifiedDate = DateTime.Now;
        //        gcServicesType.GiftCertId = giftCertId;
        //        gcServicesType.Active = true;
        //        gcServicesType.ServicesType = servicesType;


        //        _context.Add(gcServicesType);
        //        await _context.SaveChangesAsync();

        //        return RedirectToAction("Edit", "GiftCert", new { id = giftCertId });
        //    }

        //    return View(gcServicesType);
        //}

        // GET: ServicesType/Create
        public async Task<IActionResult> Create(int? giftCertNo)
        {
            var giftCert = await _context.GiftCert             
               .Include(g => g.ServicesType)             
               .SingleOrDefaultAsync(m => m.GiftCertNo == giftCertNo);
            if (giftCert == null)
            {
                return NotFound();
            }

            ViewBag.GiftCertNo = giftCert.GiftCertNo;
          

            return View();
        }

        // POST: ServicesType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int giftCertNo, [Bind("Id,LastModifiedBy,CreatedDate,ModifiedDate,Name,Active,GiftCertNo")] ServicesType servicesType)
        {
            if (ModelState.IsValid)
            {
                servicesType.GiftCertNo = giftCertNo;
                servicesType.LastModifiedBy = "leila";
                servicesType.CreatedDate = DateTime.Now;
                servicesType.ModifiedDate = DateTime.Now;
                servicesType.Active = true;
                _context.Add(servicesType);
                await _context.SaveChangesAsync();

                return RedirectToAction("Edit", "GiftCert", new { id = giftCertNo });
            }
            return View(servicesType);
        }

        // GET: ServicesType/Edit/5
        public async Task<IActionResult> Edit(int? id, int? giftCertNo)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicesType = await _context.ServicesType.SingleOrDefaultAsync(m => m.Id == id);
            if (servicesType == null)
            {
                return NotFound();
            }

            ViewBag.GiftCertNo = giftCertNo;
       

            return View(servicesType);
        }

        // POST: ServicesType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int giftCertNo, [Bind("Id,LastModifiedBy,CreatedDate,ModifiedDate,Name,Active,GiftCertNo")] ServicesType servicesType)
        {
            if (id != servicesType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicesType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicesTypeExists(servicesType.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //  return RedirectToAction(nameof(Index));
                return RedirectToAction("Edit", "GiftCert", new { id = giftCertNo });
            }
            return View(servicesType);
        }

        //// GET: GcServicesTypes/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var gcServicesType = await _context.GcServicesType
        //        .Include(g => g.GiftCert)
        //        .Include(g => g.ServicesType)
        //        .SingleOrDefaultAsync(m => m.Id == id);
        //    if (gcServicesType == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.GiftCertId = gcServicesType.GiftCert.Id;

        //    return View(gcServicesType);
        //}

        //// POST: GcServicesTypes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id, int giftCertId)
        //{
        //    var gcServicesType = await _context.GcServicesType
        //        .Include(g => g.ServicesType)
        //        .SingleOrDefaultAsync(m => m.Id == id);

        //    _context.GcServicesType.Remove(gcServicesType);
        //    _context.ServicesType.Remove(gcServicesType.ServicesType);
        //    await _context.SaveChangesAsync();

        //    return RedirectToAction("Edit", "GiftCert", new { id = giftCertId });
        //}

        // GET: ServicesType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicesType = await _context.ServicesType
                .Include(g => g.GiftCertNoNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (servicesType == null)
            {
                return NotFound();
            }

            return View(servicesType);
        }

        // POST: ServicesType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servicesType = await _context.ServicesType.SingleOrDefaultAsync(m => m.Id == id);
            _context.ServicesType.Remove(servicesType);
            await _context.SaveChangesAsync();
            return RedirectToAction("Edit", "GiftCert", new { id = servicesType.GiftCertNo });
        }

        private bool ServicesTypeExists(int id)
        {
            return _context.ServicesType.Any(e => e.Id == id);
        }
    }
}
