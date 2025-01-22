using System;

public class FoodItem
{
    // each food has a name, category, quantity, and expiration date
    public string Name { get; set; }
    public string Category { get; set; }
    public int Quantity { get; set; }
    public DateTime ExpirationDate { get; set; }

    // getting the info for each food item set up with FoodItem
    public FoodItem(string name, string category, int quantity, DateTime expirationDate)
    {
        // error handling - making sure there is atleast 1 of the food in stock
        if (quantity < 0)
            throw new ArgumentException("Quantity must be positive.");

        Name = name;
        Category = category;
        Quantity = quantity;
        ExpirationDate = expirationDate;
    }

    // ToString is called in the PrintFoodItems method so the food is printed out in a nice way
    public override string ToString()
    // printing each individual food item with how much it has
    {
        return $"{Name} ({Category}) - {Quantity} units - Expires on {ExpirationDate:MM/dd/yyyy}";
    }

}