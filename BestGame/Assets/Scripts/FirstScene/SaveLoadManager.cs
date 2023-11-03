using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoadManager
{
    private readonly string _filePath;

    public SaveLoadManager()
    {
        _filePath = Application.persistentDataPath + "/Save.dat";
    }

    public void Save(PlayerData data)
    {
        using (FileStream fileStream = File.Create(_filePath))
        {
            new BinaryFormatter().Serialize(fileStream, data);
        }
    }

    public PlayerData Load()
    {
        if (!File.Exists(_filePath))
            return new PlayerData();

        PlayerData data;

        using(FileStream fileStream = File.Open(_filePath, FileMode.Open))
        {
            object loadedData = new BinaryFormatter().Deserialize(fileStream);
            data = (PlayerData)loadedData;
        }

        return data;
    }
}
