using KomodoClaimsDept_ClaimsRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsDept_Console
{
    class ProgramUI
    {
        private KomodoClaimsRepository _claimsRepo = new KomodoClaimsRepository();
        public void Run()
        {
            SeedClaim();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display Menu Options To User
                Console.WriteLine("Select a menu option:\n" +
                    "1. View All Claims\n" +
                    "2. Review Claim\n" +
                    "3. Enter A New Claim\n" +
                    "4. Exit");

                // Get User's Input
                string input = Console.ReadLine();

                // Evaluate User's Input
                switch (input)
                {
                    case "1":
                        // View All Claims
                        DisplayAllClaims();
                        break;
                    case "2":
                        // Review Claim
                        ReviewClaim();
                        break;
                    case "3":
                        // Create New Claim
                        CreateNewClaim();
                        break;
                    case "4":
                        // Exit
                        Console.WriteLine("Thank you, goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                Console.Clear();

            }
        }

        // View All Claims
        private void DisplayAllClaims()
        {
            Console.Clear();

            Queue<ClaimContent> listOfClaims = _claimsRepo.GetClaimConentList();

            foreach(ClaimContent claim in listOfClaims)
            {
                Console.WriteLine($"ClaimID: {claim.ClaimID}\n" +
                    $"Claim Type: {claim.TypeOfClaim}\n" +
                    $"Description: {claim.Description}\n" +
                    $"Claim Amount: {claim.ClaimAmount}\n" +
                    $"Date of Accident: {claim.DateOfIncident}" +
                    $"Date of claim: {claim.DateOfClaim}\n" +
                    $"IsValid: {claim.IsValid}");
            }
        }
        
        // Review Claim
        private void ReviewClaim()
        {
            Console.Clear();

            ClaimContent nextClaim = _claimsRepo.HandleNextClaim();
            Console.WriteLine($"ClaimID: {nextClaim.ClaimID}\n" +
                $"Type: {nextClaim.TypeOfClaim}\n" +
                $"Description: {nextClaim.Description}\n" +
                $"Amount: {nextClaim.ClaimAmount}\n" +
                $"DateOfAccedent: {nextClaim.DateOfIncident}\n" +
                $"DateOfClaim: {nextClaim.DateOfClaim}\n" +
                $"IsValid: {nextClaim.IsValid}");

            Console.WriteLine("Would you like to handle this claim? (Y/N)");
            string handleClaim = Console.ReadLine().ToLower();

            if (handleClaim == "y")
            {
                _claimsRepo.DequeueClaim();
                Console.WriteLine("The claim was successfully proccesed. Press any key to go back to the menu.");
                Console.ReadKey();
                Console.Clear();
                Menu();
            }
            else
            {
                Console.WriteLine("Press any key to go back to the main menu.");
                Console.ReadKey();
                Console.Clear();
                Menu();
            }
        }

        // Create New Claim
        private void CreateNewClaim()
        {
            Console.Clear();
            ClaimContent newClaim = new ClaimContent();

            // ClaimID
            Console.WriteLine("Enter the new ClaimID:");
            string claimIDAsString = Console.ReadLine();
            newClaim.ClaimID = int.Parse(claimIDAsString);

            // ClaimType
            Console.WriteLine("Enter the new Claim Type Number:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            string claimTypeAsString = Console.ReadLine();
            int claimTypeAsInt = int.Parse(claimTypeAsString);
            newClaim.TypeOfClaim = (ClaimType)claimTypeAsInt;

            // Description
            Console.WriteLine("Enter the description of the new claim:");
            newClaim.Description = Console.ReadLine();

            // ClaimAmount
            Console.WriteLine("Enter the amount of new claim");
            string claimAmountAsString = Console.ReadLine();
            newClaim.ClaimAmount = decimal.Parse(claimAmountAsString);

            // DateOfIncident
            Console.WriteLine("Enter the date of the incident the claim occured: (mm/dd/yyyy)");
            newClaim.DateOfIncident = Console.ReadLine();

            // DateOfClaim
            Console.WriteLine("Enter the date the new claim was submitted: (mm/dd/yyyy)");
            newClaim.DateOfClaim = Console.ReadLine();

            // IsValid
            Console.WriteLine("Is the date of the claim within 30 calendar days of the incident date? (Y/N)");
            string isValidString = Console.ReadLine().ToLower();

            if(isValidString == "y")
            {
                newClaim.IsValid = true;
            }
            else
            {
                newClaim.IsValid = false;
            }

            _claimsRepo.AddClaimToList(newClaim);
        }

        // Seed Method
        private void SeedClaim()
        {
            ClaimContent carAccident = new ClaimContent(1, ClaimType.Car, "Wreck on I-69", 1500m, "08/20/2020", "09/14/2020", true);
            ClaimContent homeClaim = new ClaimContent(2, ClaimType.Home, "Kitchen fire", 5500m, "08/10/2020", "09/09/2020", true);
            ClaimContent theftClaim = new ClaimContent(3, ClaimType.Theft, "Stolen phone", 1000m, "07/30/2020", "09/14/2020", false);

            _claimsRepo.AddClaimToList(carAccident);
            _claimsRepo.AddClaimToList(homeClaim);
            _claimsRepo.AddClaimToList(theftClaim);
        }

    }
}
