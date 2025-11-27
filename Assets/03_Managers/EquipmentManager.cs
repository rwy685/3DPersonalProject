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
        status.AddEquipStats(item.TotalAttack, item.TotalDefense, item.TotalHp, item.TotalCritical);
    }

    private void RemoveStats(ItemInstance item, PlayerStatus status)
    {
        status.RemoveEquipStats(item.TotalAttack, item.TotalDefense, item.TotalHp, item.TotalCritical);
    }

    //===================================
    // 데이터 저장 및 불러오기 용
    //===================================
    public EquipmentData ToData()
    {
        return new EquipmentData()
        {
            weaponID = weapon?.itemID ?? -1,
            armorID = armor?.itemID ?? -1
        };
    }

    public void LoadFromData(EquipmentData data, PlayerStatus status)
    {
        var inv = GameManager.Instance.characterManager.player.inventory;

        if (data.weaponID >= 0)
        {
            var item = inv.items.Find(i => i.itemID == data.weaponID);
            if (item != null)
                Equip(item, status);
        }

        if (data.armorID >= 0)
        {
            var item = inv.items.Find(i => i.itemID == data.armorID);
            if (item != null)
                Equip(item, status);
        }
    }

}






