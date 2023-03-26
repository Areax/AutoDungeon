using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Door
{
    [SerializeField]
    public string doorName { get; set; }

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
    Strength,
    Nature,
    Magic,
    Lockpicking
} 