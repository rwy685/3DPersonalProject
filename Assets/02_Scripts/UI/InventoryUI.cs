using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject slotPrefab;
    public Transform slotRoot;
    private int slotCount = 30;

    private Inventory inventory;
    private List<InventorySlotUI> slotUIs = new List<InventorySlotUI>();

    public DesignEnums.ItemType? currentTypeFilter = null;
    public DesignEnums.ItemRarity? currentRarityFilter = null;

    public bool isInitialized = false;

    public void Init(Inventory inventory)
    {
        this.inventory = inventory;

        if (!isInitialized)
        {
            CreateSlots();
            isInitialized = true;

            // 장비 변경 이벤트 구독
            var player = GameManager.Instance.characterManager.player;
            player.equipmentManager.OnEquipmentChanged += RefreshEquipMarks;
        }

        Refresh();
        StartCoroutine(ScrollToTopNextFrame());
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

    public void Refresh()
    {
        if (inventory == null)
            return;

        List<ItemInstance> items = inventory.items;

        // 필터 적용
        List<ItemInstance> filtered = new List<ItemInstance>();

        foreach (var item in items)
        {
            if (currentTypeFilter != null &&
                item.template.itemType != currentTypeFilter.Value)
                continue;

            if (currentRarityFilter != null &&
                item.template.itemRarity != currentRarityFilter.Value)
                continue;

            filtered.Add(item);
        }

        // 슬롯 반영
        for (int i = 0; i < slotUIs.Count; i++)
        {
            if (i < filtered.Count)
                slotUIs[i].SetItem(filtered[i]);
            else
                slotUIs[i].SetItem(null);
        }
    }


    // 장비 변경 시 (E) 표시만 갱신
    public void RefreshEquipMarks()
    {
        foreach (var slot in slotUIs)
            slot.RefreshEquipState();
    }

    void ClickSlot(ItemInstance item)
    {
        if (item != null)
            GameManager.Instance.uiManager.ShowItemPopup(item);
    }

    IEnumerator ScrollToTopNextFrame()
    {
        yield return null;
        Canvas.ForceUpdateCanvases();

        var scroll = GetComponentInChildren<ScrollRect>();
        if (scroll != null)
        {
            scroll.verticalNormalizedPosition = 1f;
        }
    }
}




