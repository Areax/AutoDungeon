using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonCreator : MonoBehaviour
{
    [SerializeField]
    private DungeonRoomGenerator roomGenerator; 
    
    void Start()
    {
        //for (int i = 0; i < 5; i++)
        //{
            var dungeon = generateDungeon(1);
            //Debug.Log(JsonUtility.ToJson(dungeon));
        //}
    }

    // Update is called once per frame
    List<Room> generateDungeon(int level)
    {
        var dungeonRun = new List<Room>();
        
        //generate first room 
        dungeonRun.Add(roomGenerator.generateRoom(level, DoorLockType.None));
        Debug.Log("Room0: "+ JsonUtility.ToJson(dungeonRun[0]));
        
        for (int i = 1; i < 5; i++)
        {
            //openRandom door 
            var lastRoom = dungeonRun[^1];
            var lastDoor = lastRoom.doors[Random.Range(0, lastRoom.doors.Count)];
            Debug.Log($"door{i}: {JsonUtility.ToJson(lastDoor)}");
            
            Room room = roomGenerator.generateRoom(level, lastDoor.locktype);
            Debug.Log($"room{i}: {JsonUtility.ToJson(room)}");
            dungeonRun.Add(room);
        }
        
        return dungeonRun;
    }
}
