using System.Text;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemPopupUI : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI baseStatText;
    public TextMeshProUGUI addedStatText;
    public TextMeshProUGUI descText;

    public Button equipButton;
    public Button unequipButton;

    private ItemInstance currentItem;

    public void Show(ItemInstance item)
    {
        currentItem = item;

        var player = GameManager.Instance.characterManager.player;
        var eq = player.equipmentManager;

        bool isEquipped = (eq.weapon == item || eq.armor == item);

        equipButton.gameObject.SetActive(!isEquipped);
        unequipButton.gameObject.SetActive(isEquipped);

        nameText.text = item.template.name;
        descText.text = item.template.Description;

        // 기본 스탯
        StringBuilder sb = new StringBuilder();

        if (item.template.baseAttack != 0)
            sb.AppendLine($"기본 공격력 : {item.template.baseAttack}");

        if (item.template.baseDefense != 0)
            sb.AppendLine($"기본 방어력 : {item.template.baseDefense}");

        if (item.template.baseHp != 0)
            sb.AppendLine($"기본 체력 : {item.template.baseHp}");

        baseStatText.text = sb.ToString();


        // 추가 옵션
        addedStatText.text = "";
        var optionLoader = GameManager.Instance.dataManager.optionInfoLoader;

        foreach (var opt in item.options)
        {
            var optData = optionLoader.GetByKey(opt.optionID);
            addedStatText.text += string.Format(optData.Description, opt.value) + "\n";
        }


        gameObject.SetActive(true);

        // 팝업 애니메이션
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutBack);
    }

    public void OnClickEquip()
    {
        var player = GameManager.Instance.characterManager.player;
        player.equipmentManager.Equip(currentItem, player.status);

        gameObject.SetActive(false);
    }

    public void OnClickUnequip()
    {
        var player = GameManager.Instance.characterManager.player;
        player.equipmentManager.Unequip(currentItem, player.status);

        gameObject.SetActive(false);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}




