using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class LongRangeEnemyOnce : LongRangeEnemyNone
{

    public new IEnumerator Shoot()
    {
        while (!isDead)
        {
            yield return new WaitForSeconds(enemyData.attackCoolDown);
            if (CheckDistance())
            {
                GetEnemyBullet();
                Death();
            }
        }
    }
}
