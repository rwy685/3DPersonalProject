using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerCondition condition;
    public PlayerStatus status;
    public PlayerController controller;
    public Inventory inventory;
    public EquipmentManager equipmentManager;

    public void Initialize()
    {
        status = new PlayerStatus();
        equipmentManager = new EquipmentManager();
        
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
        // 테스트용 아이템 추가
        inventory.AddItem(1000, 1);
        inventory.AddItem(1001, 1);
        inventory.AddItem(1002, 1);
        inventory.AddItem(1003, 1);
        inventory.AddItem(1004, 1);
        inventory.AddItem(1005, 1);
        inventory.AddItem(1006, 1);
        inventory.AddItem(1007, 1);
        inventory.AddItem(1008, 1);
        inventory.AddItem(1009, 1);


        Debug.Log("테스트용 아이템 추가 완료");

    }



}
