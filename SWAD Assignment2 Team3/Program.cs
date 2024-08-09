/* Display Menu */
void DisplayMenu()
{
    Console.Write("---------------- M E N U -----------------\r\n" +
    "[1] Register Vehicle (Marvin)\r\n" +
    "[2] Make Reservation (Jovan)\r\n" +
    "[3] Make Payment (Ryan)\r\n" +
    "[4] Return Vehicle (Lucas)\r\n" +
    "[5]  (Codi)\r\n" +
    "[0] Exit\r\n------------------------------------------\r\nEnter your option : ");
}

/* functions/methods here */
void MakeReservation()
{
    /* initialise */
    CarRenter renter = new CarRenter("Bob", "hi@hi.com", Convert.ToDateTime("1/1/2000"), "D12345678", "Verified", "U011", "1 HarbourFront Walk, Singapore 098585", "regular", "Credit card", new List<Reservation>());
    List<string> pictures = new List<string>()
    {
        "URL1", "URL2", "URL3", "URL4", "URL5", "URL6","URL7", "URL8", "URL9", "URL10"
    };
        List<Vehicle> vehicles = new List<Vehicle>()
    {
        new Vehicle("V001", "Audi", "A5", 2015, 100, pictures, "U001", 50, "Weekdays: 9 AM - 6 PM, Weekends: 10 AM - 4 PM", "A", "This is an Audi", "L001"),
        new Vehicle("V002", "Mercedes", "Benz", 2013, 120, pictures, "U002", 60, "Weekdays: 9 AM - 6 PM, Weekends: 10 AM - 4 PM", "A", "This is an Mercedes", "L002"),
        new Vehicle("V003", "BMW", "M3", 2017, 150, pictures, "U003", 55, "Weekdays: 9 AM - 6 PM, Weekends: 10 AM - 4 PM", "A", "This is an BMW", "L003")
    };


    Vehicle vehicle;
    while (true)
    {
        Console.Write("\r\n---------------- Vehicles -----------------\r\n" +
        "[1] Audi\r\n" +
        "[2] Mercedes\r\n" +
        "[3] BMW\r\n" +
        "[0] Exit\r\n------------------------------------------\r\nEnter your option : ");

        int option = Convert.ToInt16(Console.ReadLine());
        if (option == 0) { return; }
        else if (option >= 1 && option <= 3) { vehicle = vehicles[option - 1]; break; }
        else
        {
            Console.WriteLine("Invalid option! Please try again.");
        }
        Console.WriteLine();
    }

    Console.WriteLine(vehicle.AvailabilitySchedule);
    DateTime startDate;
    DateTime endDate;
    while (true)
    {
        try
        {
            Console.Write("Enter start date and time (e.g. 1/12/2024 13:00):");
            startDate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Enter end date and time (e.g. 3/12/2024 13:00):");
            endDate = Convert.ToDateTime(Console.ReadLine());
            break;
        }
        catch (FormatException)
        {
            Console.WriteLine("Incorrect Date and Time format! Please try again :)");
        }
    }
 
    Console.Write("Enter pickup location (iCar Station 5, Downtown):");
    string pickupLocation = Console.ReadLine();
    Console.Write("Enter return location (iCar Station 3, Airport):");
    string returnLocation = Console.ReadLine();

    Reservation reservation = new Reservation("R001", "U011", startDate, endDate, pickupLocation, returnLocation, "Pending", 150, "Unpaid", vehicle.ListingID);
    renter.BookingHistory.Add(reservation);

    Console.WriteLine("\r\nReservation ID: " + reservation.ReservationID +
                      "\r\nReservation StartDate: " + reservation.StartDate +
                      "\r\nReservation EndDate: " + reservation.EndDate +
                      "\r\nReservation Pick Up Location: " + reservation.PickUpLocation +
                      "\r\nReservation Return Location: " + reservation.ReturnLocation +
                      "\r\nReservation Total Cost: $" + reservation.TotalCost.ToString("F2"));
}

void MakePayment()
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

    // Example Payment Amount
    decimal paymentAmount = 200.00m; // Example static amount, modify this to reflect actual logic if needed

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
            Console.WriteLine($"Prime discount applied. New payment amount: {paymentAmount.ToString("F2")}");
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


while (true)
{
    DisplayMenu();
    int option = Convert.ToInt16(Console.ReadLine());

    if (option == 0) { break; }
    else if (option == 1) { 
        RegisterVehicle registrationProcess = new RegisterVehicle();
        registrationProcess.Start();
    }
    else if (option == 2) { MakeReservation(); }
    else if (option == 3) { MakePayment(); }
    else if (option == 4) {}
    else if (option == 5) { }
    else
    {
        Console.WriteLine("Invalid option! Please try again.");
    }
    Console.WriteLine();
}
