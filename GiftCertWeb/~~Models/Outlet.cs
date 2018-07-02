using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GiftCertWeb.Models
{
    public partial class Outlet
    {
        public Outlet()
        {
            GcOutlet = new HashSet<GcOutlet>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Active { get; set; }

        public ICollection<GcOutlet> GcOutlet { get; set; }
    }
}
