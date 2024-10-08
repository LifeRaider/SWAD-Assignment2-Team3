using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Codi, S10241842

public class AccidentReport
{
    // Private attributes
    private string location;
    private string time;
    private string description;
    private string renterLicensePlate;
    private string relevantPartyLicensePlate;
    private string relevantPartyPhoneNumber;

    // Public Properties
    public string Location { get; set; }
    public string Time { get; set; }
    public string Description { get; set; }
    public string RenterLicensePlate { get; set; }
    public string RelevantPartyLicensePlate { get; set; }
    public string RelevantPartyPhoneNumber { get; set; }

    // Constructing the Constructor
    public AccidentReport() { }
    public AccidentReport(string l, string t, string d, string rlp, string rplp, string rpph)
    {
        Location = l;
        Time = t;
        Description = d;
        RenterLicensePlate = rlp;
        RelevantPartyLicensePlate = rplp;
        RelevantPartyPhoneNumber = rpph;

    }

    // CARRENTER MULTIPLICITY (1:0..*)
    // ====================
    private CarRenter carRenter;
    public CarRenter CarRenter
    {
        get { return carRenter; }
        set
        {
            if (carRenter != value)
            {
                carRenter = value;
                value?.addAccidentReport(this);
            }
        }
    }

    // Other methods
    private bool isReportSubmitted = false; // Flag to check if the report was submitted
    public bool IsAutoSubmitted { get { return isAutoSubmitted; } }
    private bool isAutoSubmitted = false;

    public bool IsFalseAlarm { get; private set; } = false;

    private void HandleFalseAlarm()
    {
        Console.WriteLine("\nFalse alarm confirmed. No further action is required.");
        IsFalseAlarm = true;
        Console.WriteLine("\nNotifying admin about the false alarm...");
        NotifyAdminFalseAlarm();
    }

    private void NotifyAdminFalseAlarm()
    {
        // Logic to notify admin about the false alarm
        Console.WriteLine("\nAdmin notified about the false alarm.");
    }

    public void ReportAccident()
     {
         Console.WriteLine("Accident detected. Please fill in the accident report form.");
         using (Timer autoDetectTimer = new Timer(AutoSubmitReport, null, TimeSpan.FromMinutes(10), Timeout.InfiniteTimeSpan))
         // Set the TimeSpan.FromMinutes(Put value here) to 0.1 min to test the auto send. Realistically it would be 10min
         {
             while (!isReportSubmitted && !isAutoSubmitted)
             {
                 // Prompt user to confirm if the accident is a false alarm
                 string isFalseAlarm = "";
    
                 while (isFalseAlarm != "yes" && isFalseAlarm != "no")
                 {
                     Console.Write("Is this a false alarm? (yes/no): ");
                     isFalseAlarm = Console.ReadLine().ToLower();
    
                     if (isAutoSubmitted) break;
    
                     if (isFalseAlarm != "yes" && isFalseAlarm != "no")
                     {
                         Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                     }
                 }
    
                 if (isAutoSubmitted) break;
    
                 if (isFalseAlarm == "yes")
                 {
                     HandleFalseAlarm();
                     return; // Exit the method early since it's a false alarm
                 }
    
                 // Basic flow from this point on
                 if (!isAutoSubmitted)
                 {
                     Console.Write("Enter location of the accident: ");
                     string location = Console.ReadLine();
                     if (isAutoSubmitted) break;
    
                     Console.Write("Enter time of the accident (14:30): ");
                     string timeInput = Console.ReadLine();
                     if (isAutoSubmitted) break;
    
                     TimeSpan accidentTime;
                     while (!TimeSpan.TryParseExact(timeInput, @"hh\:mm", null, out accidentTime))
                     {
                         Console.WriteLine("Invalid time format. Please enter time in HH:MM format.");
                         Console.Write("Enter time of the accident (14:30): ");
                         timeInput = Console.ReadLine();
                         time = timeInput.ToString();
                     }
    
                     Console.Write("Enter description of the accident: ");
                     string description = Console.ReadLine();
                     if (isAutoSubmitted) break;
    
                     Console.Write("Enter your license plate (SBA 1234 A): ");
                     string renterLicense = Console.ReadLine();
                     if (isAutoSubmitted) break;
                     while (!ValidateLicense(renterLicense))
                     {
                         Console.WriteLine("Invalid license plate format. Please enter in the format SLL NNNN L.");
                         Console.Write("Enter your license plate (SBA 1234 A): ");
                         renterLicense = Console.ReadLine();
                     }
    
                     Console.Write("Enter the relevant party’s license plate (SBA 1234 A): ");
                     string relevantLicense = Console.ReadLine();
                     if (isAutoSubmitted) break;
                     while (!ValidateLicense(relevantLicense))
                     {
                         Console.WriteLine("Invalid license plate format. Please enter in the format SBA 1234 A.");
                         Console.Write("Enter the relevant party’s license plate (SBA 1234 A): ");
                         relevantLicense = Console.ReadLine();
                     }
    
                     Console.Write("Enter the relevant party’s phone number (9156 4567): ");
                     string relevantPartyNumber = Console.ReadLine();
                     if (isAutoSubmitted) break;
                     while (!ValidatePhoneNumber(relevantPartyNumber))
                     {
                         Console.WriteLine("Invalid phone number format. Please enter in the format 9156 4567.");
                         Console.Write("Enter the relevant party’s phone number (9156 4567): ");
                         relevantPartyNumber = Console.ReadLine();
                     }
    
                     if (!isAutoSubmitted)
                     {
                         // Simulate form submission
                         SubmitAccidentReport(location, time, description, renterLicense, relevantLicense, relevantPartyNumber);
    
                         Console.WriteLine("\nAccident report submitted successfully.");
                         isReportSubmitted = true; // Mark the report as submitted
                         autoDetectTimer.Dispose();// Dispose of the timer since the report has been submitted manually
                     }
                 }
             }
         }
     }

    private void SubmitAccidentReport(string location, string time, string description, string renterLicensePlate, string relevantPartyLicensePlate, string relevantPartyPhoneNumber)
    {
        // Assign the values to the properties
        this.Location = location;
        this.Time = time;
        this.Description = description;
        this.RenterLicensePlate = renterLicensePlate;
        this.RelevantPartyLicensePlate = relevantPartyLicensePlate;
        this.RelevantPartyPhoneNumber = relevantPartyPhoneNumber;

        // Simulating submission with a print statement
        Console.WriteLine("\nSubmitting accident report...");
    }

    private bool ValidateLicense(string license)
    {
        // Basic validation for Singapore license plate format SLLL NNNN L
        return System.Text.RegularExpressions.Regex.IsMatch(license, @"^[A-Z]{1}[A-Z]{2}\s*\d{4}\s*[A-Z]$", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
    }
    
    private bool ValidatePhoneNumber(string number)
    {
        // Basic validation for phone number format XXXX XXXX
        return System.Text.RegularExpressions.Regex.IsMatch(number, @"^\d{4}\s*\d{4}$");
    }

    private void AutoSubmitReport(object state)
{
    if (!isReportSubmitted)
    {
        Console.WriteLine("\nNo report submitted by renter within 10 minutes. Auto-submitting accident report...");

        // Simulate automatic submission of the report
        SubmitAccidentReport("Location: Orchard Road", "Time: 14:30", "No Description",
            "License Plate: SBA 1234 A", 
            "No additional info on additional parties license plate", 
            "No additional info on additional parties phone number");

        Console.WriteLine("\nAccident report auto-submitted.");
        Console.WriteLine("\nPress enter to acknowledge and escape to main menu");
        isAutoSubmitted = true;
        isReportSubmitted = true;
    }
}

    public void DisplayReportInfo()
    {
        Console.WriteLine("\nAccident Report Details:");
        Console.WriteLine($"Location: {Location}");
        Console.WriteLine($"Time: {Time}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Renter License Plate: {RenterLicensePlate}");
        Console.WriteLine($"Relevant Party License Plate: {RelevantPartyLicensePlate}");
        Console.WriteLine($"Relevant Party Phone Number: {RelevantPartyPhoneNumber}");
    }
}
