namespace Text_Based_RPG;
using Text_Based_RPG;
public class CombatSystem
{
    private static Random rng = new Random();

    public static void Attack(Player player, Enemy enemy)
    {
        int roll = rng.Next(1, 21);
        int damage = rng.Next(1, player.Strength + 1);

        if (roll >= enemy.AC)
        {
            Console.WriteLine($"You hit the {enemy.Name} for {damage} damage!");
            enemy.TakeDamage(damage);
        }
        else
        {
            Console.WriteLine("You missed!");
        }
        player.DisplayHealth();
    }

    public static void EnemyTurn(Player player, Enemy enemy)
    {
        int roll = rng.Next(1, 21);
        int damage = rng.Next(1, enemy.Strength + 1);

        if (roll >= player.AC)
        {
            Console.WriteLine($"The {enemy.Name} hit you for {damage} damage!");
            player.TakeDamage(damage);
        }
        else
        {
            Console.WriteLine($"The {enemy.Name} missed!");
        }
    }
}