using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public Player player { get; private set; }
    public GameObject playerPrefab;

    public void CreatePlayer()
    {
        if (player != null) return;

        var obj = Instantiate(playerPrefab);
        player = obj.GetComponent<Player>();
        player.Initialize();

        DontDestroyOnLoad(obj);
    }
}


