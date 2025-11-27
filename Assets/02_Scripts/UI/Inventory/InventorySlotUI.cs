using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlotUI : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI equipMark;   // 프리팹에서 Text에 "E" 넣어두기

    private ItemInstance currentItem;
    private int index;
    private Action<ItemInstance> onClick;

    public void Init(int index, Action<ItemInstance> onClick)
    {
        this.index = index;
        this.onClick = onClick;

        icon.enabled = false;
        countText.text = "";

        if (equipMark != null)
            equipMark.gameObject.SetActive(false);

        //AddListener 활용
        var btn = GetComponent<Button>();
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(() =>
        {
            if (currentItem != null)
                this.onClick?.Invoke(currentItem);
        });

    }

    // 슬롯에 아이템 설정
    public void SetItem(ItemInstance item)
    {
        currentItem = item;

        if (item == null)
        {
            Clear();
            return;
        }

        icon.enabled = true;
        icon.sprite = LoadIcon(item.template.iconName);
        countText.text = item.count.ToString();

        UpdateEquipMark();
    }

    // 빈 슬롯 처리
    public void Clear()
    {
        currentItem = null;
        icon.enabled = false;
        countText.text = "";

        if (equipMark != null)
            equipMark.gameObject.SetActive(false);
    }

    // 외부에서 장비 변경 이벤트 후 호출됨
    public void RefreshEquipState()
    {
        UpdateEquipMark();
    }

    private void UpdateEquipMark()
    {
        if (equipMark == null)
            return;

        if (currentItem == null)
        {
            equipMark.gameObject.SetActive(false);
            return;
        }

        var player = GameManager.Instance.characterManager.player;
        var eq = player.equipmentManager;

        bool isEquipped =
            (eq.weapon == currentItem) ||
            (eq.armor == currentItem);

        equipMark.gameObject.SetActive(isEquipped);
    }

    private Sprite LoadIcon(string iconName)
    {
        return Resources.Load<Sprite>($"Icons/{iconName}");
    }
}





