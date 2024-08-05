// HENG WEI JIAN MARVIN (S10260527)

public class Reservation {
    // ATTRIBUTES
    // ====================
    private string reservationID;
    private string userID;
    private DateTime startDate;
    private DateTime endDate;
    private string pickUpLocation;
    private string returnLocation;
    private string reservationStatus;
    private float totalCost;
    private string paidStatus;
    private string listingID;

    public string ReservationID {
        get { return reservationID; }
        set { reservationID = value; }
    }
    public string UserID {
        get { return userID; }
        set { userID = value; }
    }
    public DateTime StartDate {
        get { return startDate; }
        set { startDate = value; }
    }
    public DateTime EndDate {
        get { return endDate; }
        set { endDate = value; }
    }
    public string PickUpLocation {
        get { return pickUpLocation; }
        set { pickUpLocation = value; }
    }
    public string ReturnLocation {
        get { return returnLocation; }
        set { returnLocation = value; }
    }
    public string ReservationStatus {
        get { return reservationStatus; }
        set { reservationStatus = value; }
    }
    public float TotalCost {
        get { return totalCost; }
        set { totalCost = value; }
    }
    public string PaidStatus {
        get { return paidStatus; }
        set { paidStatus = value; }
    }
    public string ListingID {
        get { return listingID; }
        set { listingID = value; }
    }

    public Reservation(string reservationID, string userID, DateTime startDate, DateTime endDate, string pickUpLocation, string returnLocation, string reservationStatus, float totalCost, string paidStatus, string listingID) {
        this.reservationID = reservationID;
        this.userID = userID;
        this.startDate = startDate;
        this.endDate = endDate;
        this.pickUpLocation = pickUpLocation;
        this.returnLocation = returnLocation;
        this.reservationStatus = reservationStatus;
        this.totalCost = totalCost;
        this.paidStatus = paidStatus;
        this.listingID = listingID;
    }

    // VEHICLE MULTIPLICITY (0..*:1)
    // ====================
    private Vehicle vehicle;
    public Vehicle Vehicle {
        set {
            if (vehicle != value) {
                vehicle = value;
                value.addReservation(this);
            }
        }
    }

    // CARRENTER MULTIPLICITY (0..*:1)
    // ====================
    private CarRenter carRenter;
    public CarRenter CarRenter {
        set {
            if (carRenter != value) {
                carRenter = value;
                value.addReservation(this);
            }
        }
    }

    // PAYMENT MULTIPLICITY (1:1)
    // ====================
    private Payment payment;
    public Payment Payment {
        set {
            if (payment != value) {
                payment = value;
                value.Reservation = this;
            }
        }
    }
}