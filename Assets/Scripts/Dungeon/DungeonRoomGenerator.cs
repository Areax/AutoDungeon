using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DungeonRoomGenerator : MonoBehaviour
{

    [SerializeField]
    public List<RoomImport> rooms;

    public void Awake()
    {
        var roomFiles = Resources.LoadAll<TextAsset>("rooms");
        foreach (var text in roomFiles)
        {
            rooms.Add(JsonUtility.FromJson<RoomImport>(text.text));
        }
    }

    private void Start()
    {
        rooms = new List<RoomImport>();
    }

    public Room generateRoom(int level, DoorLockType lockType)
    {
        // level
        // random needs to be designed
        // rewrite this to load in appropriate level rooms
        var lvl = level + Random.Range(1, 5) - 2;
        lvl = lvl < 1 ? 1 : lvl;
        
        // getting random room
        RoomImport import = null;
        while (import == null)
        {
            import = roomRandomizer(lvl, lockType);
        }


        // room type
        Room room = new Room();
        if (import.type == "monster")
        { 
            room = new MonsterRoom();
        }

        room.level = lvl;
        Enum.TryParse(import.roomAlignment, out room.alignment);
        room.name = import.name;
       
        room.doors = new List<Door>();
        // doors
        // read list of possible doors and add them to room 
        for (int i = 0; i < import.doors.Length; i++)
        {
            var importDoor = import.doors[i];
            var door = new Door()
            {
                name = importDoor.doorName,
                position = importDoor.doorPosition,
                lockCheck = Random.Range(importDoor.lockCheck[0], importDoor.lockCheck[1]),
            };
            Enum.TryParse(importDoor.doorStatus, out door.status);
            Enum.TryParse(importDoor.lockType, out door.locktype);
            
            // roll doorChance
            if (Random.Range(0, 100) <= importDoor.doorChance)
            {
                room.doors.Add(door);
            }
        }

        // monsters
        // if MonsterRoom read list of possible monsters and add them to room 
        if (room.GetType() == typeof(MonsterRoom))
        {
            // needs to support multiple types of enemies
            var importEnemy = import.enemies[0];
            for (int i = 0; i < Random.Range(importEnemy.enemyCount[0], importEnemy.enemyCount[1]); i++)
            {
                var enemy = ScriptableObject.CreateInstance<EnemyData>();
                enemy.enemyName = importEnemy.enemyType;
                enemy.level = Random.Range(importEnemy.enemyLevel[0], importEnemy.enemyLevel[1]);
                enemy.enemyStats = new Stats();
                (room as MonsterRoom)?.enemies.Add(enemy);
            }
        }
        
        // treasure
        // read list of possible treasures and add them to room 
        if (room.GetType() == typeof(MonsterRoom) || room.GetType() == typeof(TreasureRoom))
        {
            foreach (var reward in import.rewards)
            {
                var count = Random.Range(reward.rewardsCount[0], reward.rewardsCount[1]);
                for (int i = 0; i < count; i++)
                {
                    var item = new Item()
                    {
                        name = reward.rewardsType,
                    };
                    (room as MonsterRoom)?.rewards.Add(item);
                }
            }
            

        }

        return room;
    }

    private RoomImport roomRandomizer(int lvl, DoorLockType lockType)
    {
        var list = rooms.FindAll((r) => r.level == lvl);

        var chance = Random.Range(1, 5) < 4;
        if (lockType != DoorLockType.None && lockType != DoorLockType.Key && chance)
        {
            
            list = rooms.FindAll((r) =>
            {
                return r.roomAlignment == lockType.ToString();
            });
        }

        if (list.Count < 1)
        {
            return null;
        }
        else
        {
            return  list[Random.Range(0, list.Count)];
        }
    }
}
