using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneHitEnemy : MelliEnemyNone
{
    public override void Attack()
    {
        barrier?.ChangeHealthValue(-enemyData.damage);
        stateMachine.SwitchState(stateMachine.deadState);
    }
}
