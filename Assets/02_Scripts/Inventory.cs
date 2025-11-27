using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public ItemInfoLoader loader;
    public List<ItemInstance> items = new List<ItemInstance>();

    void Awake()
    {
        loader = new ItemInfoLoader();
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
            items.Add(new ItemInstance(template, count)); // 수정 완료
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
    //===================================
    // 데이터 저장 및 불러오기 용
    //===================================
    public List<ItemInstanceData> ToDataList()
    {
        var list = new List<ItemInstanceData>();

        foreach (var item in items)
        {
            list.Add(new ItemInstanceData()
            {
                itemID = item.itemID,
                count = item.count,
                options = item.options   // 옵션 값 그대로 저장
            });
        }

        return list;
    }

    public void LoadFromData(List<ItemInstanceData> dataList)
    {
        items.Clear();

        foreach (var data in dataList)
        {
            var template = loader.GetByKey(data.itemID);
            if (template == null)
                continue;

            var instance = new ItemInstance(template, data.count);
            instance.options = data.options; // 기존 옵션 복원
            items.Add(instance);
        }
    }

}
