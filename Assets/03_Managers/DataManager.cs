using System.IO;
using UnityEngine;

public class DataManager
{
    public ItemInfoLoader itemInfoLoader;
    public OptionInfoLoader optionInfoLoader;
    public SaveData cachedLoadData;
    public bool isNewGame = false;

    private string SavePath => Application.persistentDataPath + "/SaveData.json";

    public DataManager()
    {
        itemInfoLoader = new ItemInfoLoader();
        optionInfoLoader = new OptionInfoLoader();
    }

    // SAVE
    public void SaveAll(PlayerStatus status, Inventory inventory, EquipmentManager eq)
    {
        SaveData data = new SaveData()
        {
            status = status.ToData(),
            inventory = inventory.ToDataList(),
            equipment = eq.ToData()
        };

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(SavePath, json);

        Debug.Log("게임 저장 완료: " + SavePath);
    }

    // LOAD
    public SaveData LoadAll()
    {
        if (!File.Exists(SavePath))
            return null;

        string json = File.ReadAllText(SavePath);
        return JsonUtility.FromJson<SaveData>(json);
    }

    // DELETE
    public void ClearSave()
    {
        if (File.Exists(SavePath))
            File.Delete(SavePath);
    }
}



