using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemPopupUI : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI valueText;
    public TextMeshProUGUI descText;

    public void Show(ItemInstance item)
    {
        nameText.text = item.template.name;

        // 옵션 문자열 구성
        string optionString = "";
        var optionLoader = GameManager.Instance.dataManager.optionInfoLoader;

        foreach (var opt in item.options)
        {
            var optData = optionLoader.GetByKey(opt.optionID);
            optionString += $"{optData.Name} +{opt.value}\n";
        }

        valueText.text = optionString;
        descText.text = item.template.Description;

        // 애니메이션 유지
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutBack);
    }


    public void Hide()
    {
        gameObject.SetActive(false);
    }
}

