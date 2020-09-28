using KomodoCafe_MenuRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeConsole
{
    class ProgramUI
    {
        private MenuItemsRepository _menuItemRepo = new MenuItemsRepository();

        // Method that runs/starts the application (UI part of application)
        public void Run()
        {
            DemoItemList();
            Menu();
        }

        // Menu

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                // Display our options to the user
                Console.WriteLine("Select a menu option:\n" +
                    "1. Create New Menu Item\n" +
                    "2. View Full Menu\n" +
                    "3. View Menu Item By Name\n" +
                    "4. Update Existing Menu Item\n" +
                    "5. Delete Existing Menu Item\n" +
                    "6. Exit");

                // Get the user's input
                string input = Console.ReadLine();

                // Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        // Create New Menu Item
                        CreateNewMenuItem();
                        break;
                    case "2":
                        // View All Content
                        DisplayAllMenuItems();
                        break;
                    case "3":
                        // View Content By Menu Item Name
                        DisplayItemByName();
                        break;
                    case "4":
                        // Update Existng Menu Item
                        UpdateExistingMenuItem();
                        break;
                    case "5":
                        // Delete Existing Menu Item
                        DeleteExistingMenuItem();
                        break;
                    case "6":
                        // Exit
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // Create New Menu Item
        private void CreateNewMenuItem()
        {
            Console.Clear();
            MenuItems newItem = new MenuItems();

            // MenuNumber
            Console.WriteLine("Enter the menu number for the new item:");
            string menuNumberAsString = Console.ReadLine();
            newItem.MenuNumber = int.Parse(menuNumberAsString);

            // MenuName
            Console.WriteLine("Enter the menu name for the new item:");
            newItem.MenuName = Console.ReadLine();

            // MenuDescription
            Console.WriteLine("Enter a bref description for the new item:");
            newItem.MenuDescription = Console.ReadLine();

            // MenuIngredients
            Console.WriteLine("Enter the ingredients for the new item:");
            newItem.MenuIngredients = Console.ReadLine();

            // MenuPrice
            Console.WriteLine("Enter the price for the new item:");
            string menuPriceAsString = Console.ReadLine();
            newItem.MenuPrice = decimal.Parse(menuPriceAsString);

            _menuItemRepo.AddMenuItemToList(newItem);
        }

        // View Full Menu
        private void DisplayAllMenuItems()
        {
            Console.Clear();

            List<MenuItems> listOfItems = _menuItemRepo.GetMenuItemsList();

            foreach(MenuItems item in listOfItems)
            {
                Console.WriteLine($"Menu Item Name: {item.MenuName}\n" +
                    $"Description: {item.MenuDescription}");
            }
        }

        // View Menu Item By Name
        private void DisplayItemByName()
        {
            Console.Clear();

            // Prompt the user to give a menu item name
            Console.WriteLine("Enter the menu item name you'd like to see:");

            // Get the user's input
            string menuName = Console.ReadLine();

            // Find the menu item by the name
            MenuItems items = _menuItemRepo.GetMenuItems(menuName);

            // Display said content if it isn't null
            if(items != null)
            {
                Console.WriteLine($"Menu Number: {items.MenuNumber}\n" +
                    $"Menu Name: {items.MenuName}\n" +
                    $"Description: {items.MenuDescription}\n" +
                    $"Ingredients: {items.MenuIngredients}\n" +
                    $"Price: {items.MenuPrice}");
            }
            else
            {
                Console.WriteLine("No menu item by name provided.");
            }

        }

        // Update Existing Menu Item
        private void UpdateExistingMenuItem()
        {
            // Display all content
            DisplayAllMenuItems();

            // Ask for the title of the content to update
            Console.WriteLine("Enter the menu name you'd like to update:");

            // Get the menu item
            string oldMenuItem = Console.ReadLine();

            // Build a new object
            MenuItems newItems = new MenuItems();

            // Menu Item Number
            Console.WriteLine("Enter the new menu item number:");
            string menuNumberAsString = Console.ReadLine();
            newItems.MenuNumber = int.Parse(menuNumberAsString);

            // Menu Item Name
            Console.WriteLine("Enter the title for the new menu item:");
            newItems.MenuName = Console.ReadLine();

            // Description
            Console.WriteLine("Enter a brief description for the new menu item:");
            newItems.MenuDescription = Console.ReadLine();

            // Ingredients
            Console.WriteLine("Enter the ingredients for the new menu item:");
            newItems.MenuIngredients = Console.ReadLine();

            // Price
            Console.WriteLine("Enter the price of the new menu item:");
            string menuPriceAsString = Console.ReadLine();
            newItems.MenuPrice = decimal.Parse(menuPriceAsString);

            // Verify the update worked
            bool wasUpdated = _menuItemRepo.UpdateExistingMenuItem(oldMenuItem, newItems);
            if (wasUpdated)
            {
                Console.WriteLine("Menu item successfully added to menu.");
            }
            else
            {
                Console.WriteLine("Menu item wasn't added to the menu.");
            }
        }

        // Delete Existing Menu Item
        private void DeleteExistingMenuItem()
        {
            DisplayAllMenuItems();

            // Get Menu Name user wants to remove
            Console.WriteLine("\nEnter the menu name of the item you'd like to remove:");
            string input = Console.ReadLine();

            // Call the delete method
            bool itemDeleted = _menuItemRepo.RemoveItemFromList(input);

            if (itemDeleted)
            {
                Console.WriteLine("The menu item was successfully removed from the menu.");
            }
            else
            {
                Console.WriteLine("The menu item was NOT removed from the menu.");
            }
        }

        // Seed Method
        private void DemoItemList()
        {
            MenuItems bigMac = new MenuItems(1, "Big Mac", "American Staple Burger", "Bun, lettuce, tomato, onion, pickle, hamburger patty, cheese", 5.00m );
            MenuItems doubleCheeseburger = new MenuItems(2, "Double Cheese", "Double the Fun Burger", "Bun, lettuce, tomato, onion, pickle, two hamburger patty, 2 slices of cheese", 7.00m);
            MenuItems chickenNuggets = new MenuItems(3, "Chicken Nugs", "Kid Friendly", "All White Meat Chicken", 2.00m);

            _menuItemRepo.AddMenuItemToList(bigMac);
            _menuItemRepo.AddMenuItemToList(doubleCheeseburger);
            _menuItemRepo.AddMenuItemToList(chickenNuggets);
        }
    }
}
