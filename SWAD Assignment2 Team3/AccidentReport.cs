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
