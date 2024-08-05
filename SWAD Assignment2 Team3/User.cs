using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CODI, S10241842
namespace SWAD_ASG2_CMT
{
    public class User
    {
        // Private Attributes
        private string userName;
        private string userContact;
        private DateTime userDOB;
        private string userDriversLicense;
        private string userStatus;
        private int userID;
        private string userAddress;

        // Private attributes for multiplicties
        private List<Query> queries;
        private List<CarRenter> carRenters;
        private List<CarOwner> carOwners;
        private List<Admin> admins;

        // Public Properties
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string UserContact
        {
            get { return userContact; }
            set { userContact = value; }
        }

        public DateTime UserDOB
        {
            get { return userDOB; }
            set { userDOB = value; }
        }

        public string UserDriversLicense
        { 
            get { return userDriversLicense; }
            set { userDriversLicense = value; }
        }

        public string UserStatus
        {
            get { return userStatus; }
            set { userStatus = value; }
        }

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public string UserAddress
        {
            get { return userAddress; }
            set { userAddress = value; }
        }

        // Public properties for multiplicties
        public List<Query> Queries
        {
            get { return queries; }
        }

        public List<CarRenter> CarRenters
        {
            get { return carRenters; }
        }

        public List<CarOwner> CarOwners
        {
            get { return carOwners; }
        }

        public List<Admin> Admins
        {
            get { return admins; }
        }

        // Constructors
        public User(string n, string c, DateTime d, string u, string us, int i, string a)
        {
            userName = n;
            userContact = c;
            userDOB = d;
            userDriversLicense = u;
            userStatus = us;
            userID = i;
            userAddress = a;
            queries = new List<Query>();
            carRenters = new List<CarRenter>();
            carOwners = new List<CarOwner>();
            admins = new List<Admin>();
        }

        // Methods
        // Methods to Manage Queries
        public void AddQuery(Query query)
        {
            if (!queries.Contains(query))
            {
                queries.Add(query);
            }
        }

        public void RemoveQuery(Query query)
        {
            queries.Remove(query);
        }

        // Methods to Manage CarRenters
        public void AddCarRenter(CarRenter carRenter)
        {
            if (!carRenters.Contains(carRenter))
            {
                carRenters.Add(carRenter);
            }
        }

        public void RemoveCarRenter(CarRenter carRenter)
        {
            carRenters.Remove(carRenter);
        }

        // Methods to Manage CarOwners
        public void AddCarOwner(CarOwner carOwner)
        {
            if (!carOwners.Contains(carOwner))
            {
                carOwners.Add(carOwner);
            }
        }

        public void RemoveCarOwner(CarOwner carOwner)
        {
            carOwners.Remove(carOwner);
        }

        // Methods to Manage Admins
        public void AddAdmin(Admin admin)
        {
            if (!admins.Contains(admin))
            {
                admins.Add(admin);
            }
        }

        public void RemoveAdmin(Admin admin)
        {
            admins.Remove(admin);
        }

    }
}
