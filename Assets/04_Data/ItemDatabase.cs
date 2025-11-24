using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Database/ItemDatabase")]
public class ItemDatabase : ScriptableObject
{
    public List<ItemData> items;

    public ItemData GetItem(int id)
    {
        return items.Find(x => x.itemID == id);
    }
}
