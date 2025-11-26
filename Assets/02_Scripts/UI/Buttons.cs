using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public void OnClickInventoryBtn()
    {
        GameManager.Instance.uiManager.PushUI(GameManager.Instance.uiManager.inventoryPanel);
    }


    public void OnClickPlayerStatusBtn()
    {
        GameManager.Instance.uiManager.PushUI(GameManager.Instance.uiManager.statusPanel);
    }


    public void OnClickBackBtn()
    {
        GameManager.Instance.uiManager.PopUI();
    }


}
