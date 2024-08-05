using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_Assignment2_Team3
{
    class AccidentReport
    {
        public string reportID { get; set; }
        public string reservationID { get; set; }
        public DateTime reportDate { get; set; }
        public string reportStatus { get; set; }
        public string reportDescription { get; set; }

        public AccidentReport() { }
        public AccidentReport(string rID, string resID, DateTime rDate, string rStatus, string rDescription)
        {
            reportID = rID;
            reservationID = resID;
            reportDate = rDate;
            reportStatus = rStatus;
            reportDescription = rDescription;
        }
    }
}
