using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_Assignment2_Team3
{
    class Vehicle
    {
        public string vehicleID { get; set; }
        public string vehicleMake { get; set; }
        public string vehicleModel { get; set; }
        public int vehicleYear { get; set; }
        public int vehicleMileage { get; set; }
        public List<string> vehiclePhotos { get; set; }
        public string userID { get; set; }
        public double rentalRate { get; set; }
        public string availabilitySchedule { get; set; }
        public string vehicleStatus { get; set; }
        public string listingDescription { get; set; }
        public string listingID { get; set; }

        public Vehicle() { }
        public Vehicle(string vID, string vMake, string vModel, int vYear, int vMileage, List<string> vPhotos, string uID,
            double rRate, string aSchedule, string vStatus, string lDescription, string lID)
        {
            vehicleID = vID;
            vehicleMake = vMake;
            vehicleModel = vModel;
            vehicleYear = vYear;
            vehicleMileage = vMileage;
            vehiclePhotos = vPhotos;
            userID = uID;
            rentalRate = rRate;
            availabilitySchedule = aSchedule;
            vehicleStatus = vStatus;
            listingDescription = lDescription;
            listingID = lID;
        }

        /* add the method later */
    }
}
