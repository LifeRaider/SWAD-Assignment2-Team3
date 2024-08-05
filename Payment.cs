using System;

public class Payment
{
    public string PaymentID { get; set; }
    public string ReservationID { get; set; }
    public string PaymentMethod { get; set; }
    public decimal PaymentAmount { get; set; }
    public DateTime PaymentDate { get; set; }
    public string PaymentStatus { get; set; }
    public PrimeDiscount PrimeDiscount { get; set; }
    public decimal PenaltyAmount { get; set; }
    public string CreditCardNumber { get; set; }

    public Payment(string paymentID, string reservationID, string paymentMethod, decimal paymentAmount, DateTime paymentDate, string paymentStatus, PrimeDiscount primeDiscount, decimal penaltyAmount, string creditCardNumber)
    {
        PaymentID = paymentID;
        ReservationID = reservationID;
        PaymentMethod = paymentMethod;
        PaymentAmount = paymentAmount;
        PaymentDate = paymentDate;
        PaymentStatus = paymentStatus;
        PrimeDiscount = primeDiscount;
        PenaltyAmount = penaltyAmount;
        CreditCardNumber = creditCardNumber;
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
        Console.WriteLine($"Payment Amount: {PaymentAmount}");
        Console.WriteLine($"Payment Date: {PaymentDate}");
        Console.WriteLine($"Payment Status: {PaymentStatus}");
        if (PaymentMethod == "Credit Card")
        {
            Console.WriteLine($"Credit Card Number: {CreditCardNumber}");
        }
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
