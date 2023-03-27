
using System;
using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class MonsterRoom : Room
{

    [SerializeField]
    public List<EnemyData> enemies = new List<EnemyData>();

    [SerializeField]
    public List<Item> rewards = new List<Item>();
    
}
