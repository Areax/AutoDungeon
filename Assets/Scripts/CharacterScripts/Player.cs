using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, Character
{
    //  field for this player character name
    public string playerName;

    //  reference for this player's stats struct
    public PlayerStats stats;

    //  system.serializable allows this struct to be shown in the inspector
    [System.Serializable]
    public struct PlayerStats
    {
        //  fields for max / cur hp
        public int maxHitPoints;
        public int curHitPoints;
        [Space]

        // fields for max / cur speed
        public int maxSpeed;
        public int curSpeed;
        [Space]

        // fields for max / cur dex
        public int maxDexterity;
        public int curDexterity;
        [Space]

        // fields for max / cur strength
        public int maxStrength;
        public int curStrength;
        [Space]

        //   fields for max / cur wisdom
        public int maxWisdom;
        public int curWisdom;
        [Space]

        //  fields for max / cur intelligence
        public int maxIntelligence;
        public int curIntelligence;
        [Space]

        //  fields for the max / cur charisma
        public int maxCharisma;
        public int curCharisma;
    }

    //  field for the level of this unit
    public int level;

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
