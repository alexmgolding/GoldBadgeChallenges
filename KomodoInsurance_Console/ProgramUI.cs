using KomodoInsurance_BadgeRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Dynamic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Console
{
    class ProgramUI
    {
        private KomodoInsuranceBadgeRepository _badgeRepo = new KomodoInsuranceBadgeRepository();
        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display Options to the User
                Console.WriteLine("Security Admin please select your option:\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n" +
                    "4. Exit");

                // Get User's Input
                string input = Console.ReadLine();

                // Evaluate User's Input
                switch (input)
                {
                    case "1":
                        CreateNewBadge();
                        break;
                    case "2":
                        UpdateBadge();
                        break;
                    case "3":
                        DisplayAllBadges();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // Create New Badge
        public void CreateNewBadge()
        {
            Console.WriteLine("Enter the number of the badge:");
            string badgeIDAsString = Console.ReadLine();
            int badgeIDToINT = int.Parse(badgeIDAsString);

            Console.WriteLine("List the door that this badge has access:");
            string doorNumber = Console.ReadLine();

            BadgeAccess newBadge = _badgeRepo.CreateNewBadgeAccess(badgeIDToINT, doorNumber);

            // Additional Doors
            Console.WriteLine("Grant access to other doors? (y/n)");
            string additionalDoorToString = Console.ReadLine().ToLower();

            if (additionalDoorToString == "y")
            {
                Console.WriteLine("Enter the door you'd like to add to this badge:");
                string doorNumberAsString = Console.ReadLine();
                newBadge.DoorNumber.Add(badgeIDAsString);
            }
            else
            {
                Menu();
            }



        }
        // Update Door Access
        private void UpdateBadge()
        {
            Console.Clear();
            // BadgeID
            Console.WriteLine("Enter the badge number:");
            string badgeNumberAsString = Console.ReadLine();
            BadgeAccess badge = _badgeRepo.GetBadgeById(int.Parse(badgeNumberAsString));
            Console.WriteLine($"{badge.BadgeID} has access to doors {badge.DoorNumber}.");

            Console.WriteLine("How would you like to proceed?\n" +
                "1. Remove Door\n" +
                "2. Add Door");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine("Which door would you like to remove?");
                    string doorRemoval = Console.ReadLine();
                    _badgeRepo.RemoveDoorAccess(badge.BadgeID, doorRemoval);
                    break;
                case "2":
                    Console.WriteLine("Which door would you like to add?");
                    string doorAddition = Console.ReadLine();
                    _badgeRepo.AddDoorAccess(badge.BadgeID, doorAddition);
                    break;
                default:
                    Console.WriteLine("Please enter a valid option.");
                    break;
            }
        }

        // Display All Badges
        private void DisplayAllBadges()
        {
            Console.Clear();
            Dictionary<int, BadgeAccess> badgeDict = _badgeRepo.DisplayBadgeAccess();
        }
    }
}
