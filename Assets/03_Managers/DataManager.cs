using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager
{
    public void SavePlayerStatus(PlayerStatus status)
    {
        PlayerStatusData data = status.ToData();
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.persistentDataPath + "/player.json", json);
    }

    public PlayerStatusData LoadPlayerStatus()
    {
        string path = Application.persistentDataPath + "/player.json";

        if (!File.Exists(path))
            return null;

        string json = File.ReadAllText(path);
        return JsonUtility.FromJson<PlayerStatusData>(json);
    }
}

