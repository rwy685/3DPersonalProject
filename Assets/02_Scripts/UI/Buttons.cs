using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public void OnClickInventoryBtn()
    {
        var player = GameManager.Instance.characterManager.player;
        GameManager.Instance.uiManager.ShowInventory(player.inventory);
    }

    public void OnClickPlayerStatusBtn()
    {
        var player = GameManager.Instance.characterManager.player;
        GameManager.Instance.uiManager.ShowStatus(player.status);
    }

    public void OnClickHideAll()
    {
        GameManager.Instance.uiManager.HideAll();
    }

}    
