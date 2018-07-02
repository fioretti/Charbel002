using System;
using System.Collections.Generic;

namespace GiftCertApi.Models
{
    public partial class GcOutlet
    {
        public int Id { get; set; }
        public int? OutletId { get; set; }
        public int? GiftCertNo { get; set; }

        public GiftCert GiftCertNoNavigation { get; set; }
        public Outlet Outlet { get; set; }
    }
}
