using System;
class Player
{
    // Player properties (name, max health, gold balance, current health, armor class, strength, level) (-Lucas Manyvongsa)
    // adding more baseline stats moore in line with the 4 base classes, add more as we expand our classes later on.
    public string Name { get; private set; }
    public string Class { get; private set; }
    public int MaxHealth { get; private set; }
    public int GoldBalance { get; set; }
    public int CurrentHealth { get; private set; }
    public int AC { get; private set; }
    public int Strength { get; private set; }
    public int Intelligence { get; private set; }
    public int Dexterity { get; private set; }
    public int Constitution { get; private set; }
    public int Level { get; private set; }
    public int dodgeChance { get; private set; }
    public int critChance { get; private set; }
    public double critMultiplier { get; private set; }

    // added more stats to the player class, will need to add more as we expand our classes later on.
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
     * Class system, maybe the 9 dnd classes? Not sure how I will handle it (4 for now until we get a good foundation)
     * Races with bonuses? (yes)
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

        /* Initialize Stats and Level (a lot of numbers) don't know how character creator will work with adding points to stats (-Lucas Manyvongsa)
        * notes (idk if we will do a baseline of 10 and have a preset of stats or to let them choose which attributes to increase or decrease)  
        * for now we will just do a baseline of 10 for all stats and let them choose a class then they can specialize with increase certain stats
        */
        this.Strength = 10; // Default strength value
        this.Intelligence = 10; // Default intelligence value
        this.Dexterity = 10; // Default dexterity value
        this.Constitution = 10; // Default constitution value (thinking of separating hp and constitution, with vitality being the hp stat and constitution being the AC stat)

        //in terms of hp? 10 hp or 100 hp, what's easier to work with? probs 10, anyways more overall/general stats
        this.MaxHealth = 10; // Default max health value
        this.Level = 1; // Default level value
        this.AC = 10; // Default armor class value, once the player picks a class the AC will change.
        this.CurrentHealth = MaxHealth; // Default current health value
        this.GoldBalance = 10; // Default gold balance value, will also change depending on the class choice.

        //mostly for the rogue and archer classes.
        this.dodgeChance = 0; // Default dodge chance value, will also change depending on the class choice.
        this.critChance = 0; // Default crit chance value, will also change depending on the class choice. 
        this.critMultiplier = 1.5; // Default crit multiplier value, will also change depending on the class choice.
    
        // Class selection this is maybe subject to change, just something to establish a foundation with classes having their own stats. (-Lucas Manyvongsa)
        Console.WriteLine("Please choose a class: ");
        Console.WriteLine("1. Warrior");
        Console.WriteLine("2. Mage");
        Console.WriteLine("3. Rogue");
        Console.WriteLine("4. Archer");
        int classChoice = int.Parse(Console.ReadLine());

        switch (classChoice)
        {
            case 1:
                this.Class = "Warrior";
                this.Strength = 15;
                this.Intelligence = 5;
                this.Dexterity = 10;
                this.Constitution = 15;
                this.MaxHealth = 20;
                this.AC = 15;
                break;
            case 2:
                this.Class = "Mage";
                this.Strength = 5;
                this.Intelligence = 15;
                this.Dexterity = 10;
                this.Constitution = 10;
                this.MaxHealth = 15;
                this.AC = 10;
                break;
            case 3:
                this.Class = "Rogue";
                this.Strength = 10;
                this.Intelligence = 10;
                this.Dexterity = 15;
                this.Constitution = 10;
                this.MaxHealth = 15;
                this.AC = 12;
                this.dodgeChance = 10;
                this.critChance = 5;
                this.critMultiplier = 2.0;
                break;
            case 4:
                this.Class = "Archer";
                this.Strength = 10;
                this.Intelligence = 10;
                this.Dexterity = 15;
                this.Constitution = 10;
                this.MaxHealth = 15;
                this.AC = 12;
                this.dodgeChance = 5;
                this.critChance = 10;
                this.critMultiplier = 2.0;
                break;
            default:
                Console.WriteLine("Invalid choice, defaulting to the Depraived.");
                this.Class = "Depraived";
                this.Strength = 11;
                this.Intelligence = 11;
                this.Dexterity = 11;
                this.Constitution = 11;
                this.MaxHealth = 15;
                this.AC = 12;
                this.dodgeChance = 1;
                this.critChance = 1;
                this.critMultiplier = 1.5;
                break;
        }

        this.CurrentHealth = this.MaxHealth;
        Console.WriteLine("Character creation complete!");
    }

    public void DisplayStats() //subject to change, but something to display all the stats/info to the player. (-Lucas Manyvongsa)
    {
        Console.WriteLine("Character Stats:");
        Console.WriteLine($"Name: {this.Name}");
        Console.WriteLine($"Class: {this.Class}");
        Console.WriteLine($"Level: {this.Level}");
        Console.WriteLine($"Max Health: {this.MaxHealth}");
        Console.WriteLine($"Current Health: {this.CurrentHealth}");
        Console.WriteLine($"Armor Class: {this.AC}");
        Console.WriteLine($"Strength: {this.Strength}");
        Console.WriteLine($"Intelligence: {this.Intelligence}");
        Console.WriteLine($"Dexterity: {this.Dexterity}");
        Console.WriteLine($"Constitution: {this.Constitution}");
        Console.WriteLine($"Gold Balance: {this.GoldBalance}");
        Console.WriteLine($"Dodge Chance: {this.dodgeChance}");
        Console.WriteLine($"Crit Chance: {this.critChance}");
        Console.WriteLine($"Crit Multiplier: {this.critMultiplier}");
    }
    
}