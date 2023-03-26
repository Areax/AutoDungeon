using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Stats
{
    public int maxHitPoints;
    public int currentHitPoints;
    public int maxSpeed;
    public int currentSpeed;
    public int maxDexterity;
    public int currentDexterity;
    public int maxStrength;
    public int currentStrength;
    public int maxWisdon;
    public int currentWisdom;
    public int maxIntelligence;
    public int currentIntelligence;
    public int maxCharisma;
    public int currentCharisma;

    public override string ToString()
    {
        string output = "";
        output += "currentHitPoints: " + currentHitPoints.ToString();
        output += "\nmaxHitPoints: " + maxHitPoints.ToString();
        // TODO other stats
        return output;
    }
}