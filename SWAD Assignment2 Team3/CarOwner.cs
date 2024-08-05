using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CODI, S10241842
namespace SWAD_ASG2_CMT
{
    public class CarOwner : User
    {
        // Private Attributes
        private List<Vehicle> vehicleList;
        private double ownerEarnings;

        // Public Properties
        public List<Vehicle> VehicleList
        {
            get { return vehicleList; }
        }

        public double OwnerEarnings
        {
            get { return ownerEarnings; }
            set { ownerEarnings = value; }
        }

        // Constructor
        public CarOwner(string n, string c, DateTime d, string u, string us, int i, string a)
            : base(n, c, d, u, us, i, a)
        {
            vehicleList = new List<Vehicle>();
            ownerEarnings = 0.0;
        }

        // Methods to Manage vehicleList
        public void AddVehicle(Vehicle vehicle)
        {
            if (!vehicleList.Contains(vehicle))
            {
                vehicleList.Add(vehicle);
            }
        }

        public void RemoveVehicle(Vehicle vehicle)
        {
            vehicleList.Remove(vehicle);
        }

        public Vehicle GetVehicleById(int id)
        {
            return vehicleList.FirstOrDefault(v => v.VehicleID == id);
        }
    }
}
