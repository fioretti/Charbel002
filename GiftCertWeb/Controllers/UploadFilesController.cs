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
using OfficeOpenXml;

namespace GiftCertWeb.Controllers
{
    public class UploadFilesController : Controller
    {
        public static IConfiguration Configuration;
        private readonly IHostingEnvironment _hostingEnvironment;
        public UploadFilesController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        #region snippet1
        [HttpPost("UploadFiles")]
        public async Task<IActionResult> Post(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            // full path to file in temp location
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

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            BulkCopy(filePath);

            //return Ok(new { count = files.Count, size, filePath });
            return RedirectToAction("Index", "GiftCert");
        }

        public void BulkCopy(string filePath)
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
                    gc.GcTypeName = textpart[1];
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

                //sql entity
                var giftCerts = new List<GiftCert>();
                var gcOutlets = new List<GcOutlet>();
                var services = new List<ServicesType>();

                foreach (var gc in gcList)
                {
                    var giftCert = new GiftCert();

                    if (gc.GcTypeName.Replace(" ", "") == GcTypeOptions.RegularGC.ToString())
                        giftCert.GcTypeId = (int)GcTypeOptions.RegularGC;
                    if (gc.GcTypeName.Replace(" ", "") == GcTypeOptions.PromotionalGC.ToString())
                        giftCert.GcTypeId = (int)GcTypeOptions.PromotionalGC;
                    if (gc.GcTypeName.Replace(" ", "") == GcTypeOptions.CorporateGC.ToString())
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
        #endregion
    }
}