using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastMember;
using GiftCertWeb.Models;
using GiftCertWeb.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NToastNotify;
using OfficeOpenXml;

namespace GiftCertWeb.Controllers
{
    [Authorize]
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

                    if (!string.IsNullOrEmpty(rawTextTmp) && rawTextTmp != "|||||||||")
                    {
                        rawText += rawTextTmp;
                        rawText += "\n";
                    }
                }

                var rawText2 = rawText.Substring(0, rawText.LastIndexOf("\n") - 1);
                records = new List<string>(rawText2.Split('\n'));

                //limit reocrds to 100
                if (records.Count > 100)
                    response.ErrorMsg.Add("The maximum number of records allowed (100) has been exceeded.");

                for (int i = 0; i < records.Count; i++)
                {
                    var record = records[i];
                    var lineNumber = i + 2;
                    if (string.IsNullOrEmpty(record))
                        continue;

                    var gc = new GiftCertDto();
                    string[] servicesRecords = new List<string>().ToArray();
                    string[] outletRecords = new List<string>().ToArray();
                    string[] textpart = record.Split('|');

                    //gcnumber should be in whole number                    
                    if (!IsCharDigit(textpart[0].ToString()))
                        response.ErrorMsg.Add(String.Format("Line {0}: Gift Cert No should be in whole number.", lineNumber));
                    else
                        gc.GiftCertNo = !string.IsNullOrEmpty(textpart[0]) ? Convert.ToInt32(textpart[0]) : 0;

                    //value should be in whole number                            
                    if (!IsCharDigit(textpart[2].ToString()))
                        response.ErrorMsg.Add(String.Format("Line {0}: Value should be in whole number.", lineNumber));
                    else
                        gc.Value = !string.IsNullOrEmpty(textpart[2]) ? Convert.ToDecimal(textpart[2]) : 0;

                    //gctype contains only
                    var gcTypeItems = new List<string> { "regular gc", "promotional gc", "corporate gc" };
                    if (!gcTypeItems.Contains(textpart[1].ToLower().Trim()))
                        response.ErrorMsg.Add(String.Format("Line {0}: GC Type should contains only Regular GC, Promotional GC and Corporate GC.", lineNumber));
                    else
                        gc.GcTypeName = !string.IsNullOrEmpty(textpart[1]) ? textpart[1] : string.Empty;

                    if (IsValidDateFormat(textpart[3]))
                        gc.IssuanceDate = !string.IsNullOrEmpty(textpart[3]) ? Convert.ToDateTime(textpart[3]) : DateTime.MinValue;
                    else
                        response.ErrorMsg.Add(String.Format("Line {0}: Please Enter the issuance date in the format 'M/D/YYYY'.", lineNumber));

                    if (IsValidDateFormat(textpart[7]))
                        gc.ExpirationDate = !string.IsNullOrEmpty(textpart[7]) ? Convert.ToDateTime(textpart[7]) : DateTime.MinValue;
                    else
                        response.ErrorMsg.Add(String.Format("Line {0}: Please Enter the expiration date in the format 'M/D/YYYY'.", lineNumber));

                    gc.DtiPermitNo = !string.IsNullOrEmpty(textpart[6]) ? textpart[6] : string.Empty;
                  
                    if (!string.IsNullOrEmpty(textpart[4]))
                        servicesRecords = textpart[4].Split(';');
                    if (!string.IsNullOrEmpty(textpart[8]))
                        outletRecords = textpart[8].Split(';');

                    var giftCert = _context.GiftCert.FirstOrDefault(m => m.GiftCertNo == gc.GiftCertNo);
                    if (giftCert != null)
                        response.ErrorMsg.Add(String.Format("Line {0}: Gift Cert No {1} already exists in the database.", lineNumber, gc.GiftCertNo));

                    if (!string.IsNullOrEmpty(gc.GcTypeName))
                    {
                        if (gc.GcTypeName.Trim().ToLower() == "regular gc")
                        {
                            if (gc.GiftCertNo == 0 || gc.Value == 0 || servicesRecords.Count() == 0)
                                response.ErrorMsg.Add(String.Format("Line {0}: Regular GC requires Gift Cert No, GC Type, Value and Services.", lineNumber));
                            if (!string.IsNullOrEmpty(gc.DtiPermitNo) || gc.ExpirationDate != DateTime.MinValue || outletRecords.Count() > 0)
                                response.ErrorMsg.Add(String.Format("Line {0}: Regular GC restricts DTI Permit No, Expiration Date and Oulet.", lineNumber));
                        }

                        if (gc.GcTypeName.Trim().ToLower() == "corporate gc")
                        {
                            if (gc.GiftCertNo == 0 || gc.Value == 0 || servicesRecords.Count() == 0 || gc.ExpirationDate == DateTime.MinValue)
                                response.ErrorMsg.Add(String.Format("Line {0}: Corporate GC requires Gift Cert No, GC Type, Value, Expiration Date and Services.", lineNumber));
                            if (!string.IsNullOrEmpty(gc.DtiPermitNo) || outletRecords.Count() > 0)
                                response.ErrorMsg.Add(String.Format("Line {0}: Corporate GC restricts DTI Permit No and Oulet.", lineNumber));
                        }

                        if (gc.GcTypeName.Trim().ToLower() == "promotional gc")
                        {
                            if (gc.GiftCertNo == 0 || gc.Value == 0 || servicesRecords.Count() == 0 || string.IsNullOrEmpty(gc.DtiPermitNo) || gc.ExpirationDate == DateTime.MinValue || outletRecords.Count() == 0)
                                response.ErrorMsg.Add(String.Format("Line {0}: Promotional GC requires all fields.", lineNumber));
                        }
                    }
                 
                    //expiry date greater than purchase 
                    if (gc.ExpirationDate != DateTime.MinValue && gc.IssuanceDate != DateTime.MinValue)
                    {
                        if (gc.ExpirationDate < gc.IssuanceDate)
                            response.ErrorMsg.Add(String.Format("Line {0}: Expiration date must be greater than Issuance date.", lineNumber));
                    }

                    if (response.ErrorMsg.Count > 0)
                        response.IsValid = false;
                }
            }
            return response;
        }

        #region snippet1
        [HttpPost("ImportGc")]
        public async Task<IActionResult> Post(List<IFormFile> files)
        {
            try
            {
                var errorMsg = string.Empty;

                if (files.Count < 1)
                {
                    errorMsg = "Excel file is required.";
                    ModelState.AddModelError(string.Empty, errorMsg);
                }
                else
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

                    if (response.ErrorMsg.Count > 0)
                    {
                        foreach (var msg in response.ErrorMsg)
                        {
                            ModelState.AddModelError(string.Empty, msg);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            if (!ModelState.IsValid)
                return View("Index");

            _toastNotification.AddSuccessToastMessage("Imported successfully");
            return RedirectToAction("Index", "GiftCert");
        }

        bool IsSequential(int[] array)
        {
            return array.Zip(array.Skip(1), (a, b) => (a + 1) == b).All(x => x);
        }

        public static bool IsCharDigit(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private bool IsValidDateFormat(string date)
        {
            date = date.Split(" ")[0].ToString();
            if (string.IsNullOrEmpty(date))
                return true;

            DateTime Test;
            if (DateTime.TryParseExact(date, "M/d/yyyy", null, DateTimeStyles.None, out Test) == true)
                return true;
            else
                return false;
        }

        private ValidationResponse ValidateColumnHeaders(ValidationResponse response, int ColCount, ExcelWorksheet worksheet)
        {
            var rawValidationText = string.Empty;

            for (int row = 1; row <= 1; row++)
            {
                for (int col = 1; col <= ColCount; col++)
                {
                    if (worksheet.Cells[row, col].Value != null)
                    {
                        rawValidationText = worksheet.Cells[row, col].Value.ToString().ToLower().Trim();
                        if (col == 1)
                        {
                            if (rawValidationText != "gift cert no")
                                response.ErrorMsg.Add("Column A: The column heading should be 'Gift Cert No'.");
                        }
                        else if (col == 2)
                        {
                            if (rawValidationText != "gc type")
                                response.ErrorMsg.Add("Column B: The column heading should be 'GC Type'.");
                        }
                        else if (col == 3)
                        {
                            if (rawValidationText != "value")
                                response.ErrorMsg.Add("Column C: The column heading should be 'Value'.");
                        }
                        else if (col == 4)
                        {
                            if (rawValidationText != "issuance date")
                                response.ErrorMsg.Add("Column D: The column heading should be 'Issuance Date'.");
                        }
                        else if (col == 5)
                        {
                            if (rawValidationText != "services")
                                response.ErrorMsg.Add("Column E: The column heading should be 'Services'.");
                        }
                        else if (col == 6)
                        {
                            if (rawValidationText != "note")
                                response.ErrorMsg.Add("Column F: The column heading should be 'Note'.");
                        }
                        else if (col == 7)
                        {
                            if (rawValidationText != "dti permit no")
                                response.ErrorMsg.Add("Column G: The column heading should be 'DTI Permit No'.");
                        }
                        else if (col == 8)
                        {
                            if (rawValidationText != "expiration date")
                                response.ErrorMsg.Add("Column H: The column heading should be 'Expiration Date'.");
                        }
                        else if (col == 9)
                        {
                            if (rawValidationText != "outlet")
                                response.ErrorMsg.Add("Column I: The column heading should be 'Outlet'.");
                        }
                    }
                    else
                    {
                        var emptyColumnErr = "Line 1: Column headings cannot be empty.";
                        if (!response.ErrorMsg.Contains(emptyColumnErr))
                            response.ErrorMsg.Add(emptyColumnErr);
                    }
                }
            }

            if (response.ErrorMsg.Count > 0)
                response.IsValid = false;

            return response;
        }

        private string ServiceSetVar(string servicesRecord, GiftCertDto gc, List<OutletDto> outletList)
        {
            var outlet = outletList.FirstOrDefault() != null ? outletList.FirstOrDefault().Name : string.Empty;
            servicesRecord = servicesRecord.Replace("@Value", "@Value".ToLower());
            servicesRecord = servicesRecord.Replace("@Outlet", "@Outlet".ToLower());
            servicesRecord = servicesRecord.Replace("@ExpirationDate", "@ExpirationDate".ToLower());

            servicesRecord = servicesRecord.Replace("@Value".ToLower(), gc.Value.ToString());
            servicesRecord = servicesRecord.Replace("@Outlet".ToLower(), outlet);
            var expirationDate = gc.ExpirationDate != null ? Convert.ToDateTime(gc.ExpirationDate).ToShortDateString() : string.Empty;
            servicesRecord = servicesRecord.Replace("@ExpirationDate".ToLower(), expirationDate);

            return servicesRecord;
        }

        public ValidationResponse BulkCopy(string filePath)
        {
            var response = new ValidationResponse();

            response = ValidateExcelFile(filePath);

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

                //validate column headers
                response = ValidateColumnHeaders(response, ColCount, worksheet);

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

                for (int i = 0; i < records.Count; i++)
                {
                    var record = records[i];
                    var lineNumber = i + 2;

                    if (string.IsNullOrEmpty(record))
                        break;

                    var gc = new GiftCertDto();
                    var gcTypeItems = new List<string> { "regular gc", "promotional gc", "corporate gc" };
                    string[] textpart = record.Split('|');
                                  
                    if (textpart[0] != string.Empty && IsCharDigit(textpart[0].ToString()))
                        gc.GiftCertNo = Convert.ToInt32(textpart[0]);
                    if (gcTypeItems.Contains(textpart[1].ToLower().Trim()))
                        gc.GcTypeName = textpart[1].Trim();
                    if (textpart[2] != string.Empty && IsCharDigit(textpart[2].ToString()))
                        gc.Value = Convert.ToDecimal(textpart[2]);
                    if (textpart[3] != string.Empty && IsValidDateFormat(textpart[3]))
                        gc.IssuanceDate = Convert.ToDateTime(textpart[3]);
                    gc.Note = textpart[5];
                    gc.DtiPermitNo = textpart[6];
                    if (textpart[7] != string.Empty && IsValidDateFormat(textpart[7]))
                        gc.ExpirationDate = Convert.ToDateTime(textpart[7]);

                    var outletList = new List<OutletDto>();
                    string[] outletRecords = textpart[8].Split(';');

                    foreach (string outletRecord in outletRecords)
                    {
                        var outlet = new OutletDto();
                        outlet.Name = outletRecord;
                        outletList.Add(outlet);
                    }

                    var servicesList = new List<ServicesTypeDto>();
                    string[] servicesRecords = textpart[4].Split(';');

                    foreach (string servicesRecord in servicesRecords)
                    {
                        var servicesType = new ServicesTypeDto();
                        servicesType.Name = ServiceSetVar(servicesRecord, gc, outletList);
                        servicesList.Add(servicesType);
                    }
                                                       
                    //Outlets - Promotional GC:
                    var outletItems = new List<string> { "café marco", "wellness zone spa", "rooms" };
                    if (outletList.Where(o => !string.IsNullOrEmpty(o.Name)).Select(o => o.Name.ToLower().Trim()).Except(outletItems).Any())
                        response.ErrorMsg.Add(String.Format("Line {0}: Promotional GC should contains only Café Marco, Wellness Zone Spa and Rooms.", lineNumber));

                    gc.Services = servicesList;
                    gc.Outlets = outletList;

                    gcList.Add(gc);
                }

                //validate sequential gcno
                var isSequential = IsSequential(gcList.Select(m => m.GiftCertNo).ToArray());
                if (!isSequential)
                    response.ErrorMsg.Add("Column A: GC Number should be sequenced.");

                if (response.ErrorMsg.Count > 0)
                {
                    _toastNotification.AddErrorToastMessage("Your Import has failed.");
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
                    giftCert.IssuanceDate = gc.IssuanceDate;
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

                        if (outlet.Name.Replace(" ", "") == OutletOptions.WellnessZoneSpa.ToString())
                            gcOutlet.OutletId = (int)OutletOptions.WellnessZoneSpa;
                        if (outlet.Name.Replace(" ", "") == OutletOptions.Rooms.ToString())
                            gcOutlet.OutletId = (int)OutletOptions.Rooms;
                        if (outlet.Name.Replace(" ", "") == OutletOptions.BluBarAndGrill.ToString())
                            gcOutlet.OutletId = (int)OutletOptions.BluBarAndGrill;

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
            return response;
        }
        #endregion
    }
}