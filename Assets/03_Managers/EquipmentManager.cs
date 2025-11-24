using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager
{
    public List<ItemData> equippedItems = new List<ItemData>();

    public int GetTotalAttack(PlayerStatus baseStatus)
    {
        int total = baseStatus.BaseAttack;

        foreach (var item in equippedItems)
            total += item.attackBonus;

        return total;
    }
}

