using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Knight : MeleeEnemy
{
    public override void Attack()
    {
        base.Attack();
    }
    public override void Init()
    {
        base.Init();
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        healthBar = collision.collider.GetComponent<HealthBar>();
        if (healthBar != null )
        {
            stateMachine.SwitchState(attackState);
        }
    }
}
