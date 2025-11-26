using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject slotPrefab;
    public Transform slotRoot;
    public int slotCount = 30;

    private Inventory inventory;
    private List<InventorySlotUI> slotUIs = new List<InventorySlotUI>();

    public bool isInitialized = false;

    // ★ 추가된 변수들 (필터 상태)
    public DesignEnums.ItemType? currentTypeFilter = null;
    public DesignEnums.ItemRarity? currentRarityFilter = null;


    public void Init(Inventory inventory)
    {
        this.inventory = inventory;

        if (!isInitialized)
        {
            CreateSlots();
            isInitialized = true;
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
            slot.Init(i, OnClickSlot); // 아이템 바로 넘김
            slotUIs.Add(slot);
        }
    }

    public void Refresh()
    {
        // 1) 원본 리스트
        List<ItemInstance> filtered = inventory.items;

        // 2) 타입 필터 적용
        if (currentTypeFilter != null)
        {
            filtered = filtered.FindAll(i => i.template.itemType == currentTypeFilter);
        }

        // 3) 레어리티 필터 적용
        if (currentRarityFilter != null)
        {
            filtered = filtered.FindAll(i => i.template.itemRarity == currentRarityFilter);
        }

        // 4) 슬롯에 적용
        for (int i = 0; i < slotUIs.Count; i++)
        {
            if (i < filtered.Count)
                slotUIs[i].SetItem(filtered[i]);
            else
                slotUIs[i].Clear();
        }
    }

    // 슬롯 클릭 → 팝업 호출
    void OnClickSlot(ItemInstance item)
    {
        GameManager.Instance.uiManager.ShowItemPopup(item);
    }

    IEnumerator ScrollToTopNextFrame()
    {
        yield return null;
        Canvas.ForceUpdateCanvases();

        var scroll = GetComponentInChildren<ScrollRect>();
        if (scroll != null)
            scroll.verticalNormalizedPosition = 1f;
    }
}



