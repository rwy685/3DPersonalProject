using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition
{
    PlayerStatus status;

    public PlayerCondition(PlayerStatus status)
    {
        this.status = status;
    }

    public void TakeDamage(int damage)
    {
        status.ReduceHP(damage);

        if (status.CurrentHP <= 0)
        {
            Die();
        }
    }

    public void Die()
    {

    }
}



