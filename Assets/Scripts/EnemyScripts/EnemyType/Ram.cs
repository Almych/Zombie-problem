using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ram : MeleeEnemy
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        healthBar = collision.collider.GetComponent<HealthBar>();
        if (healthBar != null)
        {
            stateMachine.SwitchState(attackState);
        }
    }
}
