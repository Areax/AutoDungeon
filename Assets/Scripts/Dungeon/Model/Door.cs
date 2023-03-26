using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Door
{
    [SerializeField]
    string doorName { get; set; }

    [SerializeField]
    DoorStatus status;

    [SerializeField]
    Room room;
}

public enum DoorStatus
{
    Locked,
    Open,
    Closed
} 
