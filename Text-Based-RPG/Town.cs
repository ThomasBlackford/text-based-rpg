// its a town Lul made by tom
using Text_Based_RPG;
public class Town
{
    public string Name { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public Shop TownShop { get; set; }
    public bool HasQuest { get; set; } = false;

    public Town(string name, int x, int y, Shop shop, bool hasQuest = false)
    {
        Name = name;
        X = x;
        Y = y;
        TownShop = shop;
        HasQuest = hasQuest;
    }
    
    
    public void Visit(Player player)
    {
        bool inTown = true;
        while (inTown)
        {
            Console.Clear();
            Console.WriteLine($"\nWelcome to {Name}!");
            Console.WriteLine("1. Visit Shop");
            Console.WriteLine("2. Rest at Inn (Full Heal)");
            if (HasQuest) Console.WriteLine("3. Take Quest");
            Console.WriteLine("4. Leave Town");
            Console.WriteLine("5. View Stats");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    TownShop.OpenShop(player);
                    break;
                case "2":
                    player.Heal(player.MaxHealth);
                    Console.WriteLine("You rest and recover all health!");
                    Console.ReadKey();
                    break;
                case "3" when HasQuest:
                    StartQuest(player);
                    break;
                case "4":
                    inTown = false;
                    Console.WriteLine("You leave the town.");
                    break;
                case "5":
                    player.DisplayStats();
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void StartQuest(Player player)
    {
        Console.WriteLine("\nQuest: Clear the cave of bandits!");
        Console.WriteLine("Reward: 100 gold and 50 XP");
        Console.WriteLine("Accept? (Y/N)");
        
        if (Console.ReadLine().ToUpper() == "Y")
        {
            // Logic to mark quest as active to be here (wont happen)
            Console.WriteLine("Quest accepted! The cave is to the southeast.");
        }
        Console.ReadKey();
    }
}