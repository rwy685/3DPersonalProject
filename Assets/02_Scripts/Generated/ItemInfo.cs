using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class ItemInfo
{
    /// <summary>
    /// ID
    /// </summary>
    public int key;

    /// <summary>
    /// 이름
    /// </summary>
    public string name;

    /// <summary>
    /// 설명
    /// </summary>
    public string Description;

    /// <summary>
    /// 타입
    /// </summary>
    public DesignEnums.ItemType itemType;

    /// <summary>
    /// 등급
    /// </summary>
    public DesignEnums.ItemRarity itemRarity;

    /// <summary>
    /// 공격력
    /// </summary>
    public int baseAttack;

    /// <summary>
    /// 방어력
    /// </summary>
    public int baseDefense;

    /// <summary>
    /// 체력
    /// </summary>
    public int baseHp;

    /// <summary>
    /// 옵션 목록
    /// </summary>
    public List<int> optionList;

    /// <summary>
    /// 아이콘 이름
    /// </summary>
    public string iconName;

}
public class ItemInfoLoader
{
    public List<ItemInfo> ItemsList { get; private set; }
    public Dictionary<int, ItemInfo> ItemsDict { get; private set; }

    public ItemInfoLoader(string path = "JSON/ItemInfo")
    {
        string jsonData;
        jsonData = Resources.Load<TextAsset>(path).text;
        ItemsList = JsonUtility.FromJson<Wrapper>(jsonData).Items;
        ItemsDict = new Dictionary<int, ItemInfo>();
        foreach (var item in ItemsList)
        {
            ItemsDict.Add(item.key, item);
        }
    }

    [Serializable]
    private class Wrapper
    {
        public List<ItemInfo> Items;
    }

    public ItemInfo GetByKey(int key)
    {
        if (ItemsDict.ContainsKey(key))
        {
            return ItemsDict[key];
        }
        return null;
    }
    public ItemInfo GetByIndex(int index)
    {
        if (index >= 0 && index < ItemsList.Count)
        {
            return ItemsList[index];
        }
        return null;
    }
}
