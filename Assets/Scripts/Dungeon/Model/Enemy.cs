using System;
using UnityEngine;

[Serializable]
public class Enemy
{
    [SerializeField]
    public string type;

    [SerializeField]
    public int level;

    [SerializeField]
    public int attack;

    [SerializeField]
    public int defense;
}