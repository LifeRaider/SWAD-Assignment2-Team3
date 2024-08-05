using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_Assignment2_Team3
{
    class CustomerServiceRep
    {
        public string repID { get; set; }
        public string repName { get; set; }
        public string repEmail { get; set; }
        public List<string> repQueries { get; set; }

        public CustomerServiceRep() { }
        public CustomerServiceRep(string rID, string rName, string rEmail, List<string> rQueries)
        {
            repID = rID;
            repName = rName;
            repEmail = rEmail;
            repQueries = rQueries;
        }
    }
}
