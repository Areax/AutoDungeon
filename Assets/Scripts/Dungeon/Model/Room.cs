using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public class Room
{
    [SerializeField]
    public int level;

    [SerializeField]
    public List<Door> doors = new List<Door>();
}