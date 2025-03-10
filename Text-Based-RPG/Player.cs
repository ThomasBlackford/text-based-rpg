using System;
class Player
{
    public string Name { get; private set; }
    public int MaxHealth { get; private set; }
    public int GoldBalance { get; set; }
    public int CurrentHealth { get; private set; }
    public int AC { get; private set; }
    public int Strength { get; private set; }
    public int Level { get; private set; }
    
    public void AddGold(int amount)
    {
        GoldBalance += amount;
    }

    public bool SpendGold(int amount)
    {
        if (GoldBalance >= amount)
        {
            GoldBalance -= amount;
            return true;
        }
        return false;
    }

    public void takeDamage(int damage, string type)
    {
        //get players armor resistances and compare to damage type (fire,slash,pierce,etc)
        //resistPercent variable placeholder from above
        
        //get players current buffs/debuffs as well and apply in variable
        //need to come up with equation, 

        int resistPercent = 0;

        int totalDamage = damage - ((AC + resistPercent) * 10); 
        
        CurrentHealth -= totalDamage;
        
    }

    /*
     * Class system, maybe the 9 dnd classes? Not sure how I will handle it
     * Races with bonuses?
     */
    
    public void createPlayer()
    {
        int GoldBalance = 0;
        Console.WriteLine("Welcome to the character creator!");
        
        bool nameConfirmed = false;
        while (!nameConfirmed)
        {
            Console.WriteLine("Please enter your name: ");
            String playerName = Console.ReadLine();
            Console.WriteLine("Your name is " + playerName + "?");
            Console.WriteLine("Y/N");
            String choice = Console.ReadLine().ToUpper();
            if (choice == "Y")
            {
                this.Name = playerName;
                nameConfirmed = true;
            }
            else if (choice == "N")
            {
                Console.WriteLine("Let's try again.");
            }
        }

        // Initialize Strength and Level
        this.Strength = 10; // Default strength value
        this.Level = 1; // Default level value
    }
    
}