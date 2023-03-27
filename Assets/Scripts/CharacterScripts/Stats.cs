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
    public int maxWisdom;
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
        output += "currentSpeed: " + currentSpeed.ToString();
        output += "\nmaxSpeed: " + maxSpeed.ToString();
        output += "\ncurrentDexterity: " + currentDexterity.ToString();
        output += "\nmaxDexterity: " + maxDexterity.ToString();
        output += "\ncurrentWisdom: " + currentWisdom.ToString();
        output += "\nmaxWisdom: " + maxWisdom.ToString();
        output += "\ncurrentIntelligence " + maxIntelligence.ToString();
        output += "\nmaxIntelligence: " + maxIntelligence.ToString();
        output += "\ncurrentCharisma " + currentCharisma.ToString();
        output += "\nmaxCharisma: " + maxCharisma.ToString();
        return output;
    }
}