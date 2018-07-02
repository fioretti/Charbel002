using System;
using System.Collections.Generic;

namespace GiftCertWeb.Models
{
    public partial class GcRedemption
    {
        public int Id { get; set; }
        public int? RedemptionId { get; set; }
        public int? GiftCertNo { get; set; }

        public GiftCert GiftCertNoNavigation { get; set; }
        public Redemption Redemption { get; set; }
    }
}
