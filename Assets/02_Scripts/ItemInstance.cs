using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ItemInstance
{
    public int itemID;    // 어떤 아이템인지
    public int count;     // 몇 개 있는지
    public Item template; // JSON 템플릿 참조

    public ItemInstance(Item template, int count = 1)
    {
        this.itemID = template.key;
        this.count = count;
        this.template = template;
    }
}

