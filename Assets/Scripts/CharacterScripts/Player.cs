using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, Character
{
    public List<Spell> spells;
    public List<Ability> abilities;

    public Stats playerStats;
    private BasicAttack basicAttack = new BasicAttack();
    public BasicAttack GetBasicAttack()
    {
        return basicAttack;
    }


    //  reference to the enemy the player wishes to target
    public Enemy target = null;

    public int GetLevel()
    {
        throw new System.NotImplementedException();
    }

    public string GetName()
    {
        return "player";
    }

    public Stats GetStats()
    {
        return playerStats;
    }

    public int GetHealth()
    {
        return playerStats.currentHitPoints;
    }
}
