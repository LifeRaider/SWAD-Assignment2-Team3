using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CODI, S10241842
public class CarOwner : User
{
    private List<Vehicle> vehicles;
    private float ownerEarnings;

    public List<Vehicle> Vehicles
    {
        get { return vehicles; }
        set { vehicles = value; }
    }
    private float OwnerEarnings
    {
        get { return ownerEarnings; }
        set { ownerEarnings = value; }
    }

    public CarOwner() { }
    public CarOwner(List<Vehicle> vehicles, float ownerEarnings)
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