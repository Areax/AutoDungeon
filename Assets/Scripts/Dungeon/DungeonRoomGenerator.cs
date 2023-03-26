using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DungeonRoomGenerator : MonoBehaviour
{

    [SerializeField]
    public List<MonsterRoom> rooms = new List<MonsterRoom>();
    
    public Room generateRoom(int level, DoorLockType lockType)
    {
        RoomImport ri = ResourceDao.ImportJson<RoomImport>("rooms/testroom");
        
        // type
        MonsterRoom room = new MonsterRoom();
        
        // level
        // random needs to be designed
        var lvl = level + Random.Range(1, 5) - 2;
        lvl = lvl < 1 ? 1 : lvl;
        room.level = lvl;
        room.doors = new List<Door>();
        
        // doors
        // read list of possible doors and add them to room 
        for (int i = 0; i < Random.Range(1, 4); i++)
        {
            var door = new Door();
            room.doors.Add(door);
        }

        // monsters
        // if MonsterRoom read list of possible monsters and add them to room 
        if (room.GetType() == typeof(MonsterRoom))
        {
            for (int i = 0; i < Random.Range(1, 4); i++)
            {
                var enemy = new Enemy
                {
                    type = "skeleton",
                    level = Random.Range(1, 4),
                    attack = 1,
                    defense = 1, 
                };
                room.enemies.Add(enemy);
            }
        }
        
        // treasure
        // read list of possible treasures and add them to room 
        for (int i = 0; i < Random.Range(1, 4); i++)
        {
            var item = new Item()
            {
                name = "key",
            };
            room.rewards.Add(item);
        }

        return room;
    }
}
