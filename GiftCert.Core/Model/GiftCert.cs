using System;
using System.Collections.Generic;
using System.Text;

namespace GiftCert.Core.Model
{
    public class GiftCert
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
       // public GcType GcType { get; set; }

        public string ExpirationDateStr
        {
            get
            {
                return ExpirationDate != null ? Convert.ToDateTime(ExpirationDate).ToShortDateString() : string.Empty;
            }
        }
        public string GcCodeValue { get; set; }

    }
}
