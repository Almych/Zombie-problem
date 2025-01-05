using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public interface ILongRangeEnemy
{
    public IEnumerator Shoot();
}

public class LongRangeEnemyNone : Entity, ILongRangeEnemy
{
    private RaycastHit2D hit;



    protected bool CheckDistance()
    {
        hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), -Vector2.right, enemyData.attackRange, enemyData.barrier);
        if (hit.collider != null)
        { 
           return true;
        }
        else
        {
            return false;
        }
    }

    protected void GetEnemyBullet()
    {
        rb.velocity = Vector2.zero;
        var bullet = EnemyBulletPool.instance.GetBullet();
        if (bullet != null)
        {
            bullet.transform.position = transform.position;
            bullet.Activate(enemyData.damage);
        }
    }
    public override void Initiate()
    {
        base.Initiate();
        StartCoroutine(Shoot());
    }

    public virtual IEnumerator Shoot()
    {
        while (stateMachine.currentState != stateMachine.deadState)
        {
            yield return new WaitForSeconds(enemyData.attackCoolDown);
            if (CheckDistance())
            {
                stateMachine.SwitchState(stateMachine.attackState);
            }
        }
    }

    public override void Attack()
    {
        stateMachine.SwitchState(stateMachine.deadState);
    }
}
