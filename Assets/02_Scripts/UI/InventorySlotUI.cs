using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InventorySlotUI : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI countText;

    private int index;
    private Action<int> onClick;

    public void Init(int index, Action<int> onClick)
    {
        this.index = index;
        this.onClick = onClick;
    }

    public void Refresh(Inventory inventory)
    {
        var item = inventory.GetItemBySlot(index);

        if (item == null)
        {
            icon.enabled = false;
            countText.text = "";
        }
        else
        {
            //icon.enabled = true;
            //icon.sprite = LoadIcon(item.template.key);
            countText.text = item.count.ToString();
        }
    }

    public void OnClick()
    {
        onClick?.Invoke(index);
    }
}



