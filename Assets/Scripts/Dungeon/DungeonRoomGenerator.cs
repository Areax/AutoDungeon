using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DungeonRoomGenerator : MonoBehaviour
{

    [SerializeField]
    public List<Room> rooms = new List<Room>();

    void Start()
    {
        rooms = new List<Room>();
        for (int i = 0; i < 5; i++)
        {
            Room room = generateRoom(1);
            Debug.Log(JsonUtility.ToJson(room));
            rooms.Add(room);
        }
    }

    public Room generateRoom(int level)
    {
        // type
        Room room = new MonsterRoom();
        
        // level
        // random needs to be designed
        var lvl = level + Random.Range(1, 5) - 2;
        lvl = lvl < 1 ? 1 : lvl;
        room.level = lvl;
        
        
        // doors
        // random needs to be designed
        for (int i = 0; i < Random.Range(1, 4); i++)
        {
            var door = new Door();
            door.rooms.Add(room);
            room.doors.Add(door);
        }

        return room;
    }


}
