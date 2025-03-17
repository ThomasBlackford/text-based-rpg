using System.Runtime.InteropServices.ComTypes;

namespace Text_Based_RPG;
/*
 * Made by Thomas Blackford
 */
using Text_Based_RPG;
public class Item
{
    public string Name { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }
    public int Weight { get; set; }
    public ItemType Type { get; set; }
    public bool Equipped { get; set; }
    

    public Item(string name, int price, string description, int weight, ItemType itemType, bool equipped )
    {
        Name = name;
        Price = price;
        Description = description;
        Weight = weight;
        Type = itemType;
        Equipped = equipped;
    }
}