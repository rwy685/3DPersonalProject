using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject slotPrefab;
    public Transform slotRoot;
    [SerializeField] private int slotCount;

    private Inventory inventory;
    private List<InventorySlotUI> slotUIs = new List<InventorySlotUI>();

    public bool isInitialized = false;

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
            slot.Init(i, ClickSlot);
            slotUIs.Add(slot);

        }
    }

    public void Refresh()
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
    IEnumerator ScrollToTopNextFrame()
    {
        yield return null; // 한 프레임 기다림
        Canvas.ForceUpdateCanvases();

        var scroll = GetComponentInChildren<ScrollRect>();
        if (scroll != null)
        {
            scroll.verticalNormalizedPosition = 1f;  // 맨 위
        }
    }
}



