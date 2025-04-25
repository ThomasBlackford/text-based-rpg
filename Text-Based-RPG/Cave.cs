using System;
using System.Collections.Generic;
using Text_Based_RPG;

public class Cave
{
    public int X { get; set; }
    public int Y { get; set; }
    public List<Enemy> Enemies { get; set; }
    public bool Cleared { get; set; } = false;

    public Cave(int x, int y, List<Enemy> enemies)
    {
        X = x;
        Y = y;
        Enemies = new List<Enemy>(enemies); 
    }

    public void Enter(Player player)
    {
        bool inCave = true;
        while (inCave && player.IsAlive())
        {
            Console.Clear();
            Console.WriteLine("You are in the dark cave...");
            
            if (Enemies.Count > 0 && !Cleared)
            {
                Console.WriteLine("Bandits attack!");
                
                // fight enemies in order
                for (int i = Enemies.Count - 1; i >= 0; i--)
                {
                    Enemy currentEnemy = Enemies[i];
                    CombatSystem.StartCombat(player, currentEnemy);
                    
                    if (!player.IsAlive()) 
                        return;
                        
                    Enemies.RemoveAt(i); //remofve enemy
                    
                    // Small pause between enemies
                    if (Enemies.Count > 0)
                    {
                        Console.WriteLine("\nAnother enemy approaches!");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                }
                
                Cleared = true;
                Console.WriteLine("\nYou've cleared the cave of bandits!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("The cave is quiet and empty.");
            }

            Console.WriteLine("\n1. Explore deeper");
            Console.WriteLine("2. Leave cave");
            
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    if (Cleared)
                    {
                        Console.WriteLine("You find nothing but cobwebs...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("You stumble in the dark but find nothing.");
                        Console.ReadKey();
                    }
                    break;
                case "2":
                    inCave = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}