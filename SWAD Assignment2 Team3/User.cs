using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_Assignment2_Team3
{
    class User
    {
        public string userName { get; set; }
        public string userContact { get; set; }
        public DateTime userDOB { get; set; }
        public string userDriversLicense { get; set; }
        public string userStatus { get; set; }
        public string userID { get; set; }
        public string userAddress { get; set; }

        public User(string uName, string uContact, DateTime uDOB, string uDriversLicense, string uStatus, string uID, string uAddress)
        {
            userName = uName;
            userContact = uContact;
            userDOB = uDOB;
            userDriversLicense = uDriversLicense;
            userStatus = uStatus;
            userID = uID;
            userAddress = uAddress;
        }

        // Query MULTIPLICITY (1:0..*)
        // ====================
        private List<Query> queries;
        public User()
        {
            queries = new List<Query>();
        }
        public void addQuery(Query q)
        {
            if (!queries.Contains(q))
            {
                queries.Add(q);
                q.User = this;
            }
        }
    }
}
