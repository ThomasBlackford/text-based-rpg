namespace Text_Based_RPG;
/*
 * Made by Thomas Blackford
 */
public class Item
{
    public string Name { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }

    public Item(string name, int price, string description)
    {
        Name = name;
        Price = price;
        Description = description;
    }
}