using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftCertWeb.Models
{
    [Flags]
    public enum GcCodeValueOptions
    {      
        M = 1,
        A = 2,
        R = 3,
        C = 4,
        O = 5,
        P = 6,      
        L = 7,           
        E = 8,
        B = 9,
        U = 0
    }
}
