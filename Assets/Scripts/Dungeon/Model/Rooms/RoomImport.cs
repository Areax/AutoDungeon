using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RoomImport
{
    [SerializeField] public string name;

    [SerializeField] public string type;

    [SerializeField] public int level;

    [SerializeField]
    public RoomAlignment alignment;

    [SerializeField] public DoorImport[] doors;

    [SerializeField]
    public EnemyImport[] enemies;

    [SerializeField]
    public ItemImport[] rewards;
}

[Serializable]
public class DoorImport
{
    [SerializeField] public string doorName;

    [SerializeField] public string doorPosition;

    [SerializeField] public string doorStatus;

    [SerializeField] public string lockType;

    [SerializeField] public int[] lockCheck;

    [SerializeField] public int doorChance;
}

[Serializable]
public class EnemyImport
{
    [SerializeField]
    public string enemyType;
    
    [SerializeField]
    public int[] enemyLevel;
    
    [SerializeField]
    public int[] enemyCount;
}

[Serializable]
public class ItemImport
{
    [SerializeField]
    public string rewardsType;
    
    [SerializeField]
    public int[] rewardsCount;
}
