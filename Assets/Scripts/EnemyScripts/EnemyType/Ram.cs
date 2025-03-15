using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ram : MeleeEnemy
{
    public override void Attack()
    {
        attackDealer?.Attack(healthBar);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        healthBar = collision.collider.GetComponent<HealthBar>();
        if (healthBar != null)
        {
            stateMachine.SwitchState(dieState);
        }
    }
}
