//LUCAS TOH (S10257164)

public class CarRenter {

    private string renterTier;
    private string paymentMethod;
    private string bookingHistory;

    public string RenterTier {
        get { return renterTier; }
        set { renterTier = value; }
    }

    public string PaymentMethod {
        get { return paymentMethod; }
        set { paymentMethod = value; }
    }

    public string BookingHistory {
        get { return bookingHistory; }
        set { bookingHistory = value; }
    }

    public CarRenter() { }
    public CarRenter(string renterTier, string paymentMethod, string bookingHistory){
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
}