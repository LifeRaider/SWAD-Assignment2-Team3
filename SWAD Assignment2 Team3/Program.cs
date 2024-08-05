using System;

namespace CarRental
{
    class Program
    {
        static void Main(string[] args)
        {
            var iCarSystem = new iCarSystem();
            var controller = new CTL_ReturnVehicle(iCarSystem);
            var ui = new UI_ReturnVehicle(controller);
            var renter = new Renter("Alice", "R123456");

            renter.SelectReturnVehicle(ui);
        }
    }
}
