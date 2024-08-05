using System;

public class Program
{
    public static void Main(string[] args)
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

        PrimeDiscount primeDiscount = null;

        // Check for prime discount eligibility
        if (true) // Simulate always true for eligibility
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

        // Create PaymentProvider object
        PaymentProvider paymentProvider = new PaymentProvider("ProviderName", "ProviderAddress", "ProviderUEN", "ProviderContact");

        // Create Payment object
        Payment payment = new Payment(paymentID, reservationID, paymentMethod, paymentAmount, DateTime.Now, "Pending", primeDiscount, 0.00m);
        payment.PaymentProvider = paymentProvider;

        // Process the payment
        if (paymentProvider.VerifyPaymentDetails() && paymentProvider.VerifyPayment())
        {
            payment.UpdateStatusToPaid();
            Console.WriteLine("Payment processed successfully.");
        }
        else
        {
            Console.WriteLine("Payment failed.");
        }

        // Display payment info
        payment.DisplayPaymentInfo();
    }
}
