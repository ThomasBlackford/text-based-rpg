namespace Text_Based_RPG;
using Text_Based_RPG;
public class Perk
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Enums.PerkType Type { get; set; }
    public int Value { get; set; }

    public Perk(string name, string description, Enums.PerkType type, int value)
    {
        Name = name;
        Description = description;
        Type = type;
        Value = value;
    }
}