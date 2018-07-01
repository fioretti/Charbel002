using System;
using System.Collections.Generic;
using System.Text;

namespace GiftCert.Core.Model
{
    public class GcRedemption
    {
        public int Id { get; set; }
        public DateTime? RedemptionDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedDate { get; set; }
        public bool? Active { get; set; }
        public string Remarks { get; set; }
        public int? GiftCertNo { get; set; }

        public GiftCert GiftCertNoNavigation { get; set; }

    }
}
