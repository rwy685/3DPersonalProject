using System;

public class EquipmentManager
{
    public ItemInstance weapon;
    public ItemInstance armor;

    // 장비 변경될 때 알리는 이벤트
    public event Action OnEquipmentChanged;

    public void Equip(ItemInstance item, PlayerStatus status)
    {
        if (item == null || status == null)
            return;

        var type = item.template.itemType;

        if (type == DesignEnums.ItemType.Weapon)
        {
            // 이미 이 무기를 끼고 있으면 무시
            if (weapon == item)
                return;

            // 기존 무기 해제
            if (weapon != null)
                RemoveStats(weapon, status);

            weapon = item;
            AddStats(item, status);
        }
        else if (type == DesignEnums.ItemType.Armor)
        {
            if (armor == item)
                return;

            if (armor != null)
                RemoveStats(armor, status);

            armor = item;
            AddStats(item, status);
        }

        OnEquipmentChanged?.Invoke();
    }

    public void Unequip(ItemInstance item, PlayerStatus status)
    {
        if (item == null || status == null)
            return;

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

        OnEquipmentChanged?.Invoke();
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






