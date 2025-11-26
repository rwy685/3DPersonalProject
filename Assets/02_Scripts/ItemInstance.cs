using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemInstance
{
    public int itemID;
    public int count;
    public ItemInfo template;
    public List<ItemOptionValue> options;

    public ItemInstance(ItemInfo template, int count = 1)
    {
        this.template = template;
        this.itemID = template.key;
        this.count = count;

        GenerateOptionValues();
    }

    void GenerateOptionValues()
    {
        options = new List<ItemOptionValue>();
        var rarity = template.itemRarity;

        var optionLoader = GameManager.Instance.dataManager.optionInfoLoader;

        foreach (int optID in template.optionList)
        {
            var optData = optionLoader.GetByKey(optID);
            if (optData == null)
                continue;

            int finalValue = CalculateValue(optData.MinValue, optData.MaxValue, rarity);

            options.Add(new ItemOptionValue()
            {
                optionID = optID,
                value = finalValue
            });
        }
    }

    int CalculateValue(int min, int max, DesignEnums.ItemRarity rarity)
    {
        switch (rarity)
        {
            case DesignEnums.ItemRarity.Common: return min;
            case DesignEnums.ItemRarity.Rare: return UnityEngine.Random.Range(min, min + 7);
            case DesignEnums.ItemRarity.Legendary: return UnityEngine.Random.Range(min + 7, max);
            default: return min;
        }
    }

    // 옵션 합산 함수
    private int GetOptionTotal(string optionName)
    {
        var optionLoader = GameManager.Instance.dataManager.optionInfoLoader;

        return options
            .Where(o => optionLoader.GetByKey(o.optionID).Name == optionName)
            .Sum(o => o.value);
    }

    // 최종 스탯 계산
    public int TotalAttack => template.baseAttack + GetOptionTotal("Attack");
    public int TotalDefense => template.baseDefense + GetOptionTotal("Defense");
    public int TotalHp => template.baseHp + GetOptionTotal("HP");

    public Sprite GetIcon()
    {
        return Resources.Load<Sprite>($"Icons/{template.iconName}");
    }
}



