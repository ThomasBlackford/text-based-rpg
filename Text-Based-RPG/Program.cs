using System;

namespace Text_Based_RPG;
using Text_Based_RPG;

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
            Console.WriteLine("1. Visit Town");
            Console.WriteLine("2. Exit Game");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    GameWorld.VisitTown(player);
                    break;
                case "2":
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
