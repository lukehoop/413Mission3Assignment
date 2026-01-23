using System;
using System.Collections.Generic;
using System.Text;

namespace _413Mission3Assignment
{
    class Program
    {
        // creates inventory list here so every method can access
        static List<FoodItem> inventory = new List<FoodItem>();

        // main method
        static void Main(string[] args)
        {
            // while loop to run until user manually breaks out
            while (true)
            {
                // prints menu each loop
                string user_selection = "";
                Console.WriteLine("Please select an option from the menu:");
                Console.WriteLine("1. Add Food Items");
                Console.WriteLine("2. Delete Food Items");
                Console.WriteLine("3. Print List of Current Food Items");
                Console.WriteLine("4. Exit the Program");
                user_selection = Console.ReadLine();

                if (user_selection == "1")
                {
                    AddFoodItem();
                }
                else if (user_selection == "2")
                {
                    DeleteFoodItem();
                }
                else if (user_selection == "3")
                {
                    PrintFoodItems();
                }
                else if (user_selection == "4")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid selection. Please type any number to make a new selection.");
                }
            }
        }


        // define functions to be called when the selection
        static void AddFoodItem()
        {
            // user inputs
            Console.WriteLine("Enter the food item's name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the food item's category:");
            string category = Console.ReadLine();

            Console.WriteLine("Enter the food item's quantity:");
            string quantityString = Console.ReadLine();

            // error handling for num
            if (!int.TryParse(quantityString, out int quantity))
            {
                Console.WriteLine("Error: Quantity must be a number.");
                return;
            }

            // error handling for negative
            if (quantity < 0)
            {
                Console.WriteLine("Error: Quantity cannot be negative.");
                return;
            }

            Console.WriteLine("Enter the food item's expiration date (MM/DD/YYYY):");
            string dateString = Console.ReadLine();

            // date error handling 
            if (!DateTime.TryParse(dateString, out DateTime expirationDate))
            {
                Console.WriteLine("Error: Invalid date format.");
                return;
            }

            // create new instance of fooditem
            FoodItem food = new FoodItem(name, category, quantity, expirationDate);
            inventory.Add(food);

            Console.WriteLine("Food item successfully added.");
        }

        static void DeleteFoodItem()
        {
            // check if empty
            if (inventory.Count == 0)
            {
                Console.WriteLine("Inventory is empty.");
                return; 
            }

            // print list for user to pick from
            int i = 1; 
            foreach (FoodItem item in inventory)
            {
                Console.WriteLine(i + ". " + item.Name);
                i++;
            }

            // user input for selection
            Console.WriteLine("Enter the number of the item you wish to delete:");
            string userInput = Console.ReadLine();

            // error handling for potential inputs
            if (!int.TryParse(userInput, out int itemNumber))
            {
                Console.WriteLine("Error: Please enter a valid number.");
                return;
            }

            // check if in range
            if (itemNumber < 1 || itemNumber > inventory.Count)
            {
                Console.WriteLine($"Error: Please enter a number between 1 and {inventory.Count}.");
                return;
            }

            // remove item (-1) because index is dumb
            inventory.RemoveAt(itemNumber - 1);
            Console.WriteLine("Item successfully deleted.");
        }

        static void PrintFoodItems()
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("Inventory is empty.");
                return;
            }
            Console.WriteLine("=== CURRENT INVENTORY ===");
            Console.WriteLine("Name | Category | Quantity | Expiration");
            foreach (FoodItem item in inventory)
            {
                Console.WriteLine(item.Name + " | " + item.Category + " | " + item.Quantity + " | " + item.ExpirationDate.ToShortDateString());
            }

        }
    }
}