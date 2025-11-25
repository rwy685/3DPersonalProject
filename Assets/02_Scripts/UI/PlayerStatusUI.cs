using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusUI : MonoBehaviour
{
    public Image hpBar;
    private PlayerStatus status;

    public void Init(PlayerStatus status)
    {
        this.status = status;
        status.OnStatusChanged += Refresh;
        Refresh();
    }

    void Refresh()
    {
        hpBar.fillAmount = (float)status.CurrentHP / status.MaxHP;
    }
}

