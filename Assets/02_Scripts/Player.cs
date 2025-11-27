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
        // 기본 상태 생성
        status = new PlayerStatus();

        // 장비 매니저 생성
        equipmentManager = new EquipmentManager();

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

    //===================================
    // 데이터 저장 및 불러오기 용
    //===================================
    public void ApplyLoadedData(SaveData data)
    {
        // Status 복원
        status.LoadFromData(data.status);

        // Inventory 복원
        inventory.LoadFromData(data.inventory);

        // 장비 복원
        equipmentManager.LoadFromData(data.equipment, status);
    }

}
