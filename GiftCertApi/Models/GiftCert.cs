using System;
using System.Collections.Generic;

namespace GiftCertApi.Models
{
    public partial class GiftCert
    {
        public GiftCert()
        {
            GcOutlet = new HashSet<GcOutlet>();
            GcPurchase = new HashSet<GcPurchase>();
            GcRedemption = new HashSet<GcRedemption>();
            ServicesType = new HashSet<ServicesType>();
        }

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

        public GcType GcType { get; set; }
        public ICollection<GcOutlet> GcOutlet { get; set; }
        public ICollection<GcPurchase> GcPurchase { get; set; }
        public ICollection<GcRedemption> GcRedemption { get; set; }
        public ICollection<ServicesType> ServicesType { get; set; }
    }
}
