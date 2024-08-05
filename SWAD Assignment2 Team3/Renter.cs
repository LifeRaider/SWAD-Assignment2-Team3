using System;

namespace CarRental
{
    public class Renter
    {
        public string Name { get; set; }
        public string UserId { get; set; }

        public Renter(string name, string userId)
        {
            Name = name;
            UserId = userId;
        }

        public void SelectReturnVehicle(UI_ReturnVehicle ui)
        {
            Console.WriteLine($"Renter {Name} selects return vehicle");
            ui.DisplayReturnForm("Reservation123");
        }

        public void EnterReturnDetails(UI_ReturnVehicle ui, string location, DateTime time)
        {
            Console.WriteLine("Renter enters return details");
            ui.SubmitReturnDetails(location, time);
        }

        public void ConfirmArrival(UI_ReturnVehicle ui)
        {
            Console.WriteLine("Renter confirms arrival");
            ui.PromptForVehicleInspection();
        }

        public void ConfirmPayment(UI_ReturnVehicle ui)
        {
            Console.WriteLine("Renter confirms payment");
            ui.DisplayReturnConfirmation();
        }
    }
}
