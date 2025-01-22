using System;
using System.Collections.Generic;
// program.cs controls the flow of the program

class Program
{
    static List<FoodItem> inventory = new List<FoodItem>();

    // the main method doesn't return any value and it starts here
    static void Main(string[] args)
    {
        while (true)
        {
            // all of the options at the beginning
            Console.WriteLine("\nFood Bank Inventory System");
            Console.WriteLine("1-Add Food Item");
            Console.WriteLine("2-Delete Food Item");
            Console.WriteLine("3-Print List of Current Food Items");
            Console.WriteLine("4-Exit the Program");
            Console.WriteLine("Choose an option:");

            string choice = Console.ReadLine();

            // this is just taking the user to the method they want based on the number they said
            switch (choice)
            {
                case "1":
                    AddFoodItem();
                    break;
                case "2":
                    DeleteFoodItem();
                    break;
                case "3":
                    PrintFoodItems();
                    break;
                case "4":
                    // exit the program if they type 4
                    Console.WriteLine("Exiting the program");
                    return;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

    // menu to add food method
    static void AddFoodItem()
    {
        // getting the info for each food item (to be sent to FoodItem.cs)
        Console.Write("Enter the food item: ");
        string name = Console.ReadLine();

        Console.Write("Enter the food item category: ");
        string category = Console.ReadLine();

        Console.Write("Enter the quantity: ");
        int quantity = int.Parse(Console.ReadLine());

        Console.Write("Enter the expiration date (MM/DD/YYYY): ");
        DateTime expirationDate = DateTime.Parse(Console.ReadLine());

        // this line is where I'm creating a new object using the FoodItem constructor
        FoodItem newItem = new FoodItem(name, category, quantity, expirationDate);
        
        // food item stores info for individual food with a list (called inventory)
        inventory.Add(newItem);

        Console.WriteLine("Food item added :)");
    }

    // delete food method
    static void DeleteFoodItem()
    {
        Console.WriteLine("Enter the food you want to delete: ");
        string name = Console.ReadLine();

        // this allows you to search for food ignoring upper and lower case
        FoodItem itemToRemove = inventory.Find(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (itemToRemove != null)
        {
            // deleting from the list (inventory is the list of food items)
            inventory.Remove(itemToRemove);
            Console.WriteLine("Item deleted!");
        }
        // telling you if it can't find the item
        else
        {
            Console.WriteLine("Item not found");
        }
    }

    // print list of current food options method
    static void PrintFoodItems()
    {
        // error handling - if there is not inventory tell the user
        if (inventory.Count == 0)
        {
            Console.WriteLine("No food items in inventory");
        }
        else
        {
            Console.WriteLine("Current food items: ");
            foreach (var item in inventory)
            {
                // ToString prints out the item in the string set up on FoodItem.cs
                Console.WriteLine(item.ToString());
            }
        }
    }
}

