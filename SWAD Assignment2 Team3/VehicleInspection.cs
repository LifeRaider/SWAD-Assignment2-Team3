//LUCAS TOH (S10257164)
public class VehicleInspection {

    private string inspectionID;
    private string vehicleID;
    private DateTime inspectionDate;
    private string adminID;
    private bool inspectionStatus;
    private string inspectionComment;

    public string InspectionID{
        get { return inspectionID;}
        set { inspectionID = value; }
    }

    public string VehicleID{
        get { return vehicleID;}
        set { vehicleID = value; }
    }

    public DateTime InspectionDate{
        get { return inspectionDate;}
        set { inspectionDate = value; }
    }

    public string AdminID{
        get { return adminID;}
        set { adminID = value; }
    }

    public bool InspectionStatus{
        get { return inspectionStatus;}
        set { inspectionStatus = value; }
    }

    public string InspectionComment{
        get { return inspectionComment;}
        set { inspectionComment = value; }
    }

    public VehicleInspection() { }
    public VehicleInspection(string inspectionID, string vehicleID, DateTime inspectionDate, string adminID, bool inspectionStatus, string inspectionComment){
        this.inspectionID = inspectionID;
        this.vehicleID = vehicleID;
        this.inspectionDate = inspectionDate;
        this.adminID = adminID;
        this.inspectionStatus = inspectionStatus;
        this.inspectionComment = inspectionComment;
    }
    //VEHICLE MULTIPLICITY (1:1)

    private Vehicle vehicle;
    public Vehicle Vehicle {
        set {
            if (vehicle != value){
                vehicle = value;
                vehicle.VehicleInspection = this;
            }
        }
    }

    //ADMIN MULTIPLICITY (0..*:1)

    private Admin admin;
    public Admin Admin{
        set{
            if (admin != value){
                admin = value;
                admin.addVehicleInspection(this);
            }
        }
    }
}