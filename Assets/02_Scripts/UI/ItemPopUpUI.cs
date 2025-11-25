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
        Debug.Log($"[Popup] 받아온 ItemInstance: ID={item?.itemID}, name={item?.template?.name}");
        gameObject.SetActive(true);

        nameText.text = item.template.name;
        valueText.text = item.template.value.ToString();
        descText.text = item.template.Description;

        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutBack);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}

