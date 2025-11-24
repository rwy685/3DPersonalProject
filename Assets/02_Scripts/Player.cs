using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerCondition condition;
    public PlayerStatus status;
    public PlayerController controller;
    public Inventory inventory;

    public void Initialize()
    {
        status = new PlayerStatus();
        condition = new PlayerCondition();
        controller = new PlayerController();
        inventory = new Inventory();

    }


}
