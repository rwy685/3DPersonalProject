using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public GameObject slotPrefab;
    public Transform slotRoot;
    [SerializeField] private int slotCount;

    private Inventory inventory;
    private List<InventorySlotUI> slotUIs = new List<InventorySlotUI>();

    public void Init(Inventory inventory)
    {
        this.inventory = inventory;

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



