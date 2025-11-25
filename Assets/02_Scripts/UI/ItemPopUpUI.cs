using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIItemPopup : MonoBehaviour
{
    public Text nameText;
    public Text valueText;
    public Text descText;

    public void Show(ItemInstance item)
    {
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

