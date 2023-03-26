using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, Character
{

    //  field for this enemies name
    public string enemyName;

    //  reference for this enemies stats struct
    public EnemyStats enemyStats;

    //  system.serializable allows this struct to be shown in the inspector
    [System.Serializable]
    public struct EnemyStats
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

    public EnemyData enemyData;
    public int GetLevel()
    {
        return enemyData.level;
    }

    public string GetName()
    {
        return enemyData.enemyName;
    }

    public Stats GetStats()
    {
        return enemyData.enemyStats;
    }


    //  for debugging enemy death--
    public void Awake()
    {
        
    }

    public void OnMouseEnter()
    {
        Debug.Log("mouse entered " + this.GetName() + " collider");
    }

    public void OnMouseExit()
    {
        Debug.Log("mouse exited " + this.GetName() + " collider");
    }
}
