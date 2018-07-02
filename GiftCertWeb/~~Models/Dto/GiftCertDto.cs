using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftCertWeb.Models.Dto
{
    public class GiftCertDto
    {
        public int GiftCertNo { get; set; }
        public string GcTypeName { get; set; }
        public decimal? Value { get; set; }
        public List<ServicesTypeDto> Services { get; set; }
        public string Note { get; set; }
        public string DtiPermitNo { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime? IssuanceDate { get; set; }        
        public List<OutletDto> Outlets { get; set; }
    }
}
