using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Character
{
    public Stats GetStats();
    // This really isn't needed but I am temporarily adding this because there are multiple kinds of stats in the Enemy object and I am far too tired to deal with unifying those.
    public int GetHealth();
    public int GetLevel();
    public string GetName();
    public BasicAttack GetBasicAttack();
    public void UpdateCharacterStats(Stats stats)
    {
        Stats characterStats = GetStats();
        characterStats.currentHitPoints += stats.currentHitPoints;
        characterStats.currentCharisma += stats.currentCharisma;
        characterStats.currentStrength += stats.currentStrength;
        characterStats.currentDexterity += stats.currentDexterity;
        characterStats.currentIntelligence += stats.currentIntelligence;
        characterStats.currentSpeed += stats.currentSpeed;
        characterStats.currentWisdom += stats.currentWisdom;
    }
}
