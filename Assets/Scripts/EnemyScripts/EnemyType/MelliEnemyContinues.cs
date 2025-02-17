using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class MelliEnemyContinues : MelliEnemyNone
{

    //public override void Attack()
    //{
    //    if (barrier != null)
    //    StartCoroutine(ContinuesAttack(barrier));
    //}

    //private IEnumerator ContinuesAttack(HealthBar barrier)
    //{
    //    while (stateMachine.currentState == stateMachine.attackState)
    //    {
    //        yield return new WaitForSeconds(enemyData.attackCoolDown);
    //        barrier.ChangeHealthValue(-enemyData.damage);
    //    }
    //}
}
