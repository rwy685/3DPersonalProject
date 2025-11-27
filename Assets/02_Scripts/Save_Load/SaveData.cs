using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    public PlayerStatusData status;
    public List<ItemInstanceData> inventory;
    public EquipmentData equipment;
}

[Serializable]
public class ItemInstanceData
{
    public int itemID;
    public int count;
    public List<ItemOptionValue> options;
}

[Serializable]
public class EquipmentData
{
    public int weaponID;
    public int armorID;
}

