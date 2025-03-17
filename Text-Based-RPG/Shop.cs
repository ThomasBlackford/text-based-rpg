namespace Text_Based_RPG; 
/*
 * File made by Thomas Blackford
 */
public class Shop
{
     private List<Item> inventory;

    public Shop(List<Item> initialInventory)
    {
        inventory = initialInventory;
    }

    public void OpenShop(Player player)
    {
        bool shopping = true;
        while (shopping)
        {
            Console.WriteLine("\nWelcome to the Shop! What would you like to do?");
            Console.WriteLine("1. Buy Items");
            Console.WriteLine("2. Sell Items");
            Console.WriteLine("3. Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayItems();
                    BuyItem(player);
                    break;
                case "2":
                    SellItem(player);
                    break;
                case "3":
                    shopping = false;
                    Console.WriteLine("Thank you for visiting the shop!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select 1, 2, or 3.");
                    break;
            }
        }
    }

    private void DisplayItems() //displays all items for sale by specific merchant
    {
        Console.WriteLine("\nItems for Sale:");
        for (int i = 0; i < inventory.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {inventory[i].Name} - {inventory[i].Price} Gold - {inventory[i].Description}");
        }
    } //test

    private void BuyItem(Player player) //handles purhcases
    {
        int choice = inputHelper.ReadInt("Enter the number of the item to buy (0 to cancel):") - 1;
        
        if (choice >= 0 && choice < inventory.Count)
        {
            Item itemToBuy = inventory[choice];
            if (player.GoldBalance >= itemToBuy.Price)
            {
                player.GoldBalance -= itemToBuy.Price;
                Console.WriteLine($"You bought {itemToBuy.Name} for {itemToBuy.Price} gold.");
                // add items to inventory here later, when its more developed
            }
            else
            {
                Console.WriteLine("You don't have enough gold.");
            }
        }
        else if (choice != -1)
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    private void SellItem(Player player)  //havent implemented this yet
    {
        Console.WriteLine("\nXd");
    }
}