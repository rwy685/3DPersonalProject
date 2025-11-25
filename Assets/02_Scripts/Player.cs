using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerCondition condition;
    public PlayerStatus status;
    public PlayerController controller;
    public Inventory inventory;

    public void Initialize()
    {
        status = new PlayerStatus();
        
        PlayerStatusData data = GameManager.Instance.dataManager.LoadPlayerStatus();

        if (data != null)
            status.LoadFromData(data);
        else
            status = new PlayerStatus(); // 기본값

        // Condition 초기화
        condition = new PlayerCondition(status);
        inventory = GetComponent<Inventory>();
        controller = GetComponent<PlayerController>();
    }

    void Start()
    {
        var loader = new ItemLoader();

        inventory.AddItem(1000, 2); // 아이템ID = 1, count = 2
        inventory.AddItem(1001, 1);
    }



}
