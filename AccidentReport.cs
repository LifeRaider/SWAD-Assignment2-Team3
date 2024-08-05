using System;

public class AccidentReport
{
    public string ReportID { get; set; }
    public string ReservationID { get; set; }
    public DateTime ReportDate { get; set; }
    public string ReportStatus { get; set; }
    public string ReportDescription { get; set; }

    public AccidentReport(string reportID, string reservationID, DateTime reportDate, string reportStatus, string reportDescription)
    {
        ReportID = reportID;
        ReservationID = reservationID;
        ReportDate = reportDate;
        ReportStatus = reportStatus;
        ReportDescription = reportDescription;
    }

    public void DisplayReportInfo()
    {
        Console.WriteLine($"Report ID: {ReportID}");
        Console.WriteLine($"Reservation ID: {ReservationID}");
        Console.WriteLine($"Report Date: {ReportDate}");
        Console.WriteLine($"Report Status: {ReportStatus}");
        Console.WriteLine($"Description: {ReportDescription}");
    }

    public void UpdateReportStatus(string newStatus)
    {
        ReportStatus = newStatus;
        Console.WriteLine($"Report status updated to: {ReportStatus}");
    }
}
