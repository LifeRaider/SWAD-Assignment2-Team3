// HENG WEI JIAN MARVIN (S10260527)

using System;
using System.Collections.Generic;

public class Vehicle
{
    // Attributes
    private string vehicleID;
    private string vehicleMake;
    private string vehicleModel;
    private int vehicleYear;
    private int vehicleMileage;
    private List<string> vehiclePhotos;
    private string userID;
    private double rentalRate;
    private string availabilitySchedule;
    private string vehicleStatus;
    private string listingDescription;
    private string listingID;

    // Relationships
    private CarOwner owner;
    private List<Reservation> reservations;
    private List<Insurance> insurancePolicies;
    private List<VehicleInspection> inspections;

    // Constructor
    public Vehicle(string id, string make, string model, int year, int mileage, string ownerId)
    {
        this.vehicleID = id;
        this.vehicleMake = make;
        this.vehicleModel = model;
        this.vehicleYear = year;
        this.vehicleMileage = mileage;
        this.userID = ownerId;
        this.vehiclePhotos = new List<string>();
        this.reservations = new List<Reservation>();
        this.insurancePolicies = new List<Insurance>();
        this.inspections = new List<VehicleInspection>();
    }

    // Properties
    public string VehicleID
    {
        get { return vehicleID; }
        private set { vehicleID = value; }
    }

    public string VehicleMake
    {
        get { return vehicleMake; }
        set { vehicleMake = value; }
    }

    public string VehicleModel
    {
        get { return vehicleModel; }
        set { vehicleModel = value; }
    }

    public int VehicleYear
    {
        get { return vehicleYear; }
        set { vehicleYear = value; }
    }

    public int VehicleMileage
    {
        get { return vehicleMileage; }
        set { vehicleMileage = value; }
    }

    public List<string> VehiclePhotos
    {
        get { return vehiclePhotos; }
        set { vehiclePhotos = value; }
    }

    public string UserID
    {
        get { return userID; }
        set { userID = value; }
    }

    public double RentalRate
    {
        get { return rentalRate; }
        set { rentalRate = value; }
    }

    public string AvailabilitySchedule
    {
        get { return availabilitySchedule; }
        set { availabilitySchedule = value; }
    }

    public string VehicleStatus
    {
        get { return vehicleStatus; }
        set { vehicleStatus = value; }
    }

    public string ListingDescription
    {
        get { return listingDescription; }
        set { listingDescription = value; }
    }

    public string ListingID
    {
        get { return listingID; }
        set { listingID = value; }
    }

    // Methods
    public void AddPhoto(string photoUrl)
    {
        vehiclePhotos.Add(photoUrl);
    }

    public void SetOwner(CarOwner owner)
    {
        this.owner = owner;
    }

    public void AddReservation(Reservation reservation)
    {
        reservations.Add(reservation);
    }

    public void AddInsurancePolicy(Insurance insurance)
    {
        insurancePolicies.Add(insurance);
    }

    public void AddInspection(VehicleInspection inspection)
    {
        inspections.Add(inspection);
    }

    // Other methods as needed...
}