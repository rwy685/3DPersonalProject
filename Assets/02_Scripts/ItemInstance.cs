using System;
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

        DesignEnums.ItemRarity rarity = template.itemRarity;

        // OptionLoader 가져오기
        var optionLoader = GameManager.Instance.dataManager.optionInfoLoader;

        foreach (int optID in template.optionList)
        {
            var optData = optionLoader.GetByKey(optID);
            if (optData == null)
            {
                Debug.LogError($"옵션 ID {optID} 를 OptionInfoLoader에서 찾지 못했습니다.");
                continue;
            }

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
            case DesignEnums.ItemRarity.Common:
                return min;

            case DesignEnums.ItemRarity.Rare:
                return UnityEngine.Random.Range(min, min + 7);

            case DesignEnums.ItemRarity.Legendary:
                return UnityEngine.Random.Range(min + 7, max);

            default:
                return min;
        }
    }

    public Sprite GetIcon()
    {
        return Resources.Load<Sprite>($"Icons/{template.iconName}");
    }
}


