using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CODI, S10241842

public class Admin
{
    // Private Attributes
    private int adminID;
    private string adminName;
    private string adminContact;
    private string adminRole;

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

    public Admin() { }
    public Admin(int adminID, string adminName, string adminContact, string adminRole)
    {
        this.adminID = adminID;
        this.adminName = adminName;
        this.adminContact = adminContact;
        this.adminRole = adminRole;
    }

    // USERS MULTIPLICITY (1:0..*)
    private List<User> users;
    public void addUser(User u) {
        if (!users.Contains(u)) {
            users.Add(u);
            u.Admin = this;
        }
    }

    // VEHICLE MULTIPLICITY (1:0..*)
    private List<Vehicle> vehicles;
    public void addVehicle(Vehicle v) {
        if (!vehicles.Contains(v)) {
            vehicles.Add(v);
            v.Admin = this;
        }
    }

    // VEHICLEINSPECTION MULTIPLICITY (1:0..*)
    private List<VehicleInspection> vehicleInspections;
    public void addVehicleInspection(VehicleInspection vi) {
        if (!vehicleInspections.Contains(vi)) {
            vehicleInspections.Add(vi);
            vi.Admin = this;
        }
    }
    
    // Method for Reporting accident
    public void ReviewAccidentReport(AccidentReport report)
    {
        Console.WriteLine("\nAdmin reviewing accident report...");
        DispatchResponseTeam();
    }
    
    public void DispatchResponseTeam()
    {
        // Simulate dispatching a response team
        Console.WriteLine("\nDispatching response team...");
    }
}
