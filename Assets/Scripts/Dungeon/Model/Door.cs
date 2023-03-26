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
    public List<Room> rooms = new List<Room>();

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
    Key,
    Strength,
    Magic,
    Lockpicking
} 