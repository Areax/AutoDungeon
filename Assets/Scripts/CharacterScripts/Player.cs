using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, Character
{
    public List<Spell> spells;
    public List<Ability> abilities;
    public Stats playerStats;

    public int GetLevel()
    {
        throw new System.NotImplementedException();
    }

    public string GetName()
    {
        throw new System.NotImplementedException();
    }

    public Stats GetStats()
    {
        return playerStats;
    }
}
