namespace Assignment3;

public class FoodItem
{
    // Properties to store food item details
    public string Name = ""; // The name of the food item
    public string Category = ""; // The category (e.g., "Dairy", "Produce")
    public int Quantity = 0; // The quantity of the food item
    public DateTime Expiration = new DateTime(); // The expiration date of the food item
    
    // Constructor to initialize a new FoodItem
    public FoodItem(string name, string category, int quantity, DateTime expiration)
    {
        Name = name; // Set the name
        Category = category; // Set the category
        Quantity = quantity; // Set the quantity
        Expiration = expiration; // Set the expiration date
    }
    
    // Override the ToString() method to display food item details in a readable format
    public override string ToString()
    {
        return $"Name: {Name} | Category: {Category} | Quantity: {Quantity} | Expires: {Expiration.ToShortDateString()}";
    }

}  


   