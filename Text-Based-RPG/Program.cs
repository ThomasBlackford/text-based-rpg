using System;
namespace Text_Based_RPG;
using Text_Based_RPG;
class Program
{
    static void Main()
    {
        Player player = new Player();
        player.CreatePlayer();
        
        Console.WriteLine(player.Name + " here are your stats!");
        player.DisplayStats();
    }
}