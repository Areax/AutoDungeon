using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonCreator : MonoBehaviour
{
    [SerializeField]
    private DungeonRoomGenerator roomGenerator; 
    
    [SerializeField]
    private List<Room> dungeon; 
    
    void Start()
    {
        //for (int i = 0; i < 5; i++)
        //{
            dungeon = generateTestDungeon(1);
            //Debug.Log(JsonUtility.ToJson(dungeon));
        //}
    }

    // Update is called once per frame
    List<Room> generateTestDungeon(int level)
    {
        var dungeonRun = new List<Room>();
        
        //generate first room 
        dungeonRun.Add(roomGenerator.generateRoom(level, DoorLockType.None));
        Debug.Log($"Generated Room0: {dungeonRun[0].name}");
        
        for (int i = 1; i < 5; i++)
        {
            //openRandom door 
            var lastRoom = dungeonRun[^1];
            var lastDoor = lastRoom.doors[Random.Range(0, lastRoom.doors.Count)];
            Debug.Log($"Used door{i}: {lastDoor.name} \n {JsonUtility.ToJson(lastDoor, true)}");
            
            Room room = roomGenerator.generateRoom(level, lastDoor.locktype);
            Debug.Log($"Generated Room{i}: {room.name} \n {JsonUtility.ToJson(room, true)}");
            dungeonRun.Add(room);
        }
        
        return dungeonRun;
    }
}
