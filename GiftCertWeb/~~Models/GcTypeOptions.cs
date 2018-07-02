using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftCertWeb.Models
{
    [Flags]
    public enum GcTypeOptions
    {
        RegularGC = 1,
        PromotionalGC = 2,
        CorporateGC = 3
    }
}
