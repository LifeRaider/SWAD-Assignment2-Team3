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

void ReturnVehicle()
{
    // Initialize some example data for demonstration purposes
    CarRenter renter = new CarRenter("Bob", "hi@hi.com", Convert.ToDateTime("1/1/2000"), "D12345678", "Verified", "U011", "1 HarbourFront Walk, Singapore 098585", "regular", "Credit card", new List<Reservation>());
    Vehicle vehicle = new Vehicle("V001", "Audi", "A5", 2015, 100, new List<string> { "URL1", "URL2" }, "U001", 50, "Weekdays: 9 AM - 6 PM, Weekends: 10 AM - 4 PM", "A", "This is an Audi", "L001");
    Reservation reservation = new Reservation("R001", "U011", Convert.ToDateTime("1/12/2024 13:00"), Convert.ToDateTime("3/12/2024 13:00"), "iCar Station 5, Downtown", "iCar Station 3, Airport", "Pending", 150, "Unpaid", vehicle.ListingID);
    renter.BookingHistory.Add(reservation);

    // Display renter's booking history
    Console.WriteLine("\r\nYour Reservations:");
    for (int i = 0; i < renter.BookingHistory.Count; i++)
    {
        Console.WriteLine($"[{i + 1}] Reservation ID: {renter.BookingHistory[i].ReservationID}, " +
                          $"Vehicle Listing ID: {renter.BookingHistory[i].VehicleListingID}, " +
                          $"Start Date: {renter.BookingHistory[i].StartDate}, " +
                          $"End Date: {renter.BookingHistory[i].EndDate}, " +
                          $"Status: {renter.BookingHistory[i].Status}");
    }

    // Prompt user to select the reservation they want to return
    Console.Write("\r\nEnter the reservation number to return the vehicle or 0 to exit: ");
    int selection = Convert.ToInt16(Console.ReadLine());
    if (selection == 0) return;

    // Check if selection is valid
    if (selection > 0 && selection <= renter.BookingHistory.Count)
    {
        Reservation selectedReservation = renter.BookingHistory[selection - 1];

        // Assume the vehicle is returned successfully
        selectedReservation.Status = "Completed";
        selectedReservation.PaymentStatus = "Paid";  // Assume payment is made

        // Perform any vehicle inspection, update availability, etc.
        VehicleInspection inspection = new VehicleInspection(vehicle.VehicleID, "Inspection001", DateTime.Now, "Passed", "No issues found.");
        Console.WriteLine($"Vehicle Inspection: {inspection.Status} - {inspection.Notes}");

        Console.WriteLine($"\r\nVehicle returned successfully for Reservation ID: {selectedReservation.ReservationID}.");
        Console.WriteLine($"Total cost: ${selectedReservation.TotalCost.ToString("F2")} (Status: {selectedReservation.PaymentStatus})");
    }
    else
    {
        Console.WriteLine("Invalid selection. Please try again.");
    }
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
    else if (option == 3) { }
    else if (option == 4) { ReturnVehicle();}
    else if (option == 5) { }
    else
    {
        Console.WriteLine("Invalid option! Please try again.");
    }
    Console.WriteLine();
}