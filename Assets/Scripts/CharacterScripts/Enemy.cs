using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, Character
{
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
}
