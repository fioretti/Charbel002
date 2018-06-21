using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace GiftCertWeb.Controllers
{
    [Authorize]
    public class DownloadTemplate : Controller
    {
        public static IConfiguration Configuration;
        private readonly IHostingEnvironment _hostingEnvironment;

        public DownloadTemplate(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        
        public IActionResult Index()
        {
            var fileName = "GcDetails.xlsx";
            string wwwrootPath = _hostingEnvironment.WebRootPath;

            IFileProvider provider = new PhysicalFileProvider(wwwrootPath);
            IFileInfo fileInfo = provider.GetFileInfo(fileName);
            var readStream = fileInfo.CreateReadStream();
            var mimeType = "application/vnd.ms-excel";
            return File(readStream, mimeType, fileName);
        }
           
    }
}