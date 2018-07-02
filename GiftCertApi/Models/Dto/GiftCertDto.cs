using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftCertApi.Models.Dto
{
    public class GiftCertDto
    {
        public int? GcTypeId { get; set; }
        public decimal? Value { get; set; }
        public DateTime? IssuanceDate { get; set; }
        public string DtiPermitNo { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string QrCode { get; set; }
        public string Note { get; set; }
        public int? Status { get; set; }
        public int GiftCertNo { get; set; }
    }
}
