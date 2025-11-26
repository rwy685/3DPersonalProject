using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlotUI : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI equipMark;
    private ItemInstance currentItem;
    private int index;
    private Action<ItemInstance> onClick;

    public void Init(int index, System.Action<ItemInstance> onClick)
    {
        this.index = index;
        this.onClick = onClick;
    }

    // 슬롯에 아이템 설정
    public void SetItem(ItemInstance item)
    {
        currentItem = item;

        icon.enabled = true;
        icon.sprite = LoadIcon(item.template.iconName);
        countText.text = item.count.ToString();
    }

    // 빈 슬롯 처리
    public void Clear()
    {
        currentItem = null;
        icon.enabled = false;
        countText.text = "";
    }

    public void OnClick()
    {
        if (currentItem != null)
            onClick?.Invoke(currentItem);
    }

    private Sprite LoadIcon(string iconName)
    {
        return Resources.Load<Sprite>($"Icons/{iconName}");
    }
}




