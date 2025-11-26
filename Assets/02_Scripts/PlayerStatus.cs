using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerStatus
{
    [SerializeField] private int maxHP;
    [SerializeField] private int currentHP;
    [SerializeField] private int attack;
    [SerializeField] private int defense;
    [SerializeField] private float critical;
    [SerializeField] private int gold;

    // 기존 프로퍼티
    public int MaxHP => maxHP;
    public int CurrentHP => currentHP;
    public int BaseAttack => attack;
    public int BaseDefense => defense;
    public float BaseCritical => critical;
    public int Gold => gold;

    // 장비 보정치
    private int equipAttack;
    private int equipDefense;
    private int equipHp;

    // 최종 값
    public int FinalAttack => attack + equipAttack;
    public int FinalDefense => defense + equipDefense;
    public int FinalMaxHp => maxHP + equipHp;

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
    void RaiseStatusChanged()
    {
        OnStatusChanged?.Invoke();
    }

    public void AddEquipStats(int a, int d, int h)
    {
        equipAttack += a;
        equipDefense += d;
        equipHp += h;
        RaiseStatusChanged();
    }

    public void ReduceHP(int damage)
    {
        currentHP = Mathf.Clamp(currentHP - damage, 0, FinalMaxHp);
        RaiseStatusChanged();
    }

    public void AddHP(int amount)
    {
        currentHP = Mathf.Clamp(currentHP + amount, 0, FinalMaxHp);
        RaiseStatusChanged();
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



