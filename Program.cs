
using System;
using Assignment3;

internal class Program
{
    // A static list to store all food items in the inventory
    internal static List<FoodItem> inventory = new List<FoodItem>();
    
    internal static void Main(string[] args)
    { 
        int num; // Variable to store the user's menu choice
        
        bool Running = true; // A flag to keep the program running

        Console.WriteLine("Welcome to Food Bank Inventory System!");
        
        // Main program loop
        while (Running)
        {
            // Display menu options
            Console.WriteLine("\n What do you want to do?");
            Console.WriteLine("1. Add Food Items\n2. Delete Food Items\n3. Print List of Current Food Items\n4. Exit the Program\n Type the number you choose to do.");
            // Read user input and convert to an integer
            num = int.Parse(Console.ReadLine());

            // Handle the user's choice
            if (num == 1)
            {
                AddFoodItems(); // Add a new food item
            }
            else if (num == 2)
            {
                DeleteFoodItem(); // Delete an existing food item
            }
            else if (num == 3)
            {
                PrintInventory(); // Print all food items in the inventory
            }
            else if (num == 4)
            {
                Console.WriteLine("Exiting the program...");
                Running = false; // Exit the loop and end the program
            }
            else
            {
                Console.WriteLine("Invalid choice. Please select a valid option.");
            }
        }
    }

    // Method to add a new food item to the inventory
    internal static void AddFoodItems()
    {
        Console.WriteLine("Enter food name (e.g., \"Canned Beans\"): ");
        string name = Console.ReadLine(); // Read the name of the food item
        
        Console.WriteLine("Enter food category (e.g., \"Canned Goods\", \"Dairy\", \"Produce\"): ");
        string category = Console.ReadLine(); // Read the category of the food item
        
        Console.WriteLine("Enter food quantity (e.g., 15 units): ");
        // Validate quantity input and ensure it's a non-negative number
        if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 0)
        {
            Console.WriteLine("Invalid quantity. Must be a non-negative number.");
            return; // Exit the method if input is invalid
        }
        
        Console.WriteLine("Enter food expiration date (e.g., 02/25/2025): ");
        // Validate expiration date input
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime expiration))
        {
            Console.WriteLine("Invalid date format. Please try again.");
            return; // Exit the method if input is invalid
        }
        
        // Create a new food item and add it to the inventory
        FoodItem newItem = new FoodItem(name, category, quantity, expiration);
        inventory.Add(newItem);
        Console.WriteLine("Food item added successfully.");
    }
    
    // Method to delete a food item from the inventory
    internal static void DeleteFoodItem()
    {
        // If the inventory is empty, notify the user and return
        if (inventory.Count == 0)
        {
            Console.WriteLine("The inventory is currently empty.");
            return;
        }
        
        // Print the current inventory for the user to see
        PrintInventory();

        int index; // Variable to store the item number to delete
        Console.WriteLine("Enter the number of the item to delete: ");
        
        // Validate user input and ensure it's within the valid range
        while (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > inventory.Count)
        {
            Console.WriteLine("Invalid item number. Please try again.");
            Console.WriteLine("Enter the number of the item to delete: ");
        }
        
        // Remove the item at the specified index (adjusting for 0-based indexing)
        inventory.RemoveAt(index - 1);
        Console.WriteLine("Food item deleted successfully.");
        
    }

    // Method to print all food items in the inventory
    private static void PrintInventory()
    {
        // If the inventory is empty, notify the user and return
        if (inventory.Count == 0)
        {
            Console.WriteLine("The inventory is currently empty.");
            return;
        }

        // Print each item in the inventory with its index
        Console.WriteLine("\nCurrent Inventory:");
        for (int i = 0; i < inventory.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {inventory[i]}");
        }
    }
}
