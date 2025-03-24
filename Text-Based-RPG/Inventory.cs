namespace Text_Based_RPG;
using Text_Based_RPG;
public class Inventory
{
    public List<Item> Items { get; private set; } = new List<Item>();

    public void AddItem(Item item) => Items.Add(item);
    public void RemoveItem(Item item) => Items.Remove(item);

    public void DisplayInventory()
    {
        Console.WriteLine("\nInventory:");
        for (int i = 0; i < Items.Count; i++)
            Console.WriteLine($"{i + 1}. {Items[i].Name} - {Items[i].Description}");
    }

    public Item GetItem(int index) => (index >= 0 && index < Items.Count) ? Items[index] : null;
}