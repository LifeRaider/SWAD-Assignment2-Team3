using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_Assignment2_Team3
{
    class Admin
    {
        public string adminID { get; set; }
        public string adminName { get; set; }
        public string adminContact { get; set; }
        public string adminRole { get; set; }

        public Admin() { }
        public Admin(string aID, string anName, string aContact, string aRole)
        {
            adminID = aID;
            adminName = anName;
            adminContact = aContact;
            adminRole = aRole;
        }
    }
}
