using System;
using UnityEngine;
using System.Collections.Generic;


[Serializable]
public class EventRoom : Room
{
    [SerializeField]
    public List<NPC> npcs = new List<NPC>();

    [SerializeField]
    public List<Item> rewards = new List<Item>();
}
