using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CODI, S10241842
namespace SWAD_ASG2_CMT
{
    public class Admin
    {
        // Private Attributes
        private int adminID;
        private string adminName;
        private string adminContact;
        private string adminRole;
        // Private attributes for multiplicties
        private List<User> users;
        private List<Vehicle> vehicles;
        private List<VehicleInspection> vehicleInspections;

        // Public Properties
        public int AdminID
        {
            get { return adminID; }
            set { adminID = value; }
        }

        public string AdminName
        {
            get { return adminName; }
            set { adminName = value; }
        }

        public string AdminContact
        {
            get { return adminContact; }
            set { adminContact = value; }
        }

        public string AdminRole
        {
            get { return adminRole; }
            set { adminRole = value; }
        }

        // Public properties for multiplicties
        public List<User> Users
        {
            get { return users; }
        }

        public List<Vehicle> Vehicles
        {
            get { return vehicles; }
        }

        public List<VehicleInspection> VehicleInspections
        {
            get { return vehicleInspections; }
        }

        // Constructor
        public Admin (int i, string n, string c, string r)
        {
            adminID = i;
            adminName = n;
            adminContact = c;
            adminRole = r;
            users = new List<User>();
            vehicles = new List<Vehicle>();
            vehicleInspections = new List<VehicleInspection>();
        }

        // Methods
        // Methods to Manage Multiplicity
        public void AddUser(User user)
        {
            users.Add(user);
        }

        public void RemoveUser(User user)
        {
            users.Remove(user);
        }

        public void AddVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
        }

        public void RemoveVehicle(Vehicle vehicle)
        {
            vehicles.Remove(vehicle);
        }

        public void AddVehicleInspection(VehicleInspection inspection)
        {
            vehicleInspections.Add(inspection);
        }

        public void RemoveVehicleInspection(VehicleInspection inspection)
        {
            vehicleInspections.Remove(inspection);
        }
    }
}
