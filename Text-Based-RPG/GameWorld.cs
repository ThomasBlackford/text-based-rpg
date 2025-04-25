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

    private static Shop riverdaleShop = new Shop(new List<Item>
    {
        new Item("Short Sword", 50, "Basic sword", Enums.ItemType.Weapon, 3),
        new Item("Health Potion", 10, "Heals 5 HP", Enums.ItemType.Consumable, 5)
    });

    private static Shop mountainviewShop = new Shop(new List<Item>
    {
        new Item("Long Sword", 75, "Better sword", Enums.ItemType.Weapon, 5),
        new Item("Leather Armor", 50, "Basic armor", Enums.ItemType.Armor, 3)
    });

    public static void VisitTown(Player player, string townName)
    {
        bool inTown = true;
        while (inTown)
        {
            Console.Clear();
            Console.WriteLine($"\nWelcome to {townName}!");
            Console.WriteLine("1. Visit Shop");
            Console.WriteLine("2. Rest at Inn (Full Heal)");
            if (townName == "Mountainview") Console.WriteLine("3. Take Bandit Cave Quest");
            Console.WriteLine("4. Leave Town");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    if (townName == "Riverdale") riverdaleShop.OpenShop(player);
                    else mountainviewShop.OpenShop(player);
                    break;
                case "2":
                    player.Heal(player.MaxHealth);
                    Console.WriteLine("You rested and recovered all health!");
                    Console.ReadKey();
                    break;
                case "3" when townName == "Mountainview":
                    Console.WriteLine("Quest: Clear the Bandit Cave!");
                    Console.WriteLine("Reward: 100 gold and 50 XP");
                    Console.ReadKey();
                    break;
                case "4":
                    inTown = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    Console.ReadKey();
                    break;
            }
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
    
     public static void ExploreCave(Player player)
        {
            Console.WriteLine("\nYou enter the dark cave...");
            var bandits = new List<Enemy>
            {
                new Enemy("Bandit", 25, 8, 12, 15, 30),
                new Enemy("Bandit Leader", 40, 12, 15, 50, 75)
            };
    
            foreach (var enemy in bandits)
            {
                Console.WriteLine($"A {enemy.Name} attacks!");
                while (enemy.IsAlive() && player.CurrentHealth > 0)
                {
                    // Combat logic to be here
                }
                
                if (player.CurrentHealth <= 0) return;
            }
    
            Console.WriteLine("You cleared the cave of bandits!");
            player.GoldBalance += 100;
            player.AddXP(50);
            Console.ReadKey();
        }

    
}