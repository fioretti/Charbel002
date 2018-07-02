using System;
using System.Collections.Generic;

namespace GiftCertApi.Models
{
    public partial class ServicesType
    {
        public int Id { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }
        public int? GiftCertNo { get; set; }

        public GiftCert GiftCertNoNavigation { get; set; }
    }
}
