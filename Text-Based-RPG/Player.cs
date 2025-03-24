using System;
using System.Collections.Generic;
namespace Text_Based_RPG;
using Text_Based_RPG;
public class Player
{
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
    public int XP { get; private set; }
    public int DodgeChance { get; private set; }
    public int CritChance { get; private set; }
    public double CritMultiplier { get; private set; }
    public Inventory Inventory { get; private set; } = new Inventory();
    public List<Perk> Perks { get; private set; } = new List<Perk>();

    public void TakeDamage(int damage) => CurrentHealth -= Math.Max(0, damage - AC);

    public void Heal(int amount) => CurrentHealth = Math.Min(MaxHealth, CurrentHealth + amount);

    public void AddXP(int amount)
    {
        XP += amount;
        if (XP >= Level * 100)
        {
            Level++;
            XP = 0;
            Console.WriteLine($"Level up! You are now level {Level}.");
        }
    }

    public void AddPerk(Perk perk) => Perks.Add(perk);

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