using System;

namespace CarRental
{
    public class ICarSystem
    {
        public string UpdateReturnDetails(string reservationDetails, string location, DateTime time)
        {
            // Simulate updating return details
            Console.WriteLine($"Updating return details in system: Reservation={reservationDetails}, Location={location}, Time={time}");
            return "Confirmed";
        }

        public double CalculateAdditionalCharges(string inspectionResults)
        {
            // Simulate calculating additional charges
            Console.WriteLine($"Calculating additional charges based on inspection results: {inspectionResults}");
            return 50.0; // Assume there are some charges
        }

        public void ProcessPayment(double amount)
        {
            // Simulate payment processing
            Console.WriteLine($"Processing payment of amount: {amount}");
        }
    }
}
