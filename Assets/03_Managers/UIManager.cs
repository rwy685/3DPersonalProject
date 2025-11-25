using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuPrefab;

    private GameObject mainMenuInstance;

    public PlayerStatusUI uiStatus;
    public InventoryUI uiInventory;
    public ItemPopupUI uiItemPopup;

    public GameObject statusPanel;
    public GameObject inventoryPanel;

    public void InitUI()
    {
        // Canvas 찾기
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas == null)
        {
            Debug.Log("Canvas가 존재하지 않습니다.");
            return;
        }

        // 이미 UI가 있다면 삭제하고 다시 생성
        if (mainMenuInstance != null)
            Destroy(mainMenuInstance);

        // UIMainMenu 프리팹 인스턴스 생성
        mainMenuInstance = GameObject.Instantiate(mainMenuPrefab, canvas.transform);

        // 패널 연결
        statusPanel = mainMenuInstance.transform.Find("UIStatus").gameObject;
        inventoryPanel = mainMenuInstance.transform.Find("UIInventory").gameObject;

        uiStatus = statusPanel.GetComponent<PlayerStatusUI>();
        uiInventory = inventoryPanel.GetComponent<InventoryUI>();
        uiItemPopup = mainMenuInstance.transform.Find("UIItemPopup").GetComponent<ItemPopupUI>();

     
        uiItemPopup.Hide();
    }

    public void ShowStatus(PlayerStatus status)
    {
        statusPanel.SetActive(true);

        // 시작 위치를 화면 왼쪽 바깥으로 설정
        statusPanel.transform.localPosition = new Vector3(-600, 0, 0);

        // 0.25초 동안 안쪽으로 슬라이드
        statusPanel.transform.DOLocalMoveX(0, 0.25f).SetEase(Ease.OutQuad);

        uiStatus.Init(status);
    }


    public void ShowInventory(Inventory inventory)
    {
        inventoryPanel.SetActive(true);

        inventoryPanel.transform.localScale = Vector3.zero;
        inventoryPanel.transform.DOScale(Vector3.one, 0.25f).SetEase(Ease.OutBack);

        uiInventory.Init(inventory);
    }

    public void HideAll()
    {
        statusPanel.SetActive(false);
        inventoryPanel.SetActive(false);
        uiItemPopup.Hide();
    }

    public void ShowItemPopup(ItemInstance item)
    {
        uiItemPopup.Show(item);
    }
}


