using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_Assignment2_Team3
{
    class CarRenter
    {
        public string renterTier { get; set; }
        public string paymentMethod { get; set; }
        public string bookingHistory { get; set; }

        public CarRenter() { }
        public CarRenter(string rTier, string pMethod, string bHistory)
        {
            renterTier = rTier;
            paymentMethod = pMethod;
            bookingHistory = bHistory;
        }
    }
}
