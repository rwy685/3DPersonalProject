using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerStatus
{
    private string playerID;
    private int level;
    private int maxExp;
    private int maxHP;
    private int currentexp;
    private int currentHP;
    private int attack;
    private int defense;
    private float critical;
    private int gold;

    //프로퍼티
    public string PlayerID => playerID;
    public int Level => level;
    public int MaxExp => maxExp;
    public int CurrentExp => currentexp;
    public int Gold => gold;
    public int MaxHP => maxHP;
    public int CurrentHP => currentHP;
    public int BaseAttack => attack;
    public int BaseDefense => defense;
    public float BaseCritical => critical;

    // 장비 보정치
    private int equipAttack;
    private int equipDefense;
    private int equipHp;
    private float equipCritical;

    // 최종 값
    public int FinalAttack => attack + equipAttack;
    public int FinalDefense => defense + equipDefense;
    public int FinalMaxHp => maxHP + equipHp;
    public float FinalCritical => critical + equipCritical;


    public event Action OnStatusChanged;


    //테스트를 위한 생성자
    public PlayerStatus()
    {
        playerID = "Ryou";
        level = 5;
        maxExp = 20;
        currentexp = 10;
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

    public void AddEquipStats(int a, int d, int h, float c)
    {
        equipAttack += a;
        equipDefense += d;
        equipHp += h;
        equipCritical += c;
        RaiseStatusChanged();
    }

    public void RemoveEquipStats(int a, int d, int h, float c)
    {
        equipAttack -= a;
        equipDefense -= d;
        equipHp -= h;
        equipCritical -= c;
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
    public void AddExp(int amount)
    {
        currentexp += amount;

        if (currentexp >= maxExp)
        {
            currentexp -= maxExp;
            level += 1;
            maxExp += 10; 
        }

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



