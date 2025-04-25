using Text_Based_RPG;
namespace Text_Based_RPG;

public interface ICombatant
{
    string Name { get; }
    int Health { get; }
    bool IsAlive();
    void TakeDamage(int amount);
}