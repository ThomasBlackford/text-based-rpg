using System;
using System.Collections.Generic;
namespace Text_Based_RPG;
using Text_Based_RPG;

/*
 * Made by thomas, good luck reading this abomination
 */
public class Player : IAttacker, IDefender
{
    public string Name { get;  set; }
    public string Class { get;  set; }
    public int MaxHealth { get;  set; }
    public int GoldBalance { get; set; }
    public int CurrentHealth { get;  set; }
    public int Value { get; set; }
    public int AC { get;  set; }
    public int Strength { get;  set; }
    public int Intelligence { get;  set; }
    public int Dexterity { get;  set; }
    public int Constitution { get;  set; }
    public int Level { get;  set; }
    public int XP { get;  set; }
    public int DodgeChance { get; set; }
    public int CritChance { get; set; }
    public double CritMultiplier { get; set; }
    
    int IAttacker.Strength => this.Strength;
    int IDefender.AC => this.AC;
    
    int ICombatant.Health => this.CurrentHealth;
    
    public Inventory Inventory { get;  set; } = new Inventory();
    public List<Perk> Perks { get; set; } = new List<Perk>();
        public int AvailablePerkPoints { get; set; } = 0;
        

        public bool IsAlive()
        {
            if (CurrentHealth <= 0) return false;
            else
            {
                return true;
            }
        }
        

    public void TakeDamage(int damage)
    {
        Random rand = new Random();
        
        if (rand.Next(100) < DodgeChance)
        {
            Console.WriteLine($"{Name} dodged the attack!");
            return;
        }
        
        int finalDamage = Math.Max(1, damage - AC);
        
        CurrentHealth -= finalDamage;

        Console.WriteLine($"{Name} took {finalDamage} damage! Current health: {CurrentHealth}/{MaxHealth}");
        
        if (CurrentHealth <= 0)
        {
            Console.WriteLine($"{Name} has died!");
            CurrentHealth = 0;
        }
    }
    



    public void Heal(int amount) => CurrentHealth = Math.Min(MaxHealth, CurrentHealth + amount);

    public void AddXP(int amount)
    {
        XP += amount;
        if (XP >= Level * 100)
        {
            Level++;
            XP = 0;
            Console.WriteLine($"Level up! You are now level {Level}.");
            Level++;
            Value *= 2;  
            Console.WriteLine($"{Name} leveled up to level {Level}! Value increased to {Value}.");
        
            Console.WriteLine("Choose a perk to level up:");
        
            Console.WriteLine("1: Health Boost (Level: " + Level + ", Value: " + Value + ")");
            Console.WriteLine("2: Damage Boost (Level: " + Level + ", Value: " + Value + ")");
            Console.WriteLine("3: Crit Boost (Level: " + Level + ", Value: " + Value + ")");
            Console.WriteLine("4: Dodge Boost (Level: " + Level + ", Value: " + Value + ")");

            int choice = 0;
            while (choice < 1 || choice > 4)
            {
                Console.Write("Enter the number of the perk you want to level up (1-4): ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out choice) && choice >= 1 && choice <= 4)
                {
                    switch (choice)
                    {
                        case 1:
                            LevelUpPerk(Enums.PerkType.HealthBoost);
                            break;
                        case 2:
                            LevelUpPerk(Enums.PerkType.DamageBoost);
                            break;
                        case 3:
                            LevelUpPerk(Enums.PerkType.CritBoost);
                            break;
                        case 4:
                            LevelUpPerk(Enums.PerkType.DodgeBoost);
                            break;
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please choose a number between 1 and 4.");
                }
            }
        }
    }
    
    private void LevelUpPerk(Enums.PerkType perkType)
    {
        // perk logic
        switch (perkType)
        {
            case Enums.PerkType.HealthBoost:
                Level++;
                Value *= 2;  //dobules value
                Console.WriteLine($"Health Boost leveled up to level {Level}! Value increased to 5.");
                break;
            case Enums.PerkType.DamageBoost:
                Level++;
                Value *= 2;
                Console.WriteLine($"Damage Boost leveled up to level {Level}! Value increased to 2.");
                break;
            case Enums.PerkType.CritBoost:
                Level++;
                Value *= 2;
                Console.WriteLine($"Crit Boost leveled up to level {Level}! Value increased to 5%.");
                break;
            case Enums.PerkType.DodgeBoost:
                Level++;
                Value *= 2;
                Console.WriteLine($"Dodge Boost leveled up to level {Level}! Value increased to 3%.");
                break;
        }
    }

 

    public void DisplayStats()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Class: {Class}");
        Console.WriteLine($"Level: {Level}");
        Console.WriteLine($"Health: {CurrentHealth}/{MaxHealth}");
        Console.WriteLine($"Gold: {GoldBalance}");
        Console.WriteLine($"Perks: {string.Join(", ", Perks)}");
    }

    public void CreatePlayer()
    {
        Console.WriteLine("Welcome to the character creator!");
        Name = InputHelper.ReadString("Enter your name:");
        Class = InputHelper.ReadChoice("Choose a class:", new List<string> { "Warrior", "Mage", "Rogue", "Archer" });
        Level = 1;
        MaxHealth = 20;
        CurrentHealth = MaxHealth;
        GoldBalance = 100;
        AC = 10;
        Strength = 10;
        Intelligence = 10;
        Dexterity = 10;
        Constitution = 10;
        DodgeChance = 5;
        CritChance = 5;
        CritMultiplier = 1.5;
    }
}