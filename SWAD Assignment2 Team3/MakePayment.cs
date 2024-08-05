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
        // Simulate payment detail verification
        Console.WriteLine("Verifying payment details...");
        return true;
    }

    public bool VerifyPayment()
    {
        // Simulate payment verification
        Console.WriteLine("Verifying payment...");
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

    public bool CheckPrimeDiscountEligibility()
    {
        // Simulate checking for prime discount eligibility (always true for this simulation)
        Console.WriteLine("Checking prime discount eligibility...");
        return true;
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

class Program
{
    static void Main(string[] args)
    {
        // Prompt user for input
        Console.WriteLine("Enter Payment ID:");
        string paymentID = Console.ReadLine();

        Console.WriteLine("Enter Reservation ID:");
        string reservationID = Console.ReadLine();

        string paymentMethod = "";
        while (true)
        {
            Console.WriteLine("Enter Payment Method (Credit Card / Digital Wallet):");
            paymentMethod = Console.ReadLine();
            if (paymentMethod == "Credit Card" || paymentMethod == "Digital Wallet")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid payment method. Please enter 'Credit Card' or 'Digital Wallet'.");
            }
        }

        string creditCardNumber = null;
        if (paymentMethod == "Credit Card")
        {
            while (true)
            {
                Console.WriteLine("Enter 16-digit Credit Card Number:");
                creditCardNumber = Console.ReadLine();
                if (creditCardNumber.Length == 16 && long.TryParse(creditCardNumber, out _))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid credit card number. Please enter a 16-digit number.");
                }
            }
        }

        Console.WriteLine("Enter Payment Amount:");
        decimal paymentAmount = decimal.Parse(Console.ReadLine());

        CTLMakePayment ctlMakePayment = new CTLMakePayment();
        PrimeDiscount primeDiscount = null;

        // Check for prime discount eligibility
        if (ctlMakePayment.CheckPrimeDiscountEligibility())
        {
            Console.WriteLine("You are eligible for a prime discount.");
            Console.WriteLine("Apply Prime Discount (Y/N):");
            string primeDiscountInput = Console.ReadLine();
            if (primeDiscountInput.ToUpper() == "Y")
            {
                primeDiscount = new PrimeDiscount(0.10m, 0.50m, 300.00m);
                paymentAmount -= paymentAmount * primeDiscount.MonthlyRentalDiscount;
                Console.WriteLine($"Prime discount applied. New payment amount: {paymentAmount}");
            }
        }

        // Create Payment object
        Payment payment = new Payment(paymentID, reservationID, paymentMethod, paymentAmount, DateTime.Now, "Pending", primeDiscount, 0.00m, creditCardNumber);
        
        UIMakePayment uiMakePayment = new UIMakePayment();

        // Display payment options
        uiMakePayment.DisplayPaymentOptions();

        // Process the payment
        ctlMakePayment.ProcessPayment(payment);

        // Display payment info
        payment.DisplayPaymentInfo();
    }
}
