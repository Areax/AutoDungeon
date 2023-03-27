using System;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainScreen : MonoBehaviour
{
    public GameObject doorPrefab;

    GameObject interactableMainUi;
    DungeonRoomGenerator dungeonRoomGenerator;
    Room currentRoom;

    private void Start()
    {
        interactableMainUi = GameObject.FindGameObjectWithTag("InteractableMainUI");
        dungeonRoomGenerator = new DungeonRoomGenerator();
    }

    public void GenerateStartingRoom()
    {
        Room room = new Room();
        currentRoom = room;
        int randInt = UnityEngine.Random.Range(1, 5);
        
        for (int i = 0; i < randInt; i++)
        {
            Door door = new Door();
            door.name = "Dungeon Entrance #" + i;
            door.status = DoorStatus.Open;
            room.doors.Add(door);
        }

        GenerateDoorTags(room);
        HideHighLevelButtons();
    }

    private void HideHighLevelButtons()
    {
        GameObject buttonLayer = GameObject.FindGameObjectWithTag("ButtonLayer");
        buttonLayer.SetActive(false);
    }

    public void GenerateDoorTags(Room room)
    {
        Rect halfSize = interactableMainUi.GetComponent<RectTransform>().rect;
        for (int i = 0; i < room.doors.Count; i++)
        {
            float xPosition = halfSize.x * 2 / (room.doors.Count + 1) * (i + 1) - halfSize.x;
            Vector3 tagPosition = new Vector3(xPosition, 0, 0);
            float tagHeight = interactableMainUi.transform.GetComponent<RectTransform>().rect.height * 0.8f;
            GenerateDoorTag(tagPosition, tagHeight, room.doors[i]);
        }
    }

    private Button GenerateDoorTag(Vector3 tagPosition, float tagHeight, Door door)
    {
        GameObject gameObject = Instantiate(doorPrefab, interactableMainUi.transform);
        gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, tagHeight);
        gameObject.transform.localPosition = tagPosition;
        var button = gameObject.GetComponentInChildren<Button>();
        button.onClick.AddListener(() => OnEnterRoom());
        TextMeshProUGUI dungeonName = gameObject.GetComponentsInChildren<Transform>().First(t => t.gameObject.name == "Name").gameObject.GetComponent<TextMeshProUGUI>();
        dungeonName.text = door.name;
        TextMeshProUGUI dungeonDescription = gameObject.GetComponentsInChildren<Transform>().First(t => t.gameObject.name == "Description").gameObject.GetComponent<TextMeshProUGUI>();
        dungeonDescription.text = "Level: 1\nType: " + door.locktype;

        return button;
    }

    public void OnEnterRoom()
    {
        TextMeshProUGUI dungeonDescription = interactableMainUi.transform.parent.GetComponentsInChildren<Transform>().First(t => t.gameObject.name == "Description").gameObject.GetComponent<TextMeshProUGUI>();
        string[] split = dungeonDescription.text.Split("\n");
        int level = Int32.Parse(Regex.Match(split[0], @"\d+").Value);
        string type = split[1].Substring(split[1].IndexOf(':') + 1).Trim();
        DoorLockType doorLockType = Enum.Parse<DoorLockType>(type);

        currentRoom = dungeonRoomGenerator.generateRoom(level, doorLockType);
        

        foreach(Transform ch in interactableMainUi.transform)
        {
            Destroy(ch.gameObject);
        }
    }
}