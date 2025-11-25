using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public PlayerStatusUI uiStatus;
    public InventoryUI uiInventory;
    public ItemPopUpUI uiItemPopup;

    public GameObject statusPanel;
    public GameObject inventoryPanel;

    void Start()
    {
        // 초기에는 모두 비활성화
        statusPanel.SetActive(false);
        inventoryPanel.SetActive(false);
        uiItemPopup.Hide();
    }

    public void ShowStatus(PlayerStatus status)
    {
        statusPanel.SetActive(true);
        inventoryPanel.SetActive(false);
        uiStatus.Init(status);
    }

    public void ShowInventory(Inventory inventory)
    {
        inventoryPanel.SetActive(true);

        // DOTween 크기 애니메이션
        inventoryPanel.transform.localScale = Vector3.zero;
        inventoryPanel.transform.DOScale(Vector3.one, 0.25f).SetEase(Ease.OutBack);

        uiInventory.Init(inventory);
    }


    public void ShowItemPopup(ItemInstance item)
    {
        uiItemPopup.Show(item);
    }

    public void HideAll()
    {
        statusPanel.SetActive(false);
        inventoryPanel.SetActive(false);
        uiItemPopup.Hide();
    }
}

