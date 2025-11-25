using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerCondition condition;
    [SerializeField] private PlayerStatus status;
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
}
