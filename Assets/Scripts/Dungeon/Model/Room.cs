using UnityEngine;
using System.Collections.Generic;

public class Room
{
    [SerializeField]
    private int level;

    [SerializeField]
    private List<Door> doors;
}