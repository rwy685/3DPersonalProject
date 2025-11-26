using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerStatus
{
    private int maxHP;
    private int currentHP;
    private int attack;
    private int defense;
    private float critical;
    private int gold;

    public int MaxHP => maxHP;
    public int CurrentHP => currentHP;
    public int BaseAttack => attack;
    public int BaseDefense => defense;
    public float BaseCritical => critical;
    public int Gold => gold;

    public event Action OnStatusChanged;

    public PlayerStatus()
    {
        maxHP = 100;
        currentHP = 100;
        attack = 10;
        defense = 5;
        critical = 5f;
        gold = 2000;
    }

    public void ReduceHP(int damage)
    {
        currentHP = Mathf.Clamp(currentHP - damage, 0, maxHP);
        OnStatusChanged?.Invoke();
    }

    public void AddHP(int amount)
    {
        currentHP = Mathf.Clamp(currentHP + amount, 0, maxHP);
        OnStatusChanged?.Invoke();
    }

    //Data -> Json 변환용
    public void LoadFromData(PlayerStatusData data)
    {
        maxHP = data.maxHP;
        currentHP = data.currentHP;
        attack = data.attack;
        defense = data.defense;
        critical = data.critical;
    }

    //Json -> Data 변환용
    public PlayerStatusData ToData()
    {
        return new PlayerStatusData()
        {
            maxHP = this.maxHP,
            currentHP = this.currentHP,
            attack = this.attack,
            defense = this.defense,
            critical = this.critical
        };
    }


}



