// LUCAS TOH (S10257164)
public class Insurance {

    private string insuranceID;
    private string providerName;
    private string policyNumber;
    private string coverageDetail;
    private DateTime expiryDate;
    private string vehicleID;

    public string InsuranceID {
        get { return insuranceID; }
        set { insuranceID = value; }
    }

    public string PoviderName {
        get { return providerName; }
        set { providerName = value; }
    }

    public string PolicyNumber {
        get { return policyNumber; }
        set { policyNumber = value; }
    }

    public string CoverageDetail {
        get { return coverageDetail; }
        set { coverageDetail = value; }
    }

    public DateTime ExpiryDate {
        get { return expiryDate; }
        set { expiryDate = value; }
    }

    public string VehicleID {
        get { return vehicleID; }
        set { vehicleID = value; }
    }

    public Insurance() { }
    public Insurance(string insuranceID, string providerName, string policyNumber, string coverageDetail, DateTime expiryDate, string vehicleID) {
        this.insuranceID = insuranceID;
        this.providerName = providerName;
        this.policyNumber = policyNumber;
        this.coverageDetail = coverageDetail;
        this.expiryDate = expiryDate;
        this.vehicleID = vehicleID;
    }

    //VEHICLE MULTIPLICITY (1..*:1)
    private Vehicle vehicle;
    public Vehicle Vehicle {
        set {
            if (vehicle != value) {
                vehicle = value;
                value.addInsurance(this);
            }
        }
    }
}