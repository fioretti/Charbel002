using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftCertWeb.Models.Dto
{
    public class ValidationResponse
    {
        public List<string> ErrorMsg { get; set; } = new List<string>();
        public bool IsValid { get; set; } = true;
      
    }
}
