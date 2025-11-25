using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public Player player { get; private set; }
    public GameObject playerPrefab;

    public void CreatePlayer()
    {
        var obj = Instantiate(playerPrefab);
        player = obj.GetComponent<Player>();
        player.Initialize();
    }
}

