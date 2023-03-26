using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Character
{
    public Stats GetStats();
    public int GetLevel();
    public string GetName();
    public void ApplyStatsEffect(Stats effects)
    {
        Stats characterStats = GetStats();
        characterStats.currentHitPoints += effects.currentHitPoints;
        characterStats.maxHitPoints += effects.maxHitPoints;
        characterStats.currentCharisma += effects.currentCharisma;
        characterStats.maxCharisma += effects.maxCharisma;
        characterStats.currentStrength += effects.currentStrength;
        characterStats.maxStrength += effects.maxStrength;
        characterStats.currentDexterity += effects.currentDexterity;
        characterStats.maxDexterity += effects.maxDexterity;
        characterStats.currentIntelligence += effects.currentIntelligence;
        characterStats.maxIntelligence += effects.maxIntelligence;
        characterStats.currentSpeed += effects.currentSpeed;
        characterStats.maxSpeed += effects.maxSpeed;
        characterStats.currentWisdom += effects.currentWisdom;
        characterStats.maxWisdon += effects.maxWisdon;
        Debug.Log("ApplyStatsEffect after: " + characterStats);
    }
    public BasicAttack GetBasicAttack();
}
