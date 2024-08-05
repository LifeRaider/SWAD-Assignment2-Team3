using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_Assignment2_Team3
{
    class Payment
    {
        public string paymentID { get; set; }
        public string reservationID { get; set; }
        public string paymentMethod { get; set; }
        public decimal paymentAmount { get; set; }
        public DateTime paymentDate { get; set; }
        public string paymentStatus { get; set; }
        public PrimeDiscount primeDiscount { get; set; }
        public decimal penaltyAmount { get; set; }

        public Payment() { }
        public Payment(string pID, string resID, string pMethod, decimal pAmount, DateTime pDate, string pStatus, PrimeDiscount pDiscount, decimal pPenalty)
        {
            paymentID = pID;
            reservationID = resID;
            paymentMethod = pMethod;
            paymentAmount = pAmount;
            paymentDate = pDate;
            paymentStatus = pStatus;
            primeDiscount = pDiscount;
            penaltyAmount = pPenalty;
        }
    }
}
