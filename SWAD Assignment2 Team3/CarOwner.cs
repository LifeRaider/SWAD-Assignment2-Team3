using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_Assignment2_Team3
{
    class CarOwner
    {
        public List<Vehicle> vehicleList { get; set; }
        public double ownerEarnings { get; set; }

        public CarOwner() { }
        public CarOwner(List<Vehicle> vList, double oEarnings)
        {
            vehicleList = vList;
            ownerEarnings = oEarnings;
        }
    }
}
