using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class OptionInfo
{
    /// <summary>
    /// ID
    /// </summary>
    public int key;

    /// <summary>
    /// 이름
    /// </summary>
    public string Name;

    /// <summary>
    /// 설명
    /// </summary>
    public string Description;

    /// <summary>
    /// 최소값
    /// </summary>
    public int MinValue;

    /// <summary>
    /// 최대값
    /// </summary>
    public int MaxValue;

}
public class OptionInfoLoader
{
    public List<OptionInfo> ItemsList { get; private set; }
    public Dictionary<int, OptionInfo> ItemsDict { get; private set; }

    public OptionInfoLoader(string path = "JSON/OptionInfo")
    {
        string jsonData;
        jsonData = Resources.Load<TextAsset>(path).text;
        ItemsList = JsonUtility.FromJson<Wrapper>(jsonData).Items;
        ItemsDict = new Dictionary<int, OptionInfo>();
        foreach (var item in ItemsList)
        {
            ItemsDict.Add(item.key, item);
        }
    }

    [Serializable]
    private class Wrapper
    {
        public List<OptionInfo> Items;
    }

    public OptionInfo GetByKey(int key)
    {
        if (ItemsDict.ContainsKey(key))
        {
            return ItemsDict[key];
        }
        return null;
    }
    public OptionInfo GetByIndex(int index)
    {
        if (index >= 0 && index < ItemsList.Count)
        {
            return ItemsList[index];
        }
        return null;
    }
}
