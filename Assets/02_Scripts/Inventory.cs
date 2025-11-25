using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public ItemLoader loader;
    public List<ItemInstance> items = new List<ItemInstance>();

    void Awake()
    {
        loader = new ItemLoader();
    }

   
    public void AddItem(int itemID, int count = 1)
    {
        var template = loader.GetByKey(itemID);
        if (template == null)
        {
            Debug.Log($"아이템 아이디 {itemID} 찾을 수 없음.");
            return;
        }

        var existingItem = items.Find(i => i.itemID == itemID);
        if (existingItem != null)
        {
            existingItem.count += count;
        }
        else
        {
            items.Add(new ItemInstance(template, count));
        }
    }

    public void RemoveItem(int itemID, int count = 1)
    {
        var item = items.Find(i => i.itemID == itemID);
        if (item == null) return;

        item.count -= count;
        if (item.count <= 0)
            items.Remove(item);
    }

    public ItemInstance GetItemBySlot(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= items.Count)
            return null;
        return items[slotIndex];
    }
}
