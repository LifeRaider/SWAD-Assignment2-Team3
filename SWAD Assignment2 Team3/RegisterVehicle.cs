using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class RegisterVehicle
{
    private Vehicle newVehicle;
    private const int REQUIRED_PHOTOS = 10;
    private const int MAX_VEHICLE_AGE = 10;
    private const float MAX_MILEAGE = 150000;

    // Additional attributes not in Vehicle class
    private string licensePlateNumber;
    private string registrationDocument;
    private string insurancePolicyNumber;
    private string insuranceProvider;
    private bool needsAdditionalReview;

    // Test data for duplicate vehicle checks
    private readonly List<(string VIN, string LicensePlate)> existingVehicles = new List<(string, string)>
    {
        ("1HABH41JXMN109186", "SBA4321A"),
        ("5XYKT3A17CG191863", "SGX9876B"),
        ("WBAJB0C51BC532388", "SJH5678C")
    };

    public void Start()
    {
        Console.WriteLine("Welcome to the Vehicle Registration Process");
        
        newVehicle = new Vehicle();
        
        if (GetVehicleDetails() && UploadPhotos() && GetOwnershipProof() && GetInsuranceDetails())
        {
            if (ValidateVehicle())
            {
                SubmitForApproval();
            }
        }
    }

    private bool GetVehicleDetails()
    {
        newVehicle.VehicleMake = GetValidInput("Enter vehicle make: ", ValidateNonEmpty);
        newVehicle.VehicleModel = GetValidInput("Enter vehicle model: ", ValidateNonEmpty);
        newVehicle.VehicleYear = int.Parse(GetValidInput("Enter vehicle year: ", ValidateYear));
        newVehicle.VehicleMileage = float.Parse(GetValidInput("Enter vehicle mileage: ", ValidateMileage));
        string vin = GetValidInput("Enter Vehicle Identification Number (VIN): ", ValidateVIN);
        licensePlateNumber = GetValidInput("Enter Singapore license plate number: ", ValidateSingaporeLicensePlate);

        if (IsDuplicateVehicle(vin, licensePlateNumber))
        {
            Console.WriteLine("Error: This vehicle is already registered.");
            Console.WriteLine("Options:");
            Console.WriteLine("1. View existing registration details (if you're the owner)");
            Console.WriteLine("2. Contact customer support");
            Console.WriteLine("3. Cancel registration process");
            
            string choice = GetValidInput("Enter your choice (1-3): ", ValidateMenuChoice);
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Viewing existing registration details...");
                    // In a real implementation, you would show the details here
                    break;
                case "2":
                    Console.WriteLine("Please contact our customer support at support@icar.com");
                    break;
                case "3":
                    Console.WriteLine("Registration process cancelled.");
                    break;
            }
            return false;
        }

        newVehicle.VehicleID = GenerateVehicleID();
        // Store VIN in VehicleID for now, as there's no separate VIN field in the Vehicle class
        return true;
    }

    private bool UploadPhotos()
    {
        newVehicle.VehiclePhotos = new List<string>();
        Console.WriteLine($"Please upload {REQUIRED_PHOTOS} photos of your vehicle.");
        Console.WriteLine("Required photos: 1 front, 1 back, 2 sides, 2 front seats, 2 back seats, 1 dashboard, 1 trunk");
        
        for (int i = 0; i < REQUIRED_PHOTOS; i++)
        {
            string photoPath = GetValidInput($"Enter filename for photo {i + 1}: ", ValidatePhotoFormat);
            newVehicle.VehiclePhotos.Add(photoPath);
        }

        if (newVehicle.VehiclePhotos.Count != REQUIRED_PHOTOS)
        {
            Console.WriteLine($"Error: You must upload exactly {REQUIRED_PHOTOS} photos.");
            return false;
        }

        return true;
    }

    private bool GetOwnershipProof()
    {
        registrationDocument = GetValidInput("Enter vehicle registration document number (format VR######): ", ValidateRegistrationDocument);
        return true;
    }

    private bool GetInsuranceDetails()
    {
        insurancePolicyNumber = GetValidInput("Enter insurance policy number (format INS######): ", ValidateInsurancePolicyNumber);
        insuranceProvider = GetValidInput("Enter insurance provider: ", ValidateNonEmpty);
        return true;
    }

    private bool ValidateVehicle()
    {
        int currentYear = DateTime.Now.Year;
        needsAdditionalReview = false;

        // Check vehicle age
        if (currentYear - newVehicle.VehicleYear > MAX_VEHICLE_AGE)
        {
            Console.WriteLine($"Error: Vehicle is too old. Maximum age is {MAX_VEHICLE_AGE} years.");
            return false;
        }
        else if (currentYear - newVehicle.VehicleYear == MAX_VEHICLE_AGE)
        {
            needsAdditionalReview = true;
        }

        // Check vehicle mileage
        if (newVehicle.VehicleMileage > MAX_MILEAGE)
        {
            Console.WriteLine($"Error: Vehicle mileage exceeds the maximum allowed ({MAX_MILEAGE} km).");
            return false;
        }
        else if (newVehicle.VehicleMileage >= 145000 && newVehicle.VehicleMileage <= MAX_MILEAGE)
        {
            needsAdditionalReview = true;
        }

        if (needsAdditionalReview)
        {
            Console.WriteLine("Note: Your vehicle's age or mileage is close to the limit.");
            Console.WriteLine("The registration is accepted but will be flagged for additional review in the admin approval process.");
        }

        return true;
    }

    private void SubmitForApproval()
    {
        newVehicle.VehicleStatus = "Pending Approval";
        Console.WriteLine("Vehicle registration submitted successfully.");
        Console.WriteLine($"Vehicle ID: {newVehicle.VehicleID}");
        Console.WriteLine("Status: Pending Approval");
        if (needsAdditionalReview)
        {
            Console.WriteLine("Note: This registration has been flagged for additional review due to the vehicle's age or mileage.");
        }
        Console.WriteLine("The vehicle registration will now proceed to the Approve Vehicle use case.");
    }

    private string GetValidInput(string prompt, Func<string, bool> validationFunction)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (validationFunction(input))
            {
                return input;
            }
        }
    }

    private bool ValidateNonEmpty(string input)
    {
        if (!string.IsNullOrWhiteSpace(input))
        {
            return true;
        }
        Console.WriteLine("This field cannot be empty. Please try again.");
        return false;
    }

    private bool ValidateYear(string input)
    {
        if (int.TryParse(input, out int year))
        {
            int currentYear = DateTime.Now.Year;
            if (year >= currentYear - MAX_VEHICLE_AGE && year <= currentYear)
            {
                return true;
            }
        }
        Console.WriteLine($"Invalid year. Please enter a valid year between {DateTime.Now.Year - MAX_VEHICLE_AGE} and {DateTime.Now.Year}.");
        return false;
    }

    private bool ValidateMileage(string input)
    {
        if (float.TryParse(input, out float mileage) && mileage >= 0 && mileage <= MAX_MILEAGE)
        {
            return true;
        }
        Console.WriteLine($"Invalid mileage. Please enter a value between 0 and {MAX_MILEAGE}.");
        return false;
    }

    private bool ValidateVIN(string input)
    {
        if (Regex.IsMatch(input, @"^[A-HJ-NPR-Z0-9]{17}$"))
        {
            return true;
        }
        Console.WriteLine("Invalid VIN. Please enter a 17-character VIN (letters and numbers only, excluding I, O, and Q).");
        return false;
    }

    private bool ValidateSingaporeLicensePlate(string input)
    {
        if (Regex.IsMatch(input, @"^[A-Z]{3}\d{1,4}[A-Z]$"))
        {
            return true;
        }
        Console.WriteLine("Invalid Singapore license plate. Format should be like 'SBA1234A'.");
        return false;
    }

    private bool ValidatePhotoFormat(string input)
    {
        string[] validExtensions = { ".jpg", ".jpeg", ".png" };
        if (validExtensions.Any(ext => input.ToLower().EndsWith(ext)))
        {
            return true;
        }
        Console.WriteLine("Invalid photo format. Please use .jpg, .jpeg, or .png files.");
        return false;
    }

    private bool ValidateRegistrationDocument(string input)
    {
        if (Regex.IsMatch(input, @"^VR\d{6}$"))
        {
            return true;
        }
        Console.WriteLine("Invalid registration document number. Format should be VR followed by 6 digits (e.g., VR123456).");
        return false;
    }

    private bool ValidateInsurancePolicyNumber(string input)
    {
        if (Regex.IsMatch(input, @"^INS\d{6}$"))
        {
            return true;
        }
        Console.WriteLine("Invalid insurance policy number. Format should be INS followed by 6 digits (e.g., INS789012).");
        return false;
    }

    private bool IsDuplicateVehicle(string vin, string licensePlate)
    {
        return existingVehicles.Any(v => v.VIN == vin || v.LicensePlate == licensePlate);
    }

    private string GenerateVehicleID()
    {
        return $"V{new Random().Next(100000, 999999)}";
    }

    private bool ValidateMenuChoice(string input)
    {
        if (input == "1" || input == "2" || input == "3")
        {
            return true;
        }
        Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
        return false;
    }
}