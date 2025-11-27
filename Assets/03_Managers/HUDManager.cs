using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public PlayerHUDUI hud { get; private set; }

    public bool HasHUD => hud != null;

    //신에서 HUDUI 찾기
    public void FindHUDInScene()
    {
        hud = FindObjectOfType<PlayerHUDUI>();
    }
    //HUDUI 찾고 초기화
    public void Init(PlayerStatus status)
    {
        if (hud != null)
            hud.Init(status);
    }
}


