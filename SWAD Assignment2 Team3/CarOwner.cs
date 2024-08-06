using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CODI, S10241842
public class CarOwner : User
{
    private List<Vehicle> vehicleList;
    private float ownerEarnings;

    public List<Vehicle> VehicleList
    {
        get { return vehicleList; }
        set { vehicleList = value; }
    }
    private float OwnerEarnings
    {
        get { return ownerEarnings; }
        set { ownerEarnings = value; }
    }

    public CarOwner() { }
    public CarOwner(string userName, string userContact, DateTime userDOB, string userDriversLicense, string userStatus, int userID, string userAddress, List<Vehicle> vehicles, float ownerEarnings) : base(userName, userContact, userDOB, userDriversLicense, userStatus, userID, userAddress)
    {
        this.vehicles = vehicles;
        this.ownerEarnings = ownerEarnings;
    }

    private List<Vehicle> vehicles;
    public void addVehicle(Vehicle v) {
        if (!vehicles.Contains(v)) {
            vehicles.Add(v);
            v.CarOwner = this;
        }
    }
}