using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Door
{
    [SerializeField] 
    public string name;

    [SerializeField]
    public String position;

    [SerializeField]
    public DoorStatus status;

    [SerializeField] 
    public DoorLockType locktype;

    [SerializeField] 
    public int lockCheck;
}

public enum DoorStatus
{
    Locked,
    Open,
    Closed
} 

public enum DoorLockType
{
    None,
    Key,
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