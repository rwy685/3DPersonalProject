using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using TMPro;

public class ItemPopupUI : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI baseStatText;
    public TextMeshProUGUI addedStatText;
    public TextMeshProUGUI descText;

    private ItemInstance currentItem;

    public void Show(ItemInstance item)
    {
        currentItem = item;

        nameText.text = item.template.name;
        descText.text = item.template.Description;

        // 1. 기본 스탯
        if (item.template.itemType == DesignEnums.ItemType.Weapon)
            baseStatText.text = $"공격력 {item.template.baseAttack}";
        else if (item.template.itemType == DesignEnums.ItemType.Armor)
            baseStatText.text = $"방어력 {item.template.baseDefense}";
        else
            baseStatText.text = ""; // potion 같은 타입 대비

        // 2. 추가 옵션
        addedStatText.text = "";
        var optionLoader = GameManager.Instance.dataManager.optionInfoLoader;

        foreach (var opt in item.options)
        {
            var optData = optionLoader.GetByKey(opt.optionID);
            addedStatText.text += $"{optData.Name} +{opt.value}\n";
        }

        // 팝업 애니메이션
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutBack);

        gameObject.SetActive(true);
    }

    public void OnClickEquip()
    {
        var player = GameManager.Instance.characterManager.player;
        player.equipmentManager.Equip(currentItem, player.status);
    }

    public void OnClickUnequip()
    {
        var player = GameManager.Instance.characterManager.player;
        player.equipmentManager.Unequip(currentItem, player.status);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}



