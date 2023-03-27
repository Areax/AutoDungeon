using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ActionEffect
{
    public List<Stats> effectStats;
    public int timeBetweenEffects;
    public int numberOfApplications;

    public ActionEffect Clone()
    {
        List<Stats> newEffectStats = new();
        foreach(Stats stats in effectStats)
        {
            Stats newStats = new Stats();
            newStats.currentCharisma = stats.currentCharisma;
            newStats.maxCharisma = stats.maxCharisma;
            newStats.currentDexterity = stats.currentDexterity;
            newStats.maxDexterity = stats.maxDexterity;
            newStats.currentHitPoints = stats.currentHitPoints;
            newStats.maxHitPoints = stats.maxHitPoints;
            newStats.currentSpeed = stats.currentSpeed;
            newStats.maxSpeed = stats.maxSpeed;
            newStats.currentStrength = stats.currentStrength;
            newStats.maxStrength = stats.maxStrength;
            newStats.currentWisdom = stats.currentWisdom;
            newStats.maxWisdon = stats.maxWisdon;
            newStats.currentIntelligence = stats.currentIntelligence;
            newStats.maxIntelligence = stats.maxIntelligence;
            newEffectStats.Add(stats);
        }
        ActionEffect actionEffect = new();
        actionEffect.effectStats = newEffectStats;
        actionEffect.timeBetweenEffects = timeBetweenEffects;
        actionEffect.numberOfApplications = numberOfApplications;
        return actionEffect;
    }
}
