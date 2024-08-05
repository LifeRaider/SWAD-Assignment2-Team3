using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_Assignment2_Team3
{
    class PrimeDiscount
    {
        public double monthlyRentalDiscount { get; set; }
        public double roadsideAssistanceDiscount { get; set; }
        public decimal minimumMonthlyRental { get; set; }

        public PrimeDiscount() { }
        public PrimeDiscount(double mDiscount, double rDiscount, decimal mRental)
        {
            monthlyRentalDiscount = mDiscount;
            roadsideAssistanceDiscount = rDiscount;
            minimumMonthlyRental = mRental;
        }
    }
}
