using System;
using System.Collections.Generic;
using System.Linq;

public class RegisterVehicle
{
    private UI_RegisterVehicle ui;
    private CTL_RegisterVehicle controller;

    public RegisterVehicle()
    {
        ui = new UI_RegisterVehicle();
        controller = new CTL_RegisterVehicle();
    }

    public void RegisterNewVehicle(CarOwner owner)
    {
        ui.DisplayRegistrationForm();

        VehicleDetails details = ui.CollectVehicleDetails();
        List<string> photos = ui.CollectVehiclePhotos();
        string ownershipProof = ui.CollectOwnershipProof();
        string insuranceDetails = ui.CollectInsuranceDetails();

        bool isValid = controller.ValidateData(details, photos, ownershipProof, insuranceDetails);

        if (isValid)
        {
            ui.DisplayConfirmation(details, photos, ownershipProof, insuranceDetails);
            bool confirmed = ui.ConfirmDetails();

            if (confirmed)
            {
                Vehicle newVehicle = controller.CreateVehicle(details, photos, ownershipProof, insuranceDetails, owner.OwnerID);
                controller.SetStatusPendingApproval(newVehicle);

                ui.DisplaySubmission(newVehicle);
                ui.DisplayApprovalProcessInfo();

                controller.ApproveVehicle(newVehicle);
            }
        }
        else
        {
            List<string> errors = controller.GetErrors();
            foreach (string error in errors)
            {
                ui.DisplayError(error);
                ui.FixError(error);
            }
        }
    }

    // ... (rest of the code remains the same)
}

public class UI_RegisterVehicle
{
    // ... (previous code remains the same)

    public VehicleDetails CollectVehicleDetails()
    {
        VehicleDetails details = new VehicleDetails();
        details.VehicleMake = GetInput("Enter vehicle make: ", "make");
        details.VehicleModel = GetInput("Enter vehicle model: ", "model");
        details.VehicleYear = int.Parse(GetInput("Enter vehicle year: ", "year"));
        details.VehicleMileage = float.Parse(GetInput("Enter vehicle mileage: ", "mileage"));
        details.VIN = GetInput("Enter vehicle VIN: ", "vin");
        details.LicensePlate = GetInput("Enter vehicle license plate: ", "license");
        details.RentalRate = float.Parse(GetInput("Enter rental rate per day: ", "rentalRate"));
        details.AvailabilitySchedule = GetInput("Enter availability schedule: ", "availabilitySchedule");
        details.VehicleDescription = GetInput("Enter vehicle description: ", "description");
        return details;
    }

    // ... (rest of the code remains the same)
}

public class CTL_RegisterVehicle
{
    // ... (previous code remains the same)

    public Vehicle CreateVehicle(VehicleDetails details, List<string> photos, string ownershipProof, string insuranceDetails, string ownerID)
    {
        return new Vehicle
        {
            VehicleID = Guid.NewGuid().ToString(),
            VehicleMake = details.VehicleMake,
            VehicleModel = details.VehicleModel,
            VehicleYear = details.VehicleYear,
            VehicleMileage = details.VehicleMileage,
            VehiclePhotos = photos,
            UserID = ownerID,
            RentalRate = details.RentalRate,
            AvailabilitySchedule = details.AvailabilitySchedule,
            VehicleStatus = "Pending Approval",
            VehicleDescription = details.VehicleDescription,
            ListingID = Guid.NewGuid().ToString()
        };
    }

    // ... (rest of the code remains the same)
}

public class VehicleDetails
{
    public string VehicleMake { get; set; }
    public string VehicleModel { get; set; }
    public int VehicleYear { get; set; }
    public float VehicleMileage { get; set; }
    public string VIN { get; set; }
    public string LicensePlate { get; set; }
    public float RentalRate { get; set; }
    public string AvailabilitySchedule { get; set; }
    public string VehicleDescription { get; set; }
}

public class Vehicle
{
    public string VehicleID { get; set; }
    public string VehicleMake { get; set; }
    public string VehicleModel { get; set; }
    public int VehicleYear { get; set; }
    public float VehicleMileage { get; set; }
    public List<string> VehiclePhotos { get; set; }
    public string UserID { get; set; }
    public float RentalRate { get; set; }
    public string AvailabilitySchedule { get; set; }
    public string VehicleStatus { get; set; }
    public string VehicleDescription { get; set; }
    public string ListingID { get; set; }

    // Relationships
    public VehicleInspection VehicleInspection { get; set; }
    public CarOwner CarOwner { get; set; }
    public List<Insurance> Insurances { get; set; } = new List<Insurance>();
    public List<Reservation> Reservations { get; set; } = new List<Reservation>();

    // ... (other methods from the original Vehicle class)
}

public class CarOwner
{
    public string OwnerID { get; set; } = Guid.NewGuid().ToString();
    public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

    public void addVehicle(Vehicle vehicle)
    {
        if (!Vehicles.Contains(vehicle))
        {
            Vehicles.Add(vehicle);
            vehicle.CarOwner = this;
        }
    }
}

// Placeholder classes for completeness
public class VehicleInspection
{
    public Vehicle Vehicle { get; set; }
}

public class Insurance
{
    public Vehicle Vehicle { get; set; }
}

public class Reservation
{
    public Vehicle Vehicle { get; set; }
}