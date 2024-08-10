//LUCAS TOH (S10257164)

public class CarRenter:User {

    private string renterTier;
    private string paymentMethod;
    private List<Reservation> bookingHistory;

    public string RenterTier {
        get { return renterTier; }
        set { renterTier = value; }
    }

    public string PaymentMethod {
        get { return paymentMethod; }
        set { paymentMethod = value; }
    }

    public List<Reservation> BookingHistory {
        get { return bookingHistory; }
        set { bookingHistory = value; }
    }

    public CarRenter() { }
    public CarRenter(string userName, string userContact, DateTime userDOB, string userDriversLicense, string userStatus, string userID, string userAddress, string renterTier, string paymentMethod, List<Reservation> bookingHistory) : base(userName, userContact, userDOB, userDriversLicense, userStatus, userID, userAddress)
    {
        this.renterTier = renterTier;
        this.paymentMethod = paymentMethod;
        this.bookingHistory = bookingHistory;
    }

    //ACCIDENTREPORT MULTIPLICITY (1:0..*)
    private List<AccidentReport> accidentReport;
    public void addAccidentReport(AccidentReport a) {
        if (!accidentReport.Contains(a)) {
            accidentReport.Add(a);
            a.CarRenter = this;
        }
    }

    //RESERVATION MULTIPLICITY (1:0..*)
    private List<Reservation> reservations;
    public void addReservation(Reservation r) {
        if (!reservations.Contains(r)) {
            reservations.Add(r);
            r.CarRenter = this;
        }
    }

    // Method for reporting accident
    public void FileAccidentReport()
    {
        AccidentReport report = new AccidentReport();
        report.ReportAccident();
        // Interaction with Admin or Vehicle class to proceed with the report
        Admin admin = new Admin();
        admin.ReviewAccidentReport(report);
    
        Vehicle vehicle = new Vehicle(); // Assuming this is the relevant vehicle
        vehicle.UpdateStatus("Involved in Accident");
    }
}
