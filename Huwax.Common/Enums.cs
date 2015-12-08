using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huwax.Common
{
    public static class Enums
    {
        public enum UserRole
        {
            Admin = 1,
            Otomasyon = 2,
            Finans = 3,
            Satıs = 4,
            Lojistik = 5,
            Arac = 6,
            Sofor = 7,
            Yonetim = 8,
            SahaMuduru = 9,
            Bayi = 10
        }
        public enum VehicleType
        {
            Otomobil=1,
            Minibus=2,
            Motosiklet=3,
            Ticari=4,


        }
        public enum Enterprice
        {
            Kurumsal=1,
            Bireysel=2
        }


    }
}
