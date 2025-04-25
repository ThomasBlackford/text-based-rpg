
using Text_Based_RPG;

class Game
{
    private bool isRunning = true;
    private Player player;

    public Game()
    {
        this.player = player;
    }

    public void Run(Player player)
    {
        Console.WriteLine("Welcome to the Text RPG!");
        while (isRunning)
        {
            Console.WriteLine("\nWASD to move, Q to quit, M for menu");
            var key = Console.ReadKey(true).Key;
            
            switch (key)
            {
                case ConsoleKey.Q:
                    isRunning = false;
                    break;
                case ConsoleKey.M:
                    ShowGameMenu();
                    break;
                default:
                    break;
            }
        }
    }

    private void ShowGameMenu()
    {
        Console.WriteLine("\nGame Menu:");
        Console.WriteLine("1. View Stats");
        Console.WriteLine("2. View Inventory");
        Console.WriteLine("3. Return to Game");
        
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                player.DisplayStats();
                break;
            case "2":
                player.Inventory.DisplayInventory();
                break;
        }
    }
}