using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class Item
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
    /// 공격력
    /// </summary>
    public int value;

    /// <summary>
    /// 설명
    /// </summary>
    public string Description;

}
public class ItemLoader
{
    public List<Item> ItemsList { get; private set; }
    public Dictionary<int, Item> ItemsDict { get; private set; }

    public ItemLoader(string path = "JSON/Item")
    {
        string jsonData;
        jsonData = Resources.Load<TextAsset>(path).text;
        ItemsList = JsonUtility.FromJson<Wrapper>(jsonData).Items;
        ItemsDict = new Dictionary<int, Item>();
        foreach (var item in ItemsList)
        {
            ItemsDict.Add(item.key, item);
        }
    }

    [Serializable]
    private class Wrapper
    {
        public List<Item> Items;
    }

    public Item GetByKey(int key)
    {
        if (ItemsDict.ContainsKey(key))
        {
            return ItemsDict[key];
        }
        return null;
    }
    public Item GetByIndex(int index)
    {
        if (index >= 0 && index < ItemsList.Count)
        {
            return ItemsList[index];
        }
        return null;
    }
}
