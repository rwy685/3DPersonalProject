using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public Player player { get; private set; }

    public void CreatePlayer()
    {
        player = new Player();
        player.Initialize();
    }
    
}
