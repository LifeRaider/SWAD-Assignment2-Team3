using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_Assignment2_Team3
{
    class Query
    {
        public string queryID { get; set; }
        public string userID { get; set; }
        public DateTime queryDate { get; set; }
        public string queryStatus { get; set; }
        public string queryDescription { get; set; }

        public Query() { }
        public Query(string qID, string uID, DateTime qDate, string qStatus, string qDescription)
        {
            queryID = qID;
            userID = uID;
            queryDate = qDate;
            queryStatus = qStatus;
            queryDescription = qDescription;
        }
    }
}
