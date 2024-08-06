using System;
using System.Collections.Generic;

void DisplayMenu()
{
    Console.Write("---------------- M E N U -----------------\r\n" +
    "[1] Register Vehicle (Marvin)\r\n" +
    "[2] Make Reservation (Jovan)\r\n" +
    "[3] Make Payment (Ryan)\r\n" +
    "[4] Return Vehicle (Lucas)\r\n" +
    "[5] Report Accident (Codi)\r\n" +
    "[0] Exit\r\n------------------------------------------\r\nEnter your option : ");
}

/* functions/methods here */
void MakeReservation()
{
    /* initialise */
    /*CarRenter renter = new CarRenter(, "regular", "Credit card", new List<Reservation>()); */
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
        Console.Write("---------------- Vehicles -----------------\r\n" +
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
    Console.WriteLine("Enter start date and time (e.g. 1/12/2024 13:00):");
    DateTime startDate = Convert.ToDateTime(Console.ReadLine());
    Console.WriteLine("Enter end date and time (e.g. 3/12/2024 13:00):");
    DateTime endDate = Convert.ToDateTime(Console.ReadLine());
    Console.WriteLine("Enter pickup location (iCar Station 5, Downtown):");
    string pickupLocation = Console.ReadLine();
    Console.WriteLine("Enter return location (iCar Station 3, Airport):");
    string returnLocation = Console.ReadLine();

    Reservation reservation = new Reservation("R001", "U011", startDate, endDate, pickupLocation, returnLocation, "Pending", 150, "Unpaid", vehicle.ListingID);
    Console.WriteLine(reservation.ToString());
}

static void ReportAccident()
        {
            Console.WriteLine("Accident Detection System Triggered");

            // Simulating impact detection
            Console.WriteLine("System detected an impact. Waiting for renter report...");

            // Timer simulation (for demonstration purposes only)
            System.Threading.Thread.Sleep(600000); // Wait for 10 minutes (600,000 milliseconds)

            Console.WriteLine("No report submitted by user within 10 minutes. Triggering automatic report...");

            // Collecting accident report details from the user
            var report = CollectAccidentReport();

            if (report != null)
            {
                Console.WriteLine("Accident report submitted successfully.");
                // Simulating sending notification to admin
                SendNotification(report);
                Console.WriteLine("Notification sent to admin.");
            }
            else
            {
                Console.WriteLine("No report was submitted by the user. Auto-report will be generated.");
                // Simulating auto-report generation
                AutoReport();
                Console.WriteLine("Auto-report sent to admin.");
            }

            Console.WriteLine("Accident report process completed.");
        }

        static AccidentReport CollectAccidentReport()
        {
            try
            {
                Console.WriteLine("Please fill out the accident report form:");

                Console.Write("Location of the accident: ");
                string location = Console.ReadLine();

                Console.Write("Time of the accident: ");
                string timeOfAccident = Console.ReadLine();

                Console.Write("Description of the accident: ");
                string description = Console.ReadLine();

                Console.Write("License plate numbers of the parties involved: ");
                string licensePlate = Console.ReadLine();

                Console.Write("Insurance IDs of the parties involved: ");
                string insuranceIds = Console.ReadLine();

                Console.Write("Identities of the parties involved (e.g., user ID or ID number): ");
                string identities = Console.ReadLine();

                Console.Write("Photographs of the accident scene and vehicle damage (if possible): ");
                string photos = Console.ReadLine();

                // Confirm submission
                Console.Write("Submit this accident report? (yes/no): ");
                string confirmation = Console.ReadLine().ToLower();
                if (confirmation == "yes")
                {
                    return new AccidentReport(location, timeOfAccident, description, licensePlate, insuranceIds, identities, photos);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        static void SendNotification(AccidentReport report)
        {
            // Simulate sending notification via SMS and email
            Console.WriteLine("\nSending notification to iCar admin...");
            Console.WriteLine("Notification sent to iCar admin with the following details:");
            Console.WriteLine(report);
        }

        static void AutoReport()
        {
            // Simulate auto-report generation
            Console.WriteLine("\nGenerating automatic report...");
            var autoReport = new AccidentReport("Auto-detected location", "Auto-detected time", "Auto-generated description", "Auto-detected license plate", "Auto-detected insurance IDs", "Auto-detected identities", "Auto-detected photos");
            SendNotification(autoReport);
        }

while (true)
{
    DisplayMenu();
    int option = Convert.ToInt16(Console.ReadLine());

    if (option == 0) { break; }
    else if (option == 1) { /* Register Vehicle (Marvin) */ }
    else if (option == 2) { MakeReservation(); }
    else if (option == 3) { /* Make Payment (Ryan) */ }
    else if (option == 4) { /* Return Vehicle (Lucas) */ }
    else if (option == 5) { ReportAccident(); }
    else
    {
        Console.WriteLine("Invalid option! Please try again.");
    }
    Console.WriteLine();
}
