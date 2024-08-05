using System;

public class AccidentReport
{
    // ATTRIBUTES
    // ====================
    private string reportID;
    private string reservationID;
    private DateTime reportDate;
    private string reportStatus;
    private string reportDescription;

    public string ReportID
    {
        get { return reportID; }
        set { reportID = value; }
    }
    public string ReservationID
    {
        get { return reservationID; }
        set { reservationID = value; }
    }
    public DateTime ReportDate
    {
        get { return reportDate; }
        set { reportDate = value; }
    }
    public string ReportStatus
    {
        get { return reportStatus; }
        set { reportStatus = value; }
    }
    public string ReportDescription
    {
        get { return reportDescription; }
        set { reportDescription = value; }
    }

    public AccidentReport() { }
    public AccidentReport(string reportID, string reservationID, DateTime reportDate, string reportStatus, string reportDescription)
    {
        this.reportID = reportID;
        this.reservationID = reservationID;
        this.reportDate = reportDate;
        this.reportStatus = reportStatus;
        this.reportDescription = reportDescription;
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
