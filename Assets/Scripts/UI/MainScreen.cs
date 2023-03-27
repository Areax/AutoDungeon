using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainScreen : MonoBehaviour
{
    public GameObject doorPrefab;

    void test()
    {
        Room room = new Room();
        room.doors = new List<Door>();
        Door door = new Door();
        door.name = "dabana";
        door.status = DoorStatus.Open;
        door.locktype = DoorLockType.Strength;

        Door door2 = new Door();
        door2.name = "door2!";
        door2.status = DoorStatus.Closed;
        door2.locktype = DoorLockType.Magic;
        room.doors.Add(door);
        room.doors.Add(door2);
    }

    public void GenerateDoorTags(Room room)
    {
        Rect halfSize = this.GetComponent<RectTransform>().rect;
        Debug.Log("width and height: " + halfSize.x + " " + halfSize.y);
        for (int i = 0; i < room.doors.Count; i++)
        {
            float xPosition = halfSize.x * 2 / (room.doors.Count + 1) * (i + 1) - halfSize.x;
            Vector3 tagPosition = new Vector3(xPosition, 0, 0);
            float tagHeight = this.transform.GetComponent<RectTransform>().rect.height * 0.8f;
            GenerateDoorTag(tagPosition, tagHeight, room.doors[i]);
        }
    }

    private Button GenerateDoorTag(Vector3 tagPosition, float tagHeight, Door door)
    {

        GameObject gameObject = Instantiate(doorPrefab, this.transform);
        gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, tagHeight);
        gameObject.transform.localPosition = tagPosition;
        var button = gameObject.GetComponentInChildren<Button>();
        button.onClick.AddListener(() => OnEnterRoom());
        TextMeshProUGUI dungeonName = gameObject.GetComponentsInChildren<Transform>().First(t => t.gameObject.name == "Name").gameObject.GetComponent<TextMeshProUGUI>();
        dungeonName.text = door.name;
        TextMeshProUGUI dungeonDescription = gameObject.GetComponentsInChildren<Transform>().First(t => t.gameObject.name == "Description").gameObject.GetComponent<TextMeshProUGUI>();
        dungeonDescription.text = "Level: ???\nType: " + door.locktype;

        return button;
    }

    public void OnEnterRoom()
    {
        // generateRooms()
        // disable all buttons
        Debug.Log("Ta-Da!");
    }
}