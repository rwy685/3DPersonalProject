using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldUI : MonoBehaviour
{
    public TextMeshProUGUI goldText;

    public void Init(PlayerStatus status)
    {
        status.OnStatusChanged += () => Refresh(status.Gold);
        Refresh(status.Gold);
    }

    public void Refresh(int amount)
    {
        goldText.text = amount.ToString();
    }
}


