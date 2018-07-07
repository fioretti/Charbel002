using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GiftCertApi.Models;
using GiftCertApi.Models.Dto;

namespace GiftCertApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Purchase")]
    public class PurchaseController : Controller
    {
        private readonly GiftCertificateDBContext _context;

        public PurchaseController(GiftCertificateDBContext context)
        {
            _context = context;
        }

        // GET: api/Purchase
        [HttpGet]
        public async Task<IEnumerable<PurchaseDto>> GetPurchase()
        {
            var purchases = new List<PurchaseDto>();
            try
            {                
                var gcPurchases = await _context.GcPurchase.Include(p => p.Purchase).Include(g => g.GiftCertNoNavigation).ToListAsync();

                foreach (var gcPurchase in gcPurchases)
                {
                    var purchase = new PurchaseDto();
                    purchase.Id =  gcPurchase.Purchase.Id;
                    purchase.PurchaseDate = gcPurchase.Purchase.PurchaseDate != null ? gcPurchase.Purchase.PurchaseDate : DateTime.MinValue;
                    purchase.LastModifiedBy = gcPurchase.Purchase.LastModifiedBy != null ? gcPurchase.Purchase.LastModifiedBy : string.Empty;
                    purchase.CreatedDate = gcPurchase.Purchase.CreatedDate != null ? gcPurchase.Purchase.CreatedDate : DateTime.MinValue;
                    purchase.ModifiedDate = gcPurchase.Purchase.ModifiedDate != null ? gcPurchase.Purchase.ModifiedDate : DateTime.MinValue;

                    purchase.Active = gcPurchase.Purchase.Active != null ? gcPurchase.Purchase.Active : true;
                    purchase.Remarks = gcPurchase.Purchase.Remarks != null ? gcPurchase.Purchase.Remarks : string.Empty;
                    purchase.PaymentMode = gcPurchase.Purchase.PaymentMode !=null ? gcPurchase.Purchase.PaymentMode : string.Empty;
                    purchase.CcNumber = gcPurchase.Purchase.CcNumber != null ? gcPurchase.Purchase.CcNumber : string.Empty; 
                    purchase.ExpirationDate = gcPurchase.Purchase.ExpirationDate != null ? gcPurchase.Purchase.ExpirationDate : DateTime.MinValue;
                    purchase.CardType = gcPurchase.Purchase.CardType != null ? gcPurchase.Purchase.CardType : string.Empty;  
                 
                    purchases.Add(purchase);
                }

                purchases = purchases.GroupBy(p => p.Id).Select(p => p.First()).ToList();

                foreach (var gcPurchase in gcPurchases)
                {
                    var giftCert = new GiftCertDto();
                    giftCert.GiftCertNo = gcPurchase.GiftCertNoNavigation.GiftCertNo;

                    giftCert.Value = gcPurchase.GiftCertNoNavigation.Value;
                    giftCert.GcTypeId = gcPurchase.GiftCertNoNavigation.GcTypeId;
                    giftCert.IssuanceDate = gcPurchase.GiftCertNoNavigation.IssuanceDate ?? DateTime.MinValue;
                    giftCert.DtiPermitNo = gcPurchase.GiftCertNoNavigation.DtiPermitNo ?? string.Empty;
                    giftCert.ExpirationDate = gcPurchase.GiftCertNoNavigation.ExpirationDate;
                    giftCert.LastModifiedBy = gcPurchase.GiftCertNoNavigation.LastModifiedBy ?? string.Empty;
                    giftCert.CreatedDate = gcPurchase.GiftCertNoNavigation.CreatedDate ?? DateTime.MinValue;
                    giftCert.ModifiedDate = gcPurchase.GiftCertNoNavigation.ModifiedDate ?? DateTime.MinValue;
                    giftCert.QrCode = gcPurchase.GiftCertNoNavigation.QrCode;
                    giftCert.Note = gcPurchase.GiftCertNoNavigation.Note ?? string.Empty;
                    giftCert.Status = gcPurchase.GiftCertNoNavigation.Status ?? 1;

                    var purchase = purchases.SingleOrDefault(p => p.Id == gcPurchase.PurchaseId);

                    if (purchase != null)
                    {
                        if (purchase.GiftCerts == null)
                            purchase.GiftCerts = new List<GiftCertDto>();

                        if (giftCert.GiftCertNo > 0)
                            purchase.GiftCerts.Add(giftCert);
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return purchases;
        }

        // GET: api/Purchase/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPurchase([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var purchase = await _context.Purchase.SingleOrDefaultAsync(m => m.Id == id);

            if (purchase == null)
            {
                return NotFound();
            }

            return Ok(purchase);
        }

        // PUT: api/Purchase/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchase([FromRoute] int id, [FromBody] Purchase purchase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != purchase.Id)
            {
                return BadRequest();
            }

            _context.Entry(purchase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseExists(id))
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

        // POST: api/Purchase
        [HttpPost]
        public async Task<IActionResult> PostPurchase([FromBody] Purchase purchase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Purchase.Add(purchase);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPurchase", new { id = purchase.Id }, purchase);
        }

        // DELETE: api/Purchase/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchase([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var purchase = await _context.Purchase.SingleOrDefaultAsync(m => m.Id == id);
            if (purchase == null)
            {
                return NotFound();
            }

            _context.Purchase.Remove(purchase);
            await _context.SaveChangesAsync();

            return Ok(purchase);
        }

        private bool PurchaseExists(int id)
        {
            return _context.Purchase.Any(e => e.Id == id);
        }
    }
}