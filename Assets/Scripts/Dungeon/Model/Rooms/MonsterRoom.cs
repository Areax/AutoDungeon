
using System;
using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class MonsterRoom : Room
{

    [SerializeField]
    public List<Enemy> enemies = new List<Enemy>();

    [SerializeField]
    public List<Item> rewards = new List<Item>();
    
}
