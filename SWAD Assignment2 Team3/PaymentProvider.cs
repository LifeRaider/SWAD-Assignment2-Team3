using System;
using System.Collections.Generic;

public class PaymentProvider
{
    // ATTRIBUTES
    // ====================
    public string CompanyName { get; set; }
    public string CompanyAddress { get; set; }
    public string CompanyUEN { get; set; }
    public string CompanyContact { get; set; }

    // PAYMENTS MULTIPLICITY (1:0..*)
    // ====================
    private List<Payment> payments;
    public List<Payment> Payments
    {
        get { return payments; }
    }

    public PaymentProvider(string companyName, string companyAddress, string companyUEN, string companyContact)
    {
        CompanyName = companyName;
        CompanyAddress = companyAddress;
        CompanyUEN = companyUEN;
        CompanyContact = companyContact;
        payments = new List<Payment>();
    }

    public void AddPayment(Payment payment)
    {
        if (!payments.Contains(payment))
        {
            payments.Add(payment);
            payment.PaymentProvider = this;
        }
    }

    public void DisplayCompanyInfo()
    {
        Console.WriteLine($"Company Name: {CompanyName}");
        Console.WriteLine($"Address: {CompanyAddress}");
        Console.WriteLine($"UEN: {CompanyUEN}");
        Console.WriteLine($"Contact: {CompanyContact}");
    }

    public bool VerifyPaymentDetails()
    {
        // Simulate payment detail verification
        Console.WriteLine("Verifying payment details...");
        return true;
    }

    public bool VerifyPayment()
    {
        // Simulate payment verification
        Console.WriteLine("Verifying payment...");
        return true;
    }
}
