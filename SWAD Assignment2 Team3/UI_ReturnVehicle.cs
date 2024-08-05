using System;

namespace CarRental
{
    public class UI_ReturnVehicle
    {
        private CTL_ReturnVehicle controller;

        public UI_ReturnVehicle(CTL_ReturnVehicle controller)
        {
            this.controller = controller;
        }

        public void DisplayReturnForm(string reservationDetails)
        {
            Console.WriteLine($"UI displays return form with details: {reservationDetails}");
            controller.InitializeReturn(reservationDetails);
        }

        public void SubmitReturnDetails(string location, DateTime time)
        {
            Console.WriteLine($"UI submits return details: Location={location}, Time={time}");
            controller.UpdateReturnDetails(location, time);
        }

        public void DisplayConfirmation(string status)
        {
            Console.WriteLine("UI displays confirmation: " + status);
        }

        public void PromptForVehicleInspection()
        {
            Console.WriteLine("UI prompts for vehicle inspection");
            controller.ProcessInspection("InspectionResults");
        }

        public void DisplayReturnConfirmation()
        {
            Console.WriteLine("UI displays return confirmation");
        }
    }
}
