using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class MonsterRoom : Room
{
    public List<Enemy> enemies;

    public List<Item> rewards;
}
