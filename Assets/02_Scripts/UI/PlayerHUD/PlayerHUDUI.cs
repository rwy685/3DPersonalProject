using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHUDUI : MonoBehaviour
{
    public TextMeshProUGUI idText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI goldText;

    public Image expFill;
    public TextMeshProUGUI expText;

    private PlayerStatus status;

    public void Init(PlayerStatus status)
    {
        this.status = status;

        status.OnStatusChanged += Refresh;  // 변경 시 자동 반영

        Refresh();
    }

    void Refresh()
    {
        idText.text = status.PlayerID;
        levelText.text = $"Lv {status.Level}";

        goldText.text = status.Gold.ToString();

        float ratio = (float)status.CurrentExp / status.MaxExp;
        expFill.fillAmount = ratio;

        expText.text = $"{status.CurrentExp} / {status.MaxExp}";
    }
}


