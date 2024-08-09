using System;

public class Payment
{
    // ATTRIBUTES
    // ====================
    private string paymentID;
    private string reservationID;
    private string paymentMethod;
    private decimal paymentAmount;
    private DateTime paymentDate;
    private string paymentStatus;
    private PrimeDiscount primeDiscount;
    private decimal penaltyAmount;

    public string PaymentID
    {
        get { return paymentID; }
        set { paymentID = value; }
    }
    public string ReservationID
    {
        get { return reservationID; }
        set { reservationID = value; }
    }
    public string PaymentMethod
    {
        get { return paymentMethod; }
        set { paymentMethod = value; }
    }
    public decimal PaymentAmount
    {
        get { return paymentAmount; }
        set { paymentAmount = value; }
    }
    public DateTime PaymentDate
    {
        get { return paymentDate; }
        set { paymentDate = value; }
    }
    public string PaymentStatus
    {
        get { return paymentStatus; }
        set { paymentStatus = value; }
    }
    public PrimeDiscount PrimeDiscount
    {
        get { return primeDiscount; }
        set { primeDiscount = value; }
    }
    public decimal PenaltyAmount
    {
        get { return penaltyAmount; }
        set { penaltyAmount = value; }
    }

    // PAYMENTPROVIDER MULTIPLICITY (0..*:1)
    // ====================
    private PaymentProvider paymentProvider;
    public PaymentProvider PaymentProvider
    {
        get { return paymentProvider; }
        set
        {
            if (paymentProvider != value)
            {
                paymentProvider = value;
                value?.AddPayment(this);
            }
        }
    }

    // RESERVATION MULTIPLICITY (1:1)
    // ====================
    private Reservation reservation;
    public Reservation Reservation
    {
        get { return reservation; }
        set
        {
            if (reservation != value)
            {
                reservation = value;
                value.Payment = this;
            }
        }
    }

    public Payment() { }
    public Payment(string paymentID, string reservationID, string paymentMethod, decimal paymentAmount, DateTime paymentDate, string paymentStatus, PrimeDiscount primeDiscount, decimal penaltyAmount)
    {
        this.paymentID = paymentID;
        this.reservationID = reservationID;
        this.paymentMethod = paymentMethod;
        this.paymentAmount = paymentAmount;
        this.paymentDate = paymentDate;
        this.paymentStatus = paymentStatus;
        this.primeDiscount = primeDiscount;
        this.penaltyAmount = penaltyAmount;
    }

    public void ProcessPayment()
    {
        Console.WriteLine($"Processing payment ID: {PaymentID}");
        // Add logic to process the payment
    }

    public void ApplyPrimeDiscount()
    {
        if (PrimeDiscount != null)
        {
            PaymentAmount -= PaymentAmount * PrimeDiscount.MonthlyRentalDiscount;
            Console.WriteLine($"Prime discount applied. New payment amount: {PaymentAmount}");
        }
    }

  public void DisplayPaymentInfo()
{
    Console.WriteLine($"Payment ID: {PaymentID}");
    Console.WriteLine($"Reservation ID: {ReservationID}");
    Console.WriteLine($"Payment Method: {PaymentMethod}");
    Console.WriteLine($"Payment Amount: {PaymentAmount.ToString("F2")}");
    Console.WriteLine($"Payment Date: {PaymentDate}");
    Console.WriteLine($"Payment Status: {PaymentStatus}");
}

    public void UpdateStatusToPaid()
    {
        PaymentStatus = "Paid";
        Console.WriteLine($"Payment status updated to: {PaymentStatus}");
    }
}

public class PrimeDiscount
{
    public decimal MonthlyRentalDiscount { get; set; }
    public decimal RoadsideAssistanceDiscount { get; set; }
    public decimal MinimumMonthlyRental { get; set; }

    public PrimeDiscount(decimal monthlyRentalDiscount, decimal roadsideAssistanceDiscount, decimal minimumMonthlyRental)
    {
        MonthlyRentalDiscount = monthlyRentalDiscount;
        RoadsideAssistanceDiscount = roadsideAssistanceDiscount;
        MinimumMonthlyRental = minimumMonthlyRental;
    }
}
