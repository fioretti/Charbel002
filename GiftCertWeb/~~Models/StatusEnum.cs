using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftCertWeb.Models
{
    [Flags]
    public enum StatusEnum
    {
        Unsold = 1,
        Sold = 2,
        Voided = 3,
        Expired = 4,
        Availed = 5   
    }
}
