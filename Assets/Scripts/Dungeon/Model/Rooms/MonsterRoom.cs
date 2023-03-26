using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public class MonsterRoom : Room
{
    [SerializeField]
    public List<Enemy> enemies = new List<Enemy>();

    [SerializeField]
    public List<Item> rewards = new List<Item>();
    
}
