using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_Assignment2_Team3
{
    class Reservation
    {
        public string reservationID { get; set; }
        public string userID { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string pickUpLocation { get; set; }
        public string returnLocation { get; set; }
        public string reservationStatus { get; set; }
        public double totalCost { get; set; }
        public string paidStatus { get; set; }
        public string listingID { get; set; }

        public Reservation() { }

        public Reservation(string rID, string uID, DateTime sDate, DateTime eDate, string pLocation, string rLocation, 
            string rStatus, double tCost, string pStatus, string lID)
        {
            reservationID = rID;
            userID = uID;
            startDate = sDate;
            endDate = eDate;
            pickUpLocation = pLocation;
            returnLocation = rLocation;
            reservationStatus = rStatus;
            totalCost = tCost;
            paidStatus = pStatus;
            listingID = lID;
        }


    }
}
