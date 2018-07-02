using System;
using System.Collections.Generic;

namespace GiftCertWeb.Models
{
    public partial class GcPurchase
    {
        public int Id { get; set; }
        public int? PurchaseId { get; set; }
        public int? GiftCertNo { get; set; }

        public GiftCert GiftCertNoNavigation { get; set; }
        public Purchase Purchase { get; set; }
    }
}
