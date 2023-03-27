using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public class Room
{
    [SerializeField]
    public string name;
    
    [SerializeField]
    public RoomAlignment alignment;
    
    [SerializeField]
    public int level;

    [SerializeField]
    public List<Door> doors = new List<Door>();
}

public enum RoomAlignment
{
    Generic, 
    Acrobatics,
    AnimalHandling,
    Arcana,
    Athletics,
    Deception,
    History,
    Insight,
    Intimidation,
    Investigation,
    Medicine,
    Nature,
    Perception,
    Performance,
    Persuasion,
    Religion,
    SleightOfHand,
    Stealth,
    Survival,
}