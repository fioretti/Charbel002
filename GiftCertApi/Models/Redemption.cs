using System;
using System.Collections.Generic;

namespace GiftCertApi.Models
{
    public partial class Redemption
    {
        public Redemption()
        {
            GcRedemption = new HashSet<GcRedemption>();
        }

        public int Id { get; set; }
        public DateTime? RedemptionDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedDate { get; set; }
        public bool? Active { get; set; }
        public string Remarks { get; set; }

        public ICollection<GcRedemption> GcRedemption { get; set; }
    }
}
