using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public interface ILongRangeEnemy
{
    public abstract IEnumerator Shoot();
}

public class LongRangeEnemyNone : Entity, ILongRangeEnemy
{
    protected RaycastHit2D hit;

    public override void AbilityAdd()
    {
       // throw new NotImplementedException();
    }


    protected bool CheckDistance()
    {
        hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), -Vector2.right, enemyData.attackRange, enemyData.barrier);
        if (hit.collider != null)
        {
            if (hit.collider.GetComponent<HealthBar>() != null)
            {
                return true;
            }
            return false;
        }
        else
        {
            return false;
        }
    }

    protected void GetEnemyBullet()
    {
        isAttacking = true;
        rb.velocity = Vector2.zero;
        var bullet = EnemyBulletPool.instance.GetBullet();
        animator.SetBool("isAttacking", isAttacking);
        if (bullet != null)
        {
            bullet.transform.position = transform.position;
            bullet.Activate(ref enemyData.damage);
        }
    }

    public override void Initiate()
    {
        rb.velocity = -transform.right * enemyData.speed;
        Shoot();
    }

    public IEnumerator Shoot()
    {
        while (!isDead)
        {
            yield return new WaitForSeconds(enemyData.attackCoolDown);
            if (CheckDistance())
            {
                Death();
            }
        }
    }
}
