using System;
using System.Collections.Generic;

namespace GiftCertWeb.Models
{
    public partial class GcPurchase
    {
        public int Id { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Active { get; set; }
        public string Remarks { get; set; }
        public string PaymentMode { get; set; }
        public string CcNumber { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string CardType { get; set; }
        public int? GiftCertNo { get; set; }

        public GiftCert GiftCertNoNavigation { get; set; }
    }
}
