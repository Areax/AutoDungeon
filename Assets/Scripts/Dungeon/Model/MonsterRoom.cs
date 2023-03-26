using UnityEngine;
using System.Collections.Generic;

public class MonsterRoom : Room
{
    [SerializeField]
    private List<Monster> monsters;

    [SerializeField]
    private List<Reward> rewards;
}
