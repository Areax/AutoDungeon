using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class ResourceDao : MonoBehaviour
{
    public void load()
    {
        MonsterRoom mr = loadMonsterRoom("mr.json");
    }

    public MonsterRoom loadMonsterRoom(string name)
    {
        return LoadFile<MonsterRoom>(name);
    }

    public void saveMonsterRoom(string qualifyingPath, MonsterRoom monsterRoom)
    {
        Debug.Log("saving");
        SaveFile(qualifyingPath + ".json", monsterRoom);
    }

    public static void SaveFile<T>(string fileName, T resource)
    {
        string destination = Application.persistentDataPath + "/" + fileName;

        if (File.Exists(destination)) File.Delete(destination);

        StreamWriter writer = new StreamWriter(destination, true);
        writer.Write(JsonUtility.ToJson(resource));
        writer.Close();

    }

    public static T LoadFile<T>(string fileName)
    {
        string destination = Application.persistentDataPath + "/" + fileName;
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not found at folder path: " + destination);
            return default(T);
        }
        string jsonString = File.ReadAllText(destination);
        Debug.Log(jsonString);
        file.Close();

        return JsonUtility.FromJson<T>(jsonString);
    }
}