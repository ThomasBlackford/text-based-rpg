using System.Runtime.InteropServices;

namespace Text_Based_RPG;
using System.Collections.Generic;
using Text_Based_RPG;

public class InventoryHandler
{
    private List<Item> inventory;

    public void DisplayInventory()
    {
        for (int i = 0; i < this.inventory.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {this.inventory[i]}");
        }
    }

    public void AddItem(Item item)
    {
        this.inventory.Add(item);
    }

    public void removeItem(Item item)
    {
        this.inventory.Remove(item);
    }

    public void equipItem(Item item, Player player)
    {
        if (item.Equipped == false)
        {
            Console.WriteLine("Equipping your " + item.Name);
            if (item.Type == ItemType.ChestArmor)
            {
                player.bodySlot = item;
            }
        }
    }
}