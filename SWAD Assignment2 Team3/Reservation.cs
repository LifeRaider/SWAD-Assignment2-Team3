// HENG WEI JIAN MARVIN (S10260527)

using System;

public class Reservation
{
    // Attributes
    private string reservationID;
    private string userID;
    private DateTime startDate;
    private DateTime endDate;
    private string pickUpLocation;
    private string returnLocation;
    private string reservationStatus;
    private double totalCost;
    private string paidStatus;
    private string listingID;

    // Relationships
    private Vehicle reservedVehicle;
    private CarRenter renter;
    private Payment payment;

    // Constructor
    public Reservation(string reservationID, string userID, string listingID, DateTime startDate, DateTime endDate)
    {
        this.reservationID = reservationID;
        this.userID = userID;
        this.listingID = listingID;
        this.startDate = startDate;
        this.endDate = endDate;
        this.reservationStatus = "Pending"; // Initial status
        this.paidStatus = "Unpaid"; // Initial paid status
    }

    // Properties
    public string ReservationID
    {
        get { return reservationID; }
        private set { reservationID = value; }
    }

    public string UserID
    {
        get { return userID; }
        set { userID = value; }
    }

    public DateTime StartDate
    {
        get { return startDate; }
        set { startDate = value; }
    }

    public DateTime EndDate
    {
        get { return endDate; }
        set { endDate = value; }
    }

    public string PickUpLocation
    {
        get { return pickUpLocation; }
        set { pickUpLocation = value; }
    }

    public string ReturnLocation
    {
        get { return returnLocation; }
        set { returnLocation = value; }
    }

    public string ReservationStatus
    {
        get { return reservationStatus; }
        set { reservationStatus = value; }
    }

    public double TotalCost
    {
        get { return totalCost; }
        set { totalCost = value; }
    }

    public string PaidStatus
    {
        get { return paidStatus; }
        set { paidStatus = value; }
    }

    public string ListingID
    {
        get { return listingID; }
        set { listingID = value; }
    }

    // Methods
    public void SetReservedVehicle(Vehicle vehicle)
    {
        this.reservedVehicle = vehicle;
        vehicle.AddReservation(this);
    }

    public void SetRenter(CarRenter renter)
    {
        this.renter = renter;
    }

    public void SetPayment(Payment payment)
    {
        this.payment = payment;
    }

    public void CalculateTotalCost()
    {
        // Implement logic to calculate total cost based on rental duration and vehicle rate
        TimeSpan duration = endDate - startDate;
        int days = (int)duration.TotalDays;
        totalCost = days * reservedVehicle.RentalRate;
        // You might want to add additional fees or apply discounts here
    }

    public void UpdateReservationStatus(string newStatus)
    {
        reservationStatus = newStatus;
    }

    public void UpdatePaidStatus(string newStatus)
    {
        paidStatus = newStatus;
    }

    // Other methods as needed...
}