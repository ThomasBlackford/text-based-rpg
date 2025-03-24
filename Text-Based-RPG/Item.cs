namespace Text_Based_RPG;
using Text_Based_RPG;
public class Item
{
    public string Name { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }
    public Enums.ItemType Type { get; set; }
    public int Value { get; set; } // Damage for weapons, defense for armor, healing for consumables

    public Item(string name, int price, string description, Enums.ItemType type, int value)
    {
        Name = name;
        Price = price;
        Description = description;
        Type = type;
        Value = value;
    }
}