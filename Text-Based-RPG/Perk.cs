
//this handles perks and stuff
namespace Text_Based_RPG;
using Text_Based_RPG;

public class Perk
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Enums.PerkType Type { get; set; }
    public int Value { get; set; }
    public int Level { get; set; } 

    public Perk(string name, string description, Enums.PerkType type, int value, int level = 1)
    {
        Name = name;
        Description = description;
        Type = type;
        Value = value;
        Level = level;
    }

    public void Apply(Player player)
    {
        switch (Type)
        {
            case Enums.PerkType.HealthBoost:
                player.MaxHealth += Value * Level;
                break;
            case Enums.PerkType.DamageBoost:
                player.Strength += Value * Level;
                break;
            case Enums.PerkType.CritBoost:
                player.CritChance += Value * Level;
                break;
            case Enums.PerkType.DodgeBoost:
                player.DodgeChance += Value * Level;
                break;
            default:
                break;
        }
        Console.WriteLine($"{Name} applied! {Description}");
    }
    
}
