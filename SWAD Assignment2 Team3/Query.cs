using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_Assignment2_Team3
{
    class Query
    {
        private string queryID;
        private string userID;
        private DateTime queryDate;
        private string queryStatus;
        private string queryDescription;

        public string QueryID { get; set; }
        public string UserID { get; set; }
        public DateTime QueryDate { get; set; }
        public string QueryStatus { get; set; }
        public string QueryDescription { get; set; }

        public Query() { }
        public Query(string qID, string uID, DateTime qDate, string qStatus, string qDescription)
        {
            queryID = qID;
            userID = uID;
            queryDate = qDate;
            queryStatus = qStatus;
            queryDescription = qDescription;
        }

        // CustomerServiceRep MULTIPLICITY (0..*:1)
        // ====================
        private CustomerServiceRep customerServiceRep;
        public CustomerServiceRep CustomerServiceRep
        {
            set
            {
                if (customerServiceRep != value)
                {
                    customerServiceRep = value;
                    value.addQuery(this);
                }
            }
        }

        // User MULTIPLICITY (0..*:1)
        // ====================
        private User user;
        public User User
        {
            set
            {
                if (user != value)
                {
                    user = value;
                    value.addQuery(this);
                }
            }
        }
    }
}
