using System;

namespace CarRental
{
    public class ReturnVehicle
    {
        private readonly Reservation reservation;
        private readonly Vehicle vehicle;
        private readonly CarRenter carRenter;

        public ReturnVehicle(int reservationId)
        {
            this.reservation = new Reservation
            {
                ReservationId = reservationId,
                VehicleId = 101,
                RenterId = 1001,
                ReservationDate = DateTime.Now.AddDays(-7),
                ReturnDate = DateTime.Now,
                Status = "Pending"
            };

            this.vehicle = new Vehicle
            {
                VehicleId = reservation.VehicleId,
                Make = "Audi",
                Model = "A5",
                Year = 2015,
                Status = "Rented"
            };

            this.carRenter = new CarRenter
            {
                RenterId = reservation.RenterId,
                Name = "John Doe",
                LicenseNumber = "D12345678"
            };
        }

        public void SubmitReturnDetails(string location, DateTime time)
        {
            UpdateReturnDetails(location, time);
            reservation.Status = "Confirmed";

            if (reservation.Status == "Confirmed")
            {
                ConfirmArrival();
            }
        }

        private void UpdateReturnDetails(string location, DateTime time)
        {
            reservation.ReturnDate = time;
            Console.WriteLine($"Return details updated: Location={location}, Time={time}");
        }

        private void ConfirmArrival()
        {
            bool verified = carRenter.VerifyRenterIdentity();
            if (verified)
            {
                PromptForVehicleInspection();
            }
        }

        private void PromptForVehicleInspection()
        {
            Console.WriteLine("Prompting for vehicle inspection...");
            NotifyForInspection();
        }

        private void NotifyForInspection()
        {
            Console.WriteLine("Notifying for inspection...");
            ProcessInspection(new InspectionResults { VehicleId = vehicle.VehicleId, Condition = "Good", Notes = "No issues" });
        }

        private void ProcessInspection(InspectionResults results)
        {
            UpdateVehicleCondition(results);

            double additionalCharges = CalculateAdditionalCharges();
            if (additionalCharges > 0)
            {
                PromptForPayment(additionalCharges);
            }
            else
            {
                CompleteReservation();
            }
        }

        private void UpdateVehicleCondition(InspectionResults results)
        {
            Console.WriteLine($"Vehicle condition updated: {results.Condition}");
        }

        private double CalculateAdditionalCharges()
        {
            // Simulate calculating additional charges
            return 0;
        }

        private void PromptForPayment(double charges)
        {
            ProcessPayment(charges);
            CompleteReservation();
        }

        private void ProcessPayment(double charges)
        {
            Console.WriteLine($"Payment processed: Amount={charges}");
        }

        private void CompleteReservation()
        {
            reservation.Status = "Completed";
            Console.WriteLine("Reservation completed.");
            vehicle.Status = "Available";
            Console.WriteLine($"Vehicle status updated to: {vehicle.Status}");
        }
    }
}
