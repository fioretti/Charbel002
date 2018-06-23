using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftCertWeb.Models
{
    [Flags]
    public enum OutletOptions
    {
        CaféMarco = 1,
        LobbyLounge = 2,
        ElViento = 3,
        WellnessZoneSpa = 5,
        Rooms = 7,
        BluBarAndGrill = 8
    }
}
