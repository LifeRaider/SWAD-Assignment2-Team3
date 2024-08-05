using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_Assignment2_Team3
{
    class Company
    {
        public string companyName { get; set; }
        public string companyAddress { get; set; }
        public string companyUEN { get; set; }
        public string companyContact { get; set; }

        public Company() { }
        public Company(string cName, string cAddress, string cUEN, string cContact)
        {
            companyName = cName;
            companyAddress = cAddress;
            companyUEN = cUEN;
            companyContact = cContact;
        }
    }
}
