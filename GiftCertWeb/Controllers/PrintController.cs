using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiftCertWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;

namespace GiftCertWeb.Controllers
{
    public class PrintController : Controller
    {
        private readonly GiftCertificateDBContext _context;

        public PrintController(GiftCertificateDBContext context)
        {
            _context = context;
        }

        // GET: GiftCert/Details/5
        public async Task<IActionResult> Preview(int? id)
        {
            try
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


                var report = new ViewAsPdf("ViewAsPDF")
                {
                    PageMargins = { Left = 20, Bottom = 20, Right = 20, Top = 20 },
                    PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape,
                    PageSize = Rotativa.AspNetCore.Options.Size.Dle,
                    Model = giftCert
                };
                return report;

                //  return new ViewAsPdf("ViewAsPDF", giftCert)
            }
            catch (Exception ex)
            {

                throw ex;
            }
          ;          
        }

        public IActionResult DemoViewAsPDF()
        {
            return new ViewAsPdf("DemoViewAsPDF");
        }

        public IActionResult DemoPageMarginsPDF()
        {
            var report = new ViewAsPdf("DemoPageMarginsPDF")
            {
                PageMargins = { Left = 20, Bottom = 20, Right = 20, Top = 20 },
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape,
                PageSize = Rotativa.AspNetCore.Options.Size.Dle
            };
            return report;
        }

        public IActionResult DemoOrientationPDF(string Orientation)
        {
            if (Orientation == "Portrait")
            {
                var demoViewPortrait = new ViewAsPdf("DemoOrientationPDF")
                {
                    PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                };
                return demoViewPortrait;
            }
            else
            {
                var demoViewLandscape = new ViewAsPdf("DemoOrientationPDF")
                {
                    PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape,
                };
                return demoViewLandscape;
            }
        }

        public IActionResult DemoPageNumberPDF()
        {
            return new ViewAsPdf("DemoPageNumberPDF")
            {
                CustomSwitches = "--page-offset 0 --footer-center [page] --footer-font-size 12"
            };
        }


        public IActionResult DemoPageSizePDF()
        {
            return new Rotativa.AspNetCore.ViewAsPdf("DemoPageSizePDF")
            {
                PageSize = Rotativa.AspNetCore.Options.Size.A6,
            };
        }

        public IActionResult DemoPageNumberwithCurrentDate()
        {
            var pdfResult = new ViewAsPdf("DemoPageNumberwithCurrentDate")
            {
                CustomSwitches =
                    "--footer-center \"  Created Date: " +
                    DateTime.Now.Date.ToString("dd/MM/yyyy") + "  Page: [page]/[toPage]\"" +
                    " --footer-line --footer-font-size \"12\" --footer-spacing 1 --footer-font-name \"Segoe UI\""
            };

            return pdfResult;
        }

        public IActionResult DemoModelPDF()
        {
        //    List<Customer> customerList = new List<Customer>()
        //{
        //    new Customer { CustomerID = 1, Address = "Taj Lands Ends 1", City = "Mumbai" , Country ="India", Name ="Sai", Phoneno ="9000000000"},
        //    new Customer { CustomerID = 2, Address = "Taj Lands Ends 2", City = "Mumbai" , Country ="India", Name ="Ram", Phoneno ="9000000000"},
        //    new Customer { CustomerID = 3, Address = "Taj Lands Ends 3", City = "Mumbai" , Country ="India", Name ="Sainesh", Phoneno ="9000000000"},
        //    new Customer { CustomerID = 4, Address = "Taj Lands Ends 4", City = "Mumbai" , Country ="India", Name ="Saineshwar", Phoneno ="9000000000"},
        //    new Customer { CustomerID = 5, Address = "Taj Lands Ends 5", City = "Mumbai" , Country ="India", Name ="Saibags", Phoneno ="9000000000"}

        //};
            return new ViewAsPdf("DemoModelPDF");
        }



    }
}