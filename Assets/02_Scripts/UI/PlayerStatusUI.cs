using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatusUI : MonoBehaviour
{
    private PlayerStatus status;

    public TextMeshProUGUI attackText;
    public TextMeshProUGUI defenseText;
    public TextMeshProUGUI criticalText;
    public TextMeshProUGUI hpText;

    public void Init(PlayerStatus status)
    {
        this.status = status;
        status.OnStatusChanged += Refresh;
        Refresh();
    }

    void Refresh()
    {
        attackText.text = status.BaseAttack.ToString();
        defenseText.text = status.BaseDefense.ToString();
        criticalText.text = status.BaseCritical.ToString("F1");
        hpText.text = $"{status.CurrentHP} / {status.MaxHP}";
    }
}

