using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_Assignment2_Team3
{
    class Insurance
    {
        public string insuranceID { get; set; }
        public string providerName { get; set; }
        public string policyNumber { get; set; }
        public string coverageDetail { get; set; }
        public DateTime expiryDate { get; set; }
        public string vehicleID { get; set; }

        public Insurance() { }
        public Insurance(string iID, string pName, string pNumber, string cDetail, DateTime eDate, string vID)
        {
            insuranceID = iID;
            providerName = pName;
            policyNumber = pNumber;
            coverageDetail = cDetail;
            expiryDate = eDate;
            vehicleID = vID;
        }
    }
}
