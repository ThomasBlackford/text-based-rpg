namespace Text_Based_RPG;
using Text_Based_RPG;

public static class GameWorld
{
    public static List<Enemy> Enemies { get; private set; } = new List<Enemy>
    {
        new Enemy("Bandit", 20, 5, 10, 10, 20),
        new Enemy("Goblin", 15, 7, 12, 15, 25),
        new Enemy("Orc", 30, 10, 15, 20, 30)
    };

    public static Shop TownShop { get; private set; } = new Shop(new List<Item>
    {
        new Item("Sword", 50, "A sharp blade.", Enums.ItemType.Weapon, 5),
        new Item("Potion", 10, "Restores 5 HP.", Enums.ItemType.Consumable, 5),
        new Item("Leather Armor", 30, "Basic armor.", Enums.ItemType.Armor, 3)
    });

    public static void VisitTown(Player player)
    {
        Console.WriteLine("\nYou are in the town. What would you like to do?");
        Console.WriteLine("1. Visit Shop");
        Console.WriteLine("2. Rest at Inn");
        Console.WriteLine("3. Go to the Forest");
        Console.WriteLine("4. Exit Town");
        Console.WriteLine("5. Check stats");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                TownShop.OpenShop(player);
                break;
            case "2":
                player.Heal(player.MaxHealth);
                Console.WriteLine("You rested and restored your health.");
                break;
            case "3":
                ExploreForest(player);
                break;
            case "4":
                Console.WriteLine("You leave the town.");
                break;
            case "5":
                Console.WriteLine("Your stats:");
                player.DisplayStats();
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    public static void ExploreForest(Player player)
    {
        Console.WriteLine("\nYou enter the forest...");
        Random rng = new Random();
        Enemy enemy = Enemies[rng.Next(Enemies.Count)];
        Console.WriteLine($"A wild {enemy.Name} appears!");

        while (enemy.IsAlive() && player.CurrentHealth > 0)
        {
            Console.WriteLine("\n1. Attack\n2. Run");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CombatSystem.Attack(player, enemy);
                    if (enemy.IsAlive())
                        CombatSystem.EnemyTurn(player, enemy);
                    break;
                case "2":
                    Console.WriteLine("You run away!");
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        if (!enemy.IsAlive())
        {
            Console.WriteLine($"You defeated the {enemy.Name}!");
            player.GoldBalance += enemy.GoldReward;
            player.AddXP(enemy.XPReward);
        }
    }
}