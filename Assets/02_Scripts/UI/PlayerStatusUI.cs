using UnityEngine;
using TMPro;

public class PlayerStatusUI : MonoBehaviour
{
    private PlayerStatus status;
    private bool isInitialized = false;

    public TextMeshProUGUI attackText;
    public TextMeshProUGUI defenseText;
    public TextMeshProUGUI criticalText;
    public TextMeshProUGUI hpText;

    public void Init(PlayerStatus status)
    {
        this.status = status;

        if (!isInitialized)
        {
            status.OnStatusChanged += Refresh;

            var player = GameManager.Instance.characterManager.player;
            player.equipmentManager.OnEquipmentChanged += Refresh;

            isInitialized = true;
        }

        Refresh();
    }

    void Refresh()
    {
        if (status == null)
            return;

        // PlayerStatus에 FinalAttack/FinalDefense/FinalMaxHp 프로퍼티가 있어야 함
        attackText.text = status.FinalAttack.ToString();
        defenseText.text = status.FinalDefense.ToString();
        criticalText.text = status.BaseCritical.ToString("F1");
        hpText.text = $"{status.CurrentHP} / {status.FinalMaxHp}";
    }
}


