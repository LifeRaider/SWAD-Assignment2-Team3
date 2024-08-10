// HENG WEI JIAN MARVIN (S10260527)

public class Vehicle {
    // ATTRIBUTES
    // ====================
    private string vehicleID;
    private string vehicleMake;
    private string vehicleModel;
    private int vehicleYear;
    private float vehicleMileage;
    private List<string> vehiclePhotos;
    private string userID;
    private float rentalRate;
    private string availabilitySchedule;
    private string vehicleStatus;
    private string vehicleDescription;
    private string listingID;

    public string VehicleID {
        get { return vehicleID; }
        set { vehicleID = value; }
    }
    public string VehicleMake {
        get { return vehicleMake; }
        set { vehicleMake = value; }
    }
    public string VehicleModel {
        get { return vehicleModel; }
        set { vehicleModel = value; }
    }
    public int VehicleYear {
        get { return vehicleYear; }
        set { vehicleYear = value; }
    }
    public float VehicleMileage {
        get { return vehicleMileage; }
        set { vehicleMileage = value; }
    }
    public List<string> VehiclePhotos {
        get { return vehiclePhotos; }
        set { vehiclePhotos = value; }
    }
    public string UserID {
        get { return userID; }
        set { userID = value; }
    }
    public float RentalRate {
        get { return rentalRate; }
        set { rentalRate = value; }
    }
    public string AvailabilitySchedule {
        get { return availabilitySchedule; }
        set { availabilitySchedule = value; }
    }
    public string VehicleStatus {
        get { return vehicleStatus; }
        set { vehicleStatus = value; }
    }
    public string VehicleDescription {
        get { return vehicleDescription; }
        set { vehicleDescription = value; }
    }
    public string ListingID {
        get { return listingID; }
        set { listingID = value; }
    }

    public Vehicle() {
        insurances = new List<Insurance>();
        reservations = new List<Reservation>();
    }
    public Vehicle(string vehicleID, string vehicleMake, string vehicleModel, int vehicleYear, float vehicleMileage, List<string> vehiclePhotos, string userID, float rentalRate, string availabilitySchedule, string vehicleStatus, string vehicleDescription, string listingID) {
        this.vehicleID = vehicleID;
        this.vehicleMake = vehicleMake;
        this.vehicleModel = vehicleModel;
        this.vehicleYear = vehicleYear;
        this.vehicleMileage = vehicleMileage;
        this.vehiclePhotos = vehiclePhotos;
        this.userID = userID;
        this.rentalRate = rentalRate;
        this.availabilitySchedule = availabilitySchedule;
        this.vehicleStatus = vehicleStatus;
        this.vehicleDescription = vehicleDescription;
        this.listingID = listingID;
    }

    // VEHICLEINSPECTION MULTIPLICITY (1:1)
    // ====================
    private VehicleInspection vehicleInspection;
    public VehicleInspection VehicleInspection {
        set {
            if (vehicleInspection != value) {
                vehicleInspection = value;
                value.Vehicle = this;
            }
        }
    }

    // CAROWNER MULTIPLICITY (1..*:1)
    // ====================
    private CarOwner carOwner;
    public CarOwner CarOwner {
        set {
            if (carOwner != value) {
                carOwner = value;
                value.addVehicle(this);
            }
        }
    }

    // INSURANCE MULTIPLICITY (1:1..*)
    // ====================
    private List<Insurance> insurances;
    public void addInsurance(Insurance i) {
        if (!insurances.Contains(i)) {
            insurances.Add(i);
            i.Vehicle = this;
        }
    }

    // RESERVATION MULTIPLICITY (1:0..*)
    // ====================
    private List<Reservation> reservations;
    public void addReservation(Reservation r) {
        if (!reservations.Contains(r)) {
            reservations.Add(r);
            r.Vehicle = this;
        }
    }

    // ADMIN MULTIPLICITY (0..*:1)
    // ====================
    private Admin admin;
    public Admin Admin {
        set {
            if (admin != value) {
                admin = value;
                value.addVehicle(this);
            }
        }
    }

    // Methods for reporting accident
    public void UpdateStatus(string newStatus)
    {
        // Update the vehicle's status based on the accident
        Console.WriteLine($"Vehicle status updated to: {newStatus}");
    }
}
