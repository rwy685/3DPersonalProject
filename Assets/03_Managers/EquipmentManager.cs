using UnityEngine;

public class EquipmentManager
{
    public ItemInstance weapon;
    public ItemInstance armor;

    public void Equip(ItemInstance item, PlayerStatus status)
    {
        if (item.template.itemType == DesignEnums.ItemType.Weapon)
        {
            if (weapon != null)
                RemoveStats(weapon, status);

            weapon = item;
            AddStats(item, status);
        }
        else if (item.template.itemType == DesignEnums.ItemType.Armor)
        {
            if (armor != null)
                RemoveStats(armor, status);

            armor = item;
            AddStats(item, status);
        }

    }

    public void Unequip(ItemInstance item, PlayerStatus status)
    {
        if (weapon == item)
        {
            RemoveStats(item, status);
            weapon = null;
        }
        else if (armor == item)
        {
            RemoveStats(item, status);
            armor = null;
        }
    }

    private void AddStats(ItemInstance item, PlayerStatus status)
    {
        status.AddEquipStats(item.TotalAttack, item.TotalDefense, item.TotalHp);
    }

    private void RemoveStats(ItemInstance item, PlayerStatus status)
    {
        status.AddEquipStats(-item.TotalAttack, -item.TotalDefense, -item.TotalHp);
    }
}



