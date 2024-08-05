using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_Assignment2_Team3
{
    class VehicleInspection
    {
        public string inspectionID { get; set; }
        public string vehicleID { get; set; }
        public DateTime inspectionDate { get; set; }
        public string adminID { get; set; }
        public bool inspectionStatus { get; set; }
        public string inspectionComment { get; set; }

        public VehicleInspection() { }
        public VehicleInspection(string iID, string vID, DateTime iDate, string aID, bool iStatus, string iComment)
        {
            inspectionID = iID;
            vehicleID = vID;
            inspectionDate = iDate;
            adminID = aID;
            inspectionStatus = iStatus;
            inspectionComment = iComment;
        }
    }
}
