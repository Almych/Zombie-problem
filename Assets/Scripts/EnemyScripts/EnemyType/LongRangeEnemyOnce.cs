using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class LongRangeEnemyOnce : LongRangeEnemyNone
{
    public override void Attack()
    {
        GetEnemyBullet();
        stateMachine.SwitchState(stateMachine.deadState);
    }
}
