using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager
{
    public List<Item> equippedItems = new List<Item>();

    public int GetTotalAttack(PlayerStatus baseStatus)
    {
        int total = baseStatus.BaseAttack;

        foreach (var item in equippedItems)
            total += item.value;

        return total;
    }
}

