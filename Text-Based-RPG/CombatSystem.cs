namespace Text_Based_RPG;
using Text_Based_RPG;
public static class CombatSystem
{
    private static readonly Random rng = new Random();

    public static void StartCombat(Player player, Enemy enemy)
    {
        Console.WriteLine($"\nA wild {enemy.Name} appears! (HP: {enemy.Health})");
        
        while (player.IsAlive() && enemy.IsAlive())
        {
            PlayerTurn(player, enemy);
            if (!enemy.IsAlive()) break;
            
            EnemyTurn(player, enemy);
        }

        HandleCombatEnd(player, enemy);
    }

    private static void PlayerTurn(Player player, Enemy enemy)
    {
        Console.WriteLine("\nYour turn:");
        Console.WriteLine($"\tPlayer: {player.Name}" + $" Health: {player.CurrentHealth}/{player.MaxHealth}");
        Console.WriteLine("1. Attack");
        Console.WriteLine("2. Use Item");
        Console.WriteLine("3. Try to Run");
        
        string choice = Console.ReadLine();
        
        switch (choice)
        {
            case "1":
                Attack(player, enemy);
                break;
            case "2":
                UseItem(player);
                break;
            case "3":
                if (TryToRun(player, enemy))
                {
                    Console.WriteLine("You escaped successfully!");
                    enemy.TakeDamage(enemy.Health); // End combat
                }
                break;
            default:
                Console.WriteLine("Invalid choice! You hesitate...");
                break;
        }
    }

    public static void Attack(IAttacker attacker, IDefender defender)
    {
        int roll = rng.Next(1, 21);
        int damage = rng.Next(1, attacker.Strength + 1);

        if (roll >= defender.AC)
        {
            Console.WriteLine($"{attacker.Name} hits {defender.Name} for {damage} damage!");
            defender.TakeDamage(damage);
        }
        else
        {
            Console.WriteLine($"{attacker.Name} missed!");
        }
    }

    public static void EnemyTurn(Player player, Enemy enemy)
    {
        Console.WriteLine($"\n{enemy.Name}'s turn:");
        Attack(enemy, player);
    }

    private static bool TryToRun(Player player, Enemy enemy)
    {
        int chance = 40 + player.Dexterity - 5;
        return rng.Next(100) < Math.Clamp(chance, 20, 80);
    }

    private static void UseItem(Player player)
    {
        player.Inventory.DisplayInventory();
        Console.WriteLine("Enter item number to use (0 to cancel):");
        
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0)
        {
            Item item = player.Inventory.GetItem(choice - 1);
            if (item != null)
            {
                // havent implemented this Lol
            }
        }
    }

    private static void HandleCombatEnd(Player player, Enemy enemy)
    {
        if (!enemy.IsAlive())
        {
            Console.WriteLine($"\nYou defeated the {enemy.Name}!");
            player.GoldBalance += enemy.GoldReward;
            player.AddXP(enemy.XPReward);
        }
        else if (!player.IsAlive())
        {
            Console.WriteLine("\nYou were defeated...");
        }
    }
}