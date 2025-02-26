

class Player
{
    public string Name { get; private set; }
    public int MaxHealth { get; private set; }
    public int GoldBalance { get; private set; }
    public int CurrentHealth { get; private set; }
    public int AC { get; private set; }

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
        Console.WriteLine("Please enter your name: ");
        String playerName = Console.ReadLine();
        Console.WriteLine("Your name is " + playerName + "?");
        Console.WriteLine("Y/N");
        String choice = Console.ReadLine();
        if (choice == "N")
        {
            
        }
    }
    
}