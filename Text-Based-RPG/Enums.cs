public static class Enums
{
    // Enum for Character Classes (added notes for how I think the classes should be)
    public enum CharacterClass
    {
        Warrior, //warrior class to scale on str and melee based weapons with high health and armor
        Mage, //mage class to scale on int and magic based weapons
        Rogue, //try for a more sneak or agile based class with high crit chance and dodge chance with more dex based scaling weapons (i.e daggers)
        Archer //ranged class with high dex scaling and accuracy with bows and crossbows
    }

    // Enum for Character Races, will add racial bonuses/passives later, still thinking of ideas
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
}