using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public PlayerHUDUI hud;

    public void Init(PlayerStatus status)
    {
        hud.Init(status);
    }
}
