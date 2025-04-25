using System;
using Text_Based_RPG;
/*
 * made by thomas, just simple driver code.
 */
class Program

{
    static void Main()
    {
        Player player = new Player();
        player.CreatePlayer();
        
        Console.WriteLine($"{player.Name}, here are your stats!");
        player.DisplayStats();

        bool playing = true;
        while (playing)
        {
            Console.WriteLine("\nWhere would you like to go?");
            Console.WriteLine("1. Riverdale Town");
            Console.WriteLine("2. Mountainview Town");
            Console.WriteLine("3. Dark Forest");
            Console.WriteLine("4. Bandit Cave");
            Console.WriteLine("5. Exit Game");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    GameWorld.VisitTown(player, "Riverdale");
                    break;
                case "2":
                    GameWorld.VisitTown(player, "Mountainview");
                    break;
                case "3":
                    GameWorld.ExploreForest(player);
                    break;
                case "4":
                    var caveEnemies = new List<Enemy>
                    {
                        new Enemy("Bandit", 25, 8, 12, 15, 30),
                        new Enemy("Bandit Leader", 40, 12, 15, 50, 75)
                    };
                    var cave = new Cave(15, 15, caveEnemies);
                    
                    cave.Enter(player);
                    break;
                case "5":
                    playing = false;
                    Console.WriteLine("Thanks for playing!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}