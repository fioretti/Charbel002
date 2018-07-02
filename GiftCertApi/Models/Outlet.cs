using System;
using System.Collections.Generic;

namespace GiftCertApi.Models
{
    public partial class Outlet
    {
        public Outlet()
        {
            GcOutlet = new HashSet<GcOutlet>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Active { get; set; }

        public ICollection<GcOutlet> GcOutlet { get; set; }
    }
}
