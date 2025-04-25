namespace Text_Based_RPG;
using Text_Based_RPG;
/*
 * made by tom, shop interface system
 */
public class Shop
{
    private List<Item> Inventory { get; set; }

    public Shop(List<Item> initialInventory)
    {
        Inventory = initialInventory;
    }

    public void OpenShop(Player player)
    {
        bool shopping = true;
        while (shopping)
        {
            Console.WriteLine("\nWelcome to the Shop! What would you like to do?");
            Console.WriteLine("1. Buy Items");
            Console.WriteLine("2. Sell Items");
            Console.WriteLine("3. View Inventory");
            Console.WriteLine("4. Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BuyItems(player);
                    break;
                case "2":
                    SellItems(player);
                    break;
                case "3":
                    player.Inventory.DisplayInventory();
                    break;
                case "4":
                    shopping = false;
                    Console.WriteLine("Thank you for visiting the shop!");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    private void BuyItems(Player player)
    {
        Console.WriteLine("\nItems for Sale:");
        for (int i = 0; i < Inventory.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Inventory[i].Name} - {Inventory[i].Price} Gold - {Inventory[i].Description}");
        }

        int choice = InputHelper.ReadInt("Enter the number of the item to buy (0 to cancel):") - 1;
        if (choice >= 0 && choice < Inventory.Count)
        {
            Item item = Inventory[choice];
            if (player.GoldBalance >= item.Price)
            {
                player.GoldBalance -= item.Price;
                player.Inventory.AddItem(item);
                Console.WriteLine($"You bought {item.Name} for {item.Price} gold.");
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

    private void SellItems(Player player)
    {
        player.Inventory.DisplayInventory();
        int choice = InputHelper.ReadInt("Enter the number of the item to sell (0 to cancel):") - 1;
        if (choice >= 0 && choice < player.Inventory.Items.Count)
        {
            Item item = player.Inventory.Items[choice];
            player.GoldBalance += item.Price / 2; // Sell for half price
            player.Inventory.RemoveItem(item);
            Console.WriteLine($"You sold {item.Name} for {item.Price / 2} gold.");
        }
        else if (choice != -1)
        {
            Console.WriteLine("Invalid selection.");
        }
    }
}