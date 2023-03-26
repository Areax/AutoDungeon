using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonCreator : MonoBehaviour
{
    [SerializeField]
    private DungeonRoomGenerator roomGenerator; 
    
    [SerializeField]
    private List<MonsterRoom> dungeon; 
    
    void Start()
    {
        //for (int i = 0; i < 5; i++)
        //{
            dungeon = generateDungeon(1);
            //Debug.Log(JsonUtility.ToJson(dungeon));
        //}
    }

    // Update is called once per frame
    List<MonsterRoom> generateDungeon(int level)
    {
        var dungeonRun = new List<MonsterRoom>();
        
        //generate first room 
        dungeonRun.Add(roomGenerator.generateRoom(level, DoorLockType.None) as MonsterRoom);
        Debug.Log("Room0: "+ JsonUtility.ToJson(dungeonRun[0]));
        
        for (int i = 1; i < 5; i++)
        {
            //openRandom door 
            var lastRoom = dungeonRun[^1];
            var lastDoor = lastRoom.doors[Random.Range(0, lastRoom.doors.Count)];
            Debug.Log($"door{i}: {JsonUtility.ToJson(lastDoor)}");
            
            Room room = roomGenerator.generateRoom(level, lastDoor.locktype);
            Debug.Log($"room{i}: {JsonUtility.ToJson(room)}");
            dungeonRun.Add(room as MonsterRoom);
        }
        
        return dungeonRun;
    }
}
