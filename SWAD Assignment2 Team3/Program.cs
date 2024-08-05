using System;

public class PaymentProvider
{
    public string CompanyName { get; set; }
    public string CompanyAddress { get; set; }
    public string CompanyUEN { get; set; }
    public string CompanyContact { get; set; }

    public PaymentProvider(string companyName, string companyAddress, string companyUEN, string companyContact)
    {
        CompanyName = companyName;
        CompanyAddress = companyAddress;
        CompanyUEN = companyUEN;
        CompanyContact = companyContact;
    }

    public void DisplayCompanyInfo()
    {
        Console.WriteLine($"Company Name: {CompanyName}");
        Console.WriteLine($"Address: {CompanyAddress}");
        Console.WriteLine($"UEN: {CompanyUEN}");
        Console.WriteLine($"Contact: {CompanyContact}");
    }

    public bool VerifyPaymentDetails()
    {
        // Logic to verify payment details
        return true;
    }

    public bool VerifyPayment()
    {
        // Logic to verify payment
        return true;
    }
}

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

    public Payment(string paymentID, string reservationID, string paymentMethod, decimal paymentAmount, DateTime paymentDate, string paymentStatus, PrimeDiscount primeDiscount, decimal penaltyAmount)
    {
        PaymentID = paymentID;
        ReservationID = reservationID;
        PaymentMethod = paymentMethod;
        PaymentAmount = paymentAmount;
        PaymentDate = paymentDate;
        PaymentStatus = paymentStatus;
        PrimeDiscount = primeDiscount;
        PenaltyAmount = penaltyAmount;
    }

    public void ProcessPayment()
    {
        Console.WriteLine($"Processing payment ID: {PaymentID}");
        // Add logic to process the payment
    }

    public void ApplyPrimeDiscount()
    {
        if (PrimeDiscount != null && PaymentAmount >= PrimeDiscount.MinimumMonthlyRental)
        {
            PaymentAmount -= PaymentAmount * PrimeDiscount.MonthlyRentalDiscount;
            Console.WriteLine($"Prime discount applied. New payment amount: {PaymentAmount}");
        }
        else
        {
            Console.WriteLine("Prime discount not applicable.");
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

public class AccidentReport
{
    public string ReportID { get; set; }
    public string ReservationID { get; set; }
    public DateTime ReportDate { get; set; }
    public string ReportStatus { get; set; }
    public string ReportDescription { get; set; }

    public AccidentReport(string reportID, string reservationID, DateTime reportDate, string reportStatus, string reportDescription)
    {
        ReportID = reportID;
        ReservationID = reservationID;
        ReportDate = reportDate;
        ReportStatus = reportStatus;
        ReportDescription = reportDescription;
    }

    public void DisplayReportInfo()
    {
        Console.WriteLine($"Report ID: {ReportID}");
        Console.WriteLine($"Reservation ID: {ReservationID}");
        Console.WriteLine($"Report Date: {ReportDate}");
        Console.WriteLine($"Report Status: {ReportStatus}");
        Console.WriteLine($"Description: {ReportDescription}");
    }

    public void UpdateReportStatus(string newStatus)
    {
        ReportStatus = newStatus;
        Console.WriteLine($"Report status updated to: {ReportStatus}");
    }
}

public class UIMakePayment
{
    public void DisplayPaymentOptions()
    {
        Console.WriteLine("Displaying payment options...");
    }

    public void UpdateUIWithPaymentSuccess()
    {
        Console.WriteLine("Updating UI with payment success...");
    }

    public void UpdateUIWithPaymentFailed()
    {
        Console.WriteLine("Updating UI with payment failure...");
    }
}

public class CTLMakePayment
{
    public void ProcessPayment(Payment payment)
    {
        Console.WriteLine("Processing payment in controller...");
        // Logic to process payment through PaymentProcessor and PaymentProvider
        PaymentProcessor paymentProcessor = new PaymentProcessor();
        bool isPaymentProcessed = paymentProcessor.ProcessPayment(payment);
        
        if (isPaymentProcessed)
        {
            payment.UpdateStatusToPaid();
            UIMakePayment ui = new UIMakePayment();
            ui.UpdateUIWithPaymentSuccess();
        }
        else
        {
            UIMakePayment ui = new UIMakePayment();
            ui.UpdateUIWithPaymentFailed();
        }
    }

    public void UpdateStatusToPaid(Payment payment)
    {
        payment.UpdateStatusToPaid();
        Console.WriteLine("Updated status to Paid in the system.");
    }
}

public class PaymentProcessor
{
    public bool ProcessPayment(Payment payment)
    {
        Console.WriteLine("Processing payment in PaymentProcessor...");
        PaymentProvider provider = new PaymentProvider("ProviderName", "ProviderAddress", "ProviderUEN", "ProviderContact");
        bool isVerified = provider.VerifyPaymentDetails();
        if (isVerified)
        {
            return provider.VerifyPayment();
        }
        return false;
    }
}
