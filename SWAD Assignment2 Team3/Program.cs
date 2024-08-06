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

        static void ReturnVehicle()
        {
            Console.Write("Enter Reservation ID: ");
            int reservationId = Convert.ToInt32(Console.ReadLine());

            Reservation reservation = GetReservationById(reservationId);

            if (reservation != null)
            {
                Console.WriteLine("Enter return location:");
                string location = Console.ReadLine();
                Console.WriteLine("Enter return time (e.g., 1/12/2024 13:00):");
                DateTime time = Convert.ToDateTime(Console.ReadLine());

                reservation.ReturnLocation = location;
                reservation.ReturnDate = time;

                Console.WriteLine("Verifying renter identity...");
                if (true)
                {
                    Console.WriteLine("Identity verified.");
                    Console.WriteLine("Prompting for vehicle inspection...");

                    InspectionResults inspectionResults = new InspectionResults
                    {
                        VehicleId = reservation.VehicleId,
                        Condition = "Good",
                        Notes = "No issues"
                    };

                    ProcessInspection(inspectionResults, reservation);

                    double additionalCharges = CalculateAdditionalCharges(inspectionResults);
                    if (additionalCharges > 0)
                    {
                        Console.WriteLine($"Additional charges: ${additionalCharges}");
                        Console.WriteLine("Processing payment...");
                        ProcessPayment(reservation, additionalCharges);
                    }

                    Console.WriteLine("Completing reservation...");
                    CompleteReservation(reservation);

                    Console.WriteLine("Return process completed successfully.");
                }
                else
                {
                    Console.WriteLine("Identity verification failed!");
                }
            }
            else
            {
                Console.WriteLine("Reservation not found!");
            }
        }
while (true)
{
    DisplayMenu();
    int option = Convert.ToInt16(Console.ReadLine());

    if (option == 0) { break; }
    else if (option == 1) { }
    else if (option == 2) { }
    else if (option == 3) { }
    else if (option == 4) { ReturnVehicle();}
    else if (option == 5) { }
    else
    {
        Console.WriteLine("Invalid option! Please try again.");
    }
    Console.WriteLine();
}