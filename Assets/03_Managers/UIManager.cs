using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject statusPanel;
    public GameObject inventoryPanel;
    public GameObject itemPopup;

    private Stack<GameObject> uiStack = new Stack<GameObject>();


    public void InitUI()
    {
        mainMenuPanel.SetActive(true);

        var player = GameManager.Instance.characterManager.player;

        // 스택 패널은 기본적으로 꺼둔다
        statusPanel.SetActive(false);
        inventoryPanel.SetActive(false);

        // 팝업도 숨김
        itemPopup.SetActive(false);

        uiStack.Clear();
    }


    public void PushUI(GameObject panel)
    {
        if (uiStack.Count > 0)
            uiStack.Peek().SetActive(false);

        panel.SetActive(true);
        uiStack.Push(panel);

        // 패널 별 Init 처리
        if (panel == inventoryPanel)
        {
            var player = GameManager.Instance.characterManager.player;
            var invUI = inventoryPanel.GetComponent<InventoryUI>();

            if (!invUI.isInitialized)
                invUI.Init(player.inventory);
            else
                invUI.Refresh();
        }

        else if (panel == statusPanel)
        {
            var player = GameManager.Instance.characterManager.player;
            statusPanel.GetComponent<PlayerStatusUI>().Init(player.status);
        }

        // 애니메이션
        panel.transform.localScale = Vector3.zero;
        panel.transform.DOScale(Vector3.one, 0.25f).SetEase(Ease.OutBack);
    }




    public void PopUI()
    {
        if (itemPopup.activeSelf)
        {
            itemPopup.GetComponent<ItemPopupUI>().Hide();
            return;
        }
        if (uiStack.Count == 0)
            return;

        GameObject top = uiStack.Pop();
        top.SetActive(false);

        // 아래 패널 복귀
        if (uiStack.Count > 0)
        {
            uiStack.Peek().SetActive(true);
        }
        else
        {
            // 스택 비었을 때 → MainMenuPanel만 남음
            mainMenuPanel.SetActive(true);
        }
    }

    public void ShowItemPopup(ItemInstance item)
    {
        itemPopup.SetActive(true);
        itemPopup.GetComponent<ItemPopupUI>().Show(item);
    }

}


