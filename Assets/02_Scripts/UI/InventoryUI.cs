using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject slotPrefab;
    public Transform slotRoot;
    public int slotCount = 16;

    private Inventory inventory;
    private List<InventorySlotUI> slotUIs = new List<InventorySlotUI>();

    public void Init(Inventory inventory)
    {
        this.inventory = inventory;

        // 이미 슬롯이 생성되었다면 리프레시만
        if (slotUIs.Count == 0)
            CreateSlots();

        Refresh();
    }

    void CreateSlots()
    {
        for (int i = 0; i < slotCount; i++)
        {
            var obj = Instantiate(slotPrefab, slotRoot);
            var slot = obj.GetComponent<InventorySlotUI>();
            slot.Init(i, ClickSlot);
            slotUIs.Add(slot);
        }
    }

    void Refresh()
    {
        foreach (var slot in slotUIs)
            slot.Refresh(inventory);
    }

    void ClickSlot(int slotIndex)
    {
        var item = inventory.GetItemBySlot(slotIndex);
        if (item != null)
            GameManager.Instance.uiManager.ShowItemPopup(item);
    }
}


