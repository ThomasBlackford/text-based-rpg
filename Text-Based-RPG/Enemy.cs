namespace Text_Based_RPG;
using Text_Based_RPG;
public class Enemy : IAttacker, IDefender
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Strength { get; set; }
    public int AC { get; set; }
    public int GoldReward { get; set; }
    public int XPReward { get; set; }

    int IAttacker.Strength => this.Strength;
    int IDefender.AC => this.AC;
    
    public Enemy(string name, int health, int strength, int ac, int goldReward, int xpReward)
    {
        Name = name;
        Health = health;
        Strength = strength;
        AC = ac;
        GoldReward = goldReward;
        XPReward = xpReward;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0) Health = 0;
    }

    public bool IsAlive() => Health > 0;
}