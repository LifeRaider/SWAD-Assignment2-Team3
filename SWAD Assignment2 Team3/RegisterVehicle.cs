using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class RegisterVehicleSequence
{
    public class CarOwner
    {
        public string Name { get; set; }
        public string UserId { get; set; }

        public CarOwner(string name, string userId)
        {
            Name = name;
            UserId = userId;
        }

        public void RegisterVehicle(UIRegisterVehicle ui)
        {
            Console.WriteLine($"CarOwner {Name} initiates vehicle registration");
            ui.DisplayRegistrationForm();
        }

        public void SubmitVehicleDetails(UIRegisterVehicle ui, VehicleDetails details)
        {
            Console.WriteLine("CarOwner submits vehicle details");
            ui.RegisterVehicle(details);
        }

        public void SubmitVehiclePhotos(UIRegisterVehicle ui, List<string> photos)
        {
            Console.WriteLine("CarOwner submits vehicle photos");
            ui.RegisterVehicle(photos);
        }

        public void SubmitOwnershipProof(UIRegisterVehicle ui, string proof)
        {
            Console.WriteLine("CarOwner submits ownership proof");
            ui.RegisterVehicle(proof);
        }

        public void SubmitInsuranceDetails(UIRegisterVehicle ui, InsuranceDetails insurance)
        {
            Console.WriteLine("CarOwner submits insurance details");
            ui.RegisterVehicle(insurance);
        }

        public void SubmitRegistration(UIRegisterVehicle ui)
        {
            Console.WriteLine("CarOwner submits registration");
            ui.SubmitRegistration();
        }

        public void FixErrors(UIRegisterVehicle ui, List<string> errors)
        {
            Console.WriteLine("CarOwner fixing errors: " + string.Join(", ", errors));
            // Simulate fixing errors
            ui.FixError("Fixed: " + string.Join(", ", errors));
        }

        public void ConfirmDetails(UIRegisterVehicle ui)
        {
            Console.WriteLine("CarOwner confirms details");
            ui.ConfirmDetails();
        }
    }

    public class UIRegisterVehicle
    {
        private CTLRegisterVehicle controller;

        public UIRegisterVehicle(CTLRegisterVehicle controller)
        {
            this.controller = controller;
        }

        public void DisplayRegistrationForm()
        {
            Console.WriteLine("UI displays registration form");
        }

        public void RegisterVehicle(VehicleDetails details)
        {
            Console.WriteLine("UI passes vehicle details to controller");
            controller.RegisterVehicle(details);
        }

        public void RegisterVehicle(List<string> photos)
        {
            Console.WriteLine("UI passes vehicle photos to controller");
            controller.RegisterVehicle(photos);
        }

        public void RegisterVehicle(string ownershipProof)
        {
            Console.WriteLine("UI passes ownership proof to controller");
            controller.RegisterVehicle(ownershipProof);
        }

        public void RegisterVehicle(InsuranceDetails insurance)
        {
            Console.WriteLine("UI passes insurance details to controller");
            controller.RegisterVehicle(insurance);
        }

        public void SubmitRegistration()
        {
            Console.WriteLine("UI submits registration to controller");
            controller.SubmitRegistration();
        }

        public void DisplayConfirmation()
        {
            Console.WriteLine("UI displays confirmation");
        }

        public void DisplayError(List<string> errors)
        {
            Console.WriteLine("UI displays errors: " + string.Join(", ", errors));
        }

        public void FixError(string fixedError)
        {
            Console.WriteLine("UI passes fixed error to controller: " + fixedError);
            controller.FixError(fixedError);
        }

        public void ConfirmDetails()
        {
            Console.WriteLine("UI passes confirmation to controller");
            controller.ConfirmDetails();
        }

        public void DisplaySubmission(Vehicle newVehicle)
        {
            Console.WriteLine($"UI displays submission for vehicle {newVehicle.VehicleID}");
        }

        public void DisplayApprovalProcessInfo()
        {
            Console.WriteLine("UI displays approval process information");
        }
    }

    public class CTLRegisterVehicle
    {
        private ICarSystem iCarSystem;
        private VehicleDetails vehicleDetails;
        private List<string> vehiclePhotos;
        private string ownershipProof;
        private InsuranceDetails insuranceDetails;

        public CTLRegisterVehicle(ICarSystem iCarSystem)
        {
            this.iCarSystem = iCarSystem;
        }

        public void RegisterVehicle(VehicleDetails details)
        {
            Console.WriteLine("Controller processes vehicle details");
            this.vehicleDetails = details;
        }

        public async Task RegisterVehicle(List<string> photos)
        {
            Console.WriteLine("Controller processes vehicle photos");
            this.vehiclePhotos = new List<string>();
            foreach (var photo in photos)
            {
                var photoUrl = await iCarSystem.UploadPhoto(photo);
                this.vehiclePhotos.Add(photoUrl);
            }
        }

        public void RegisterVehicle(string ownershipProof)
        {
            Console.WriteLine("Controller processes ownership proof");
            this.ownershipProof = ownershipProof;
        }

        public void RegisterVehicle(InsuranceDetails insurance)
        {
            Console.WriteLine("Controller processes insurance details");
            this.insuranceDetails = insurance;
        }

        public void SubmitRegistration()
        {
            Console.WriteLine("Controller submits registration for validation");
            var formData = new RegistrationFormData
            {
                VehicleDetails = this.vehicleDetails,
                VehiclePhotos = this.vehiclePhotos,
                OwnershipProof = this.ownershipProof,
                InsuranceDetails = this.insuranceDetails
            };
            var validationResult = iCarSystem.ValidateData(formData);
            if (validationResult.IsValid)
            {
                Console.WriteLine("Validation successful");
            }
            else
            {
                Console.WriteLine("Validation failed: " + string.Join(", ", validationResult.Errors));
            }
        }

        public void FixError(string fixedError)
        {
            Console.WriteLine("Controller processes fixed error: " + fixedError);
            // In a real implementation, you would update the relevant data here
        }

        public void ConfirmDetails()
        {
            Console.WriteLine("Controller confirms details and creates vehicle");
            var newVehicle = iCarSystem.CreateVehicle(new RegistrationFormData
            {
                VehicleDetails = this.vehicleDetails,
                VehiclePhotos = this.vehiclePhotos,
                OwnershipProof = this.ownershipProof,
                InsuranceDetails = this.insuranceDetails
            });
            Console.WriteLine($"New vehicle created with ID: {newVehicle.VehicleID}");
        }
    }

    public class ICarSystem
    {
        public async Task<string> UploadPhoto(string photo)
        {
            // Simulate photo upload
            await Task.Delay(100);  // Simulate network delay
            return $"https://icar.com/photos/{Guid.NewGuid()}.jpg";
        }

        public ValidationResult ValidateData(RegistrationFormData formData)
        {
            var errors = new List<string>();

            // Validate vehicle details
            if (formData.VehicleDetails.Year < 2014 || formData.VehicleDetails.Year > DateTime.Now.Year)
            {
                errors.Add("Invalid vehicle year");
            }
            if (formData.VehicleDetails.Mileage > 150000)
            {
                errors.Add("Mileage exceeds limit");
            }
            if (string.IsNullOrEmpty(formData.VehicleDetails.Make) || string.IsNullOrEmpty(formData.VehicleDetails.Model))
            {
                errors.Add("Make and model must be provided");
            }

            // Validate photos
            if (formData.VehiclePhotos.Count < 10)
            {
                errors.Add("At least 10 photos must be provided");
            }

            // Validate ownership proof
            if (string.IsNullOrEmpty(formData.OwnershipProof))
            {
                errors.Add("Ownership proof must be provided");
            }

            // Validate insurance details
            if (formData.InsuranceDetails.ExpiryDate <= DateTime.Now)
            {
                errors.Add("Insurance policy has expired");
            }

            return new ValidationResult { IsValid = errors.Count == 0, Errors = errors };
        }

        public Vehicle CreateVehicle(RegistrationFormData formData)
        {
            var vehicle = new Vehicle(
                Guid.NewGuid().ToString(),
                formData.VehicleDetails.Make,
                formData.VehicleDetails.Model,
                formData.VehicleDetails.Year,
                formData.VehicleDetails.Mileage,
                formData.VehicleDetails.OwnerId
            );

            vehicle.VehiclePhotos = formData.VehiclePhotos;
            vehicle.VehicleStatus = "Pending Approval";

            // In a real implementation, you would save this to a database
            Console.WriteLine($"Vehicle created and saved: {vehicle.VehicleID}");

            return vehicle;
        }
    }

    public class VehicleDetails
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public string OwnerId { get; set; }
    }

    public class InsuranceDetails
    {
        public string PolicyNumber { get; set; }
        public string Provider { get; set; }
        public DateTime ExpiryDate { get; set; }
    }

    public class RegistrationFormData
    {
        public VehicleDetails VehicleDetails { get; set; }
        public List<string> VehiclePhotos { get; set; }
        public string OwnershipProof { get; set; }
        public InsuranceDetails InsuranceDetails { get; set; }
    }

    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public List<string> Errors { get; set; }
    }

    public static async Task SimulateRegisterVehicleSequence()
    {
        var iCarSystem = new ICarSystem();
        var controller = new CTLRegisterVehicle(iCarSystem);
        var ui = new UIRegisterVehicle(controller);
        var carOwner = new CarOwner("John Doe", "U123456");

        carOwner.RegisterVehicle(ui);

        var vehicleDetails = new VehicleDetails
        {
            Make = "Toyota",
            Model = "Corolla",
            Year = 2020,
            Mileage = 50000,
            OwnerId = carOwner.UserId
        };
        carOwner.SubmitVehicleDetails(ui, vehicleDetails);

        var photos = new List<string> { "photo1.jpg", "photo2.jpg", "photo3.jpg", "photo4.jpg", "photo5.jpg",
                                        "photo6.jpg", "photo7.jpg", "photo8.jpg", "photo9.jpg", "photo10.jpg" };
        carOwner.SubmitVehiclePhotos(ui, photos);

        carOwner.SubmitOwnershipProof(ui, "OwnershipDoc123.pdf");

        var insuranceDetails = new InsuranceDetails
        {
            PolicyNumber = "INS123456",
            Provider = "ABC Insurance",
            ExpiryDate = DateTime.Now.AddYears(1)
        };
        carOwner.SubmitInsuranceDetails(ui, insuranceDetails);

        carOwner.SubmitRegistration(ui);

        // Simulate confirmation and vehicle creation
        carOwner.ConfirmDetails(ui);

        Console.WriteLine("Vehicle registration process completed.");
    }
}