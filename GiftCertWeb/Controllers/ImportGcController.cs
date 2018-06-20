using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastMember;
using GiftCertWeb.Models;
using GiftCertWeb.Models.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NToastNotify;
using OfficeOpenXml;

namespace GiftCertWeb.Controllers
{
    public class ImportGcController : Controller
    {
        public static IConfiguration Configuration;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IToastNotification _toastNotification;
        private readonly GiftCertificateDBContext _context;

        public ImportGcController(IHostingEnvironment hostingEnvironment, IToastNotification toastNotification, GiftCertificateDBContext context)
        {
            _hostingEnvironment = hostingEnvironment;
            _toastNotification = toastNotification;
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        private ValidationResponse ValidateExcelFile(string filePath)
        {
            var response = new ValidationResponse();

            FileInfo file = new FileInfo(filePath);

            using (ExcelPackage package = new ExcelPackage(file))
            {
                StringBuilder sb = new StringBuilder();
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                int rowCount = worksheet.Dimension.Rows;
                int ColCount = worksheet.Dimension.Columns;

                var rawText = string.Empty;
                List<string> records = new List<string>();

                for (int row = 2; row <= rowCount; row++)
                {
                    var rawTextTmp = string.Empty;
                    for (int col = 1; col <= ColCount; col++)
                    {
                        if (worksheet.Cells[row, col].Value != null)
                            rawTextTmp += worksheet.Cells[row, col].Value.ToString() + "|";
                        else
                            rawTextTmp += "|";
                    }

                    if (!string.IsNullOrEmpty(rawTextTmp) && rawTextTmp != "||||||||")
                    {
                        rawText += rawTextTmp;
                        rawText += "\n";
                    }
                }

                var rawText2 = rawText.Substring(0, rawText.LastIndexOf("\n") - 1);
                records = new List<string>(rawText2.Split('\n'));

                foreach (string record in records)
                {
                    if (string.IsNullOrEmpty(record))
                        continue;

                    var gc = new GiftCertDto();
                    string[] servicesRecords = new List<string>().ToArray();
                    string[] outletRecords = new List<string>().ToArray();
                    string[] textpart = record.Split('|');

                    gc.GiftCertNo = !string.IsNullOrEmpty(textpart[0]) ? Convert.ToInt32(textpart[0]) : 0;
                    gc.GcTypeName = !string.IsNullOrEmpty(textpart[1]) ? textpart[1] : string.Empty;
                    gc.Value = !string.IsNullOrEmpty(textpart[2]) ? Convert.ToDecimal(textpart[2]) : 0;
                    gc.DtiPermitNo = !string.IsNullOrEmpty(textpart[5]) ? textpart[5] : string.Empty;
                    gc.ExpirationDate = !string.IsNullOrEmpty(textpart[6]) ? Convert.ToDateTime(textpart[6]) : DateTime.MinValue;
                    if (!string.IsNullOrEmpty(textpart[3]))
                        servicesRecords = textpart[3].Split(';');
                    if (!string.IsNullOrEmpty(textpart[7]))
                        outletRecords = textpart[7].Split(';');

                    var giftCert = _context.GiftCert.FirstOrDefault(m => m.GiftCertNo == gc.GiftCertNo);
                    if (giftCert != null)
                    {
                        response.ErrorMsg.Add("Gift Cert No: " + gc.GiftCertNo + " already exists in the database.");
                        response.IsValid = false;
                        break;
                    }

                    if (string.IsNullOrEmpty(gc.GcTypeName))
                    {
                        response.ErrorMsg.Add("GC Type is required.");
                        response.IsValid = false;
                        break;
                    }

                    if (gc.GcTypeName.Trim().ToLower() == "regular gc")
                    {
                        if (gc.GiftCertNo == 0 || gc.Value == 0 || servicesRecords.Count() == 0)
                            response.ErrorMsg.Add("Regular GC requires Gift Cert No, GC Type, Value and Services.");
                        if (!string.IsNullOrEmpty(gc.DtiPermitNo) || gc.ExpirationDate != DateTime.MinValue || outletRecords.Count() > 0)
                            response.ErrorMsg.Add("Regular GC restricts DTI Permit No, Expiration Date and Oulet.");
                    }

                    if (gc.GcTypeName.Trim().ToLower() == "corporate gc")
                    {
                        if (gc.GiftCertNo == 0 || gc.Value == 0 || servicesRecords.Count() == 0 || gc.ExpirationDate == DateTime.MinValue)
                            response.ErrorMsg.Add("Corporate GC requires Gift Cert No, GC Type, Value, Expiration Date and Services.");
                        if (!string.IsNullOrEmpty(gc.DtiPermitNo) || outletRecords.Count() > 0)
                            response.ErrorMsg.Add("Corporate GC restricts DTI Permit No and Oulet.");
                    }

                    if (gc.GcTypeName.Trim().ToLower() == "promotional gc")
                    {
                        if (gc.GiftCertNo == 0 || gc.Value == 0 || servicesRecords.Count() == 0 || string.IsNullOrEmpty(gc.DtiPermitNo) || gc.ExpirationDate == DateTime.MinValue || outletRecords.Count() == 0)
                            response.ErrorMsg.Add("Promotional GC requires all fields.");
                    }

                    if (response.ErrorMsg.Count > 0)
                    {
                        response.IsValid = false;
                        break;
                    }
                }
            }
            return response;
        }

        #region snippet1
        [HttpPost("ImportGc")]
        public async Task<IActionResult> Post(List<IFormFile> files)
        {
            var errorMsg = string.Empty;
            var isValid = true;

            if (files.Count < 1)
            {
                errorMsg = "File is required.";
                isValid = false;
            }

            if (isValid)
            {
                long size = files.Sum(f => f.Length);

                var filePath = Path.GetTempFileName();

                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                    }
                }

                var response = BulkCopy(filePath);

                if (!response.IsValid)
                {
                    foreach (var msg in response.ErrorMsg)
                    {
                        ModelState.AddModelError(string.Empty, msg);
                    }
                }
            }

            if (!isValid)
                ModelState.AddModelError(string.Empty, errorMsg);
            //   _toastNotification.AddErrorToastMessage("Error", errorMsg);

            //return Ok(new { count = files.Count, size, filePath });
            //   return RedirectToAction("Index", "GiftCert");
            //  return RedirectToAction("Index", "ImportGc");
            return View("Index");
        }

        bool IsSequential(int[] array)
        {
            return array.Zip(array.Skip(1), (a, b) => (a + 1) == b).All(x => x);
        }

        public ValidationResponse BulkCopy(string filePath)
        {
            var response = new ValidationResponse();

            response = ValidateExcelFile(filePath);

            if (response.IsValid)
            {
                // TODO: Extract this to a service class
                // load from excel

                var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

                builder.AddEnvironmentVariables();
                Configuration = builder.Build();
                string connectionstring = Configuration["ConnectionStrings:DefaultConnection"];

                //  var filePath = @"D:/GcDetails.xlsx";
                FileInfo file = new FileInfo(filePath);

                using (ExcelPackage package = new ExcelPackage(file))
                {
                    StringBuilder sb = new StringBuilder();
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                    int rowCount = worksheet.Dimension.Rows;
                    int ColCount = worksheet.Dimension.Columns;

                    var rawText = string.Empty;
                    List<string> records = new List<string>();

                    for (int row = 2; row <= rowCount; row++)
                    {
                        for (int col = 1; col <= ColCount; col++)
                        {
                            if (col == 1 && worksheet.Cells[row, col].Value == null)
                                break;

                            if (worksheet.Cells[row, col].Value != null)
                                rawText += worksheet.Cells[row, col].Value.ToString() + "|";
                            else
                                rawText += "|";
                        }
                        rawText += "\n";
                    }

                    records = new List<string>(rawText.Split('\n'));

                    var gcList = new List<GiftCertDto>();

                    foreach (string record in records)
                    {
                        if (string.IsNullOrEmpty(record))
                            break;

                        var gc = new GiftCertDto();

                        string[] textpart = record.Split('|');

                        if (textpart[0] != string.Empty)
                            gc.GiftCertNo = Convert.ToInt32(textpart[0]);
                        gc.GcTypeName = textpart[1].Trim();
                        if (textpart[2] != string.Empty)
                            gc.Value = Convert.ToDecimal(textpart[2]);
                        gc.Note = textpart[4];
                        gc.DtiPermitNo = textpart[5];
                        if (textpart[6] != string.Empty)
                            gc.ExpirationDate = Convert.ToDateTime(textpart[6]);

                        var servicesList = new List<ServicesTypeDto>();
                        string[] servicesRecords = textpart[3].Split(';');

                        foreach (string servicesRecord in servicesRecords)
                        {
                            var servicesType = new ServicesTypeDto();
                            servicesType.Name = servicesRecord;
                            servicesList.Add(servicesType);
                        }

                        var outletList = new List<OutletDto>();
                        string[] outletRecords = textpart[7].Split(';');

                        foreach (string outletRecord in outletRecords)
                        {
                            var outlet = new OutletDto();
                            outlet.Name = outletRecord;
                            outletList.Add(outlet);
                        }

                        gc.Services = servicesList;
                        gc.Outlets = outletList;


                        gcList.Add(gc);

                    }

                    //validate sequential gcno
                    var isSequential = IsSequential(gcList.Select(m => m.GiftCertNo).ToArray());
                    if (!isSequential)
                    {
                        response.ErrorMsg.Add("GC Number should be sequenced.");
                        response.IsValid = false;
                        return response;
                    }

                    //gctype contains only
                    var desiredItems = new List<string> { "regular gc", "promotional gc", "corporate gc" };
                    if (gcList.Select(m => m.GcTypeName.ToLower().Trim()).Except(desiredItems).Any())
                    {
                        response.ErrorMsg.Add("GC Type should contains only Regular GC, Promotional GC and Corporate GC");
                        response.IsValid = false;
                        return response;
                    }

                    //sql entity
                    var giftCerts = new List<GiftCert>();
                    var gcOutlets = new List<GcOutlet>();
                    var services = new List<ServicesType>();

                    foreach (var gc in gcList)
                    {
                        var giftCert = new GiftCert();

                        if (gc.GcTypeName.Replace(" ", "").ToLower() == GcTypeOptions.RegularGC.ToString().ToLower())
                            giftCert.GcTypeId = (int)GcTypeOptions.RegularGC;
                        if (gc.GcTypeName.Replace(" ", "").ToLower() == GcTypeOptions.PromotionalGC.ToString().ToLower())
                            giftCert.GcTypeId = (int)GcTypeOptions.PromotionalGC;
                        if (gc.GcTypeName.Replace(" ", "").ToLower() == GcTypeOptions.CorporateGC.ToString().ToLower())
                            giftCert.GcTypeId = (int)GcTypeOptions.CorporateGC;

                        giftCert.Value = gc.Value;
                        giftCert.DtiPermitNo = gc.DtiPermitNo;
                        giftCert.ExpirationDate = gc.ExpirationDate;
                        giftCert.QrCode = Guid.NewGuid().ToString();
                        giftCert.GiftCertNo = gc.GiftCertNo;
                        giftCert.Note = gc.Note;

                        giftCert.LastModifiedBy = "leila";
                        giftCert.CreatedDate = DateTime.Now;
                        giftCert.ModifiedDate = DateTime.Now;

                        giftCerts.Add(giftCert);

                        //gcoutlet                  
                        foreach (var outlet in gc.Outlets)
                        {
                            if (string.IsNullOrEmpty(outlet.Name))
                                break;

                            var gcOutlet = new GcOutlet();
                            if (outlet.Name.Replace(" ", "") == OutletOptions.CaféMarco.ToString())
                                gcOutlet.OutletId = (int)OutletOptions.CaféMarco;
                            if (outlet.Name.Replace(" ", "") == OutletOptions.ElViento.ToString())
                                gcOutlet.OutletId = (int)OutletOptions.ElViento;
                            if (outlet.Name.Replace(" ", "") == OutletOptions.LobbyLounge.ToString())
                                gcOutlet.OutletId = (int)OutletOptions.LobbyLounge;

                            gcOutlet.GiftCertNo = gc.GiftCertNo;
                            gcOutlets.Add(gcOutlet);
                        }

                        //services
                        foreach (var service in gc.Services)
                        {
                            if (string.IsNullOrEmpty(service.Name))
                                break;

                            var servicesType = new ServicesType();

                            servicesType.GiftCertNo = gc.GiftCertNo;
                            servicesType.Name = service.Name;
                            servicesType.Active = true;
                            servicesType.LastModifiedBy = "leila";
                            servicesType.CreatedDate = DateTime.Now;
                            servicesType.ModifiedDate = DateTime.Now;

                            services.Add(servicesType);
                        }
                    }

                    var gcParameters = new[]
                       {
                        nameof(GiftCert.GcTypeId),
                        nameof(GiftCert.Value),
                        nameof(GiftCert.IssuanceDate),
                        nameof(GiftCert.DtiPermitNo),
                        nameof(GiftCert.ExpirationDate),
                        nameof(GiftCert.LastModifiedBy),
                        nameof(GiftCert.CreatedDate),
                        nameof(GiftCert.ModifiedDate),
                        nameof(GiftCert.QrCode),
                        nameof(GiftCert.Note),
                        nameof(GiftCert.Status),
                        nameof(GiftCert.GiftCertNo)
                    };

                    var gcOutletParameters = new[]
                      {
                        nameof(GcOutlet.Id),
                        nameof(GcOutlet.OutletId),
                        nameof(GcOutlet.GiftCertNo)
                  };

                    var serviceTypeParameters = new[]
                    {
                        nameof(ServicesType.Id),
                        nameof(ServicesType.LastModifiedBy),
                        nameof(ServicesType.CreatedDate),
                        nameof(ServicesType.ModifiedDate),
                        nameof(ServicesType.Name),
                        nameof(ServicesType.Active),
                        nameof(ServicesType.GiftCertNo)
                  };


                    using (var sqlcopy = new SqlBulkCopy(connectionstring, SqlBulkCopyOptions.Default))
                    {
                        sqlcopy.BatchSize = 500;

                        sqlcopy.DestinationTableName = "[GiftCert]";
                        using (var reader = ObjectReader.Create(giftCerts, gcParameters))
                        {
                            sqlcopy.WriteToServer(reader);
                        }

                        sqlcopy.DestinationTableName = "[GcOutlet]";
                        using (var reader = ObjectReader.Create(gcOutlets, gcOutletParameters))
                        {
                            sqlcopy.WriteToServer(reader);
                        }

                        sqlcopy.DestinationTableName = "[ServicesType]";
                        using (var reader = ObjectReader.Create(services, serviceTypeParameters))
                        {
                            sqlcopy.WriteToServer(reader);
                        }
                    }
                }
            }
            return response;
        }


        #endregion
    }
}