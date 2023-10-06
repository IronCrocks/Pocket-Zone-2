using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private void Awake()
    {
        LoadData();
    }

    public void SaveData()
    {
        var data = new Dictionary<string, object>
        {
            { "Player", Managers.PlayerManager.GetData() },
            { "Inventory",Managers.InventoryManager.GetData()}

        };

        string path = GetPath();

        WriteData(path, data);
    }

    public void LoadData()
    {
        string path = GetPath();

        if (!File.Exists(path))
        {
            return;
        }

        var data = ReadData(path);

        if (data == null)
        {
            return;
        }

        Managers.PlayerManager.LoadData(data["Player"]);
        Managers.InventoryManager.LoadData(data["Inventory"]);
    }

    private string GetPath() => Path.Combine(Application.persistentDataPath, "game.data");

    private void WriteData(string path, Dictionary<string, object> data)
    {
        var formatter = new BinaryFormatter();
        using FileStream stream = File.Create(path);
        formatter.Serialize(stream, data);
    }

    private Dictionary<string, object> ReadData(string path)
    {
        var formatter = new BinaryFormatter();
        using FileStream stream = File.OpenRead(path);
        var data = formatter.Deserialize(stream) as Dictionary<string, object>;

        return data;
    }
}
