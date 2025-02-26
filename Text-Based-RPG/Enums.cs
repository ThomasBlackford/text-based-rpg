using System;

public static class Enums
{
    // Enum for Character Classes
    public enum CharacterClass
    {
        Warrior,
        Mage,
        Rogue, //add more here if u want
        Archer
    }

    // Enum for Character Races
    public enum CharacterRace
    {
        Human,
        DarkElf,
        HighElf,
        Dragonian,
        RockDwarf,
        Orc
    }

    // Enum for Damage Types (used in combat for resistance and damage calculation)
    public enum DamageType
    {
        Slash,
        Pierce,
        Bludgeon,
        Fire,
        Ice,
        Poison
    }

    public enum ItemType
    {
        Weapon,
        Armor,
        Consumable,
        Misc,
        Quest
    }
}