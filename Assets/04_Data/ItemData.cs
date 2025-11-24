using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Item/ItemData")]
public class ItemData : ScriptableObject
{
    public int itemID;
    public string name;
    public Sprite icon;

    public ItemType itemType;

    public int attackBonus;
    public int defenseBonus;
    public int healAmount;
}
