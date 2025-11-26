using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTabButtons : MonoBehaviour
{
    public InventoryUI inventoryUI;

    public void OnClickAll()
    {
        inventoryUI.currentTypeFilter = null;
        inventoryUI.currentRarityFilter = null;
        inventoryUI.Refresh();
    }

    public void OnClickWeapon()
    {
        inventoryUI.currentTypeFilter = DesignEnums.ItemType.Weapon;
        inventoryUI.currentRarityFilter = null;
        inventoryUI.Refresh();
    }

    public void OnClickArmor()
    {
        inventoryUI.currentTypeFilter = DesignEnums.ItemType.Armor;
        inventoryUI.currentRarityFilter = null;
        inventoryUI.Refresh();
    }

    public void OnClickCommon()
    {
        inventoryUI.currentRarityFilter = DesignEnums.ItemRarity.Common;
        inventoryUI.currentTypeFilter = null;
        inventoryUI.Refresh();
    }

    public void OnClickRare()
    {
        inventoryUI.currentRarityFilter = DesignEnums.ItemRarity.Rare;
        inventoryUI.currentTypeFilter = null;
        inventoryUI.Refresh();
    }

    public void OnClickLegendary()
    {
        inventoryUI.currentRarityFilter = DesignEnums.ItemRarity.Legendary;
        inventoryUI.currentTypeFilter = null;
        inventoryUI.Refresh();
    }
}

