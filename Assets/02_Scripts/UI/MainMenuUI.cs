using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public TextMeshProUGUI goldText;

    public void RefreshGold(int amount)
    {
        goldText.text = amount.ToString();
    }
}

