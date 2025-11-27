using UnityEngine;

public class HUDManager : MonoBehaviour
{
    // 현재 씬에서 찾은 HUD UI
    public PlayerHUDUI hud { get; private set; }

    // HUD 존재 여부
    public bool HasHUD => hud != null;

    // 씬이 바뀔 때마다 호출 (GameManager에서)
    public void FindHUDInScene()
    {
        hud = FindObjectOfType<PlayerHUDUI>();
    }

    // 실제로 PlayerStatus를 HUD에 연결
    public void Init(PlayerStatus status)
    {
        if (hud == null || status == null)
            return;

        hud.Init(status);
    }
}

