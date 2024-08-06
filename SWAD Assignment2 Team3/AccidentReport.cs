using System;

namespace AccidentReportSystem
{
    public class AccidentReport
    {
        public string Location { get; set; }
        public string TimeOfAccident { get; set; }
        public string Description { get; set; }
        public string LicensePlate { get; set; }
        public string InsuranceIds { get; set; }
        public string Identities { get; set; }
        public string Photos { get; set; }

        public AccidentReport() { }

        public AccidentReport(string location, string timeOfAccident, string description, string licensePlate, string insuranceIds, string identities, string photos)
        {
            Location = location;
            TimeOfAccident = timeOfAccident;
            Description = description;
            LicensePlate = licensePlate;
            InsuranceIds = insuranceIds;
            Identities = identities;
            Photos = photos;
        }

        public override string ToString()
        {
            return $"Location: {Location}\n" +
                   $"Time of Accident: {TimeOfAccident}\n" +
                   $"Description: {Description}\n" +
                   $"License Plate: {LicensePlate}\n" +
                   $"Insurance IDs: {InsuranceIds}\n" +
                   $"Identities: {Identities}\n" +
                   $"Photos: {Photos}";
        }
    }
}
