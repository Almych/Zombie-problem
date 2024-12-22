using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class LongRangeContinues : LongRangeEnemyNone
{
    public override void Initiate()
    {
        rb.velocity = -transform.right * enemyData.speed;

        StartCoroutine(Shoot());
    }
    public new IEnumerator Shoot()
    {
         while (!isDead)
         {
                yield return new WaitForSeconds(enemyData.attackCoolDown);
                if (CheckDistance())
                {
                    GetEnemyBullet();
                }
         }
    }
}
