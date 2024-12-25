using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMelliEnemy
{
    public void OnCollisionEnter2D(Collision2D collision);
}
public class MelliEnemyNone : Entity, IMelliEnemy
{
    protected HealthBar barrier;

  
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<HealthBar>() != null)
        {
            barrier = collision.collider.GetComponent<HealthBar>();
            stateMachine.SwitchState(stateMachine.attackState);
        }
    }



    public override void Attack()
    {
        stateMachine.SwitchState(stateMachine.deadState);
    }
}
