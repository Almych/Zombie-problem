using System;
using System.Collections;
using UnityEngine;

public abstract class EffectDamage : Damage
{
    [SerializeField] protected float stunTime;
    [Range(1, 7)][SerializeField] protected float effectChance;
    private Entity currentEnemy;
    

    //public override void MakeDamage(Entity enemy)
    //{
    //    defaultDamage = CreateInstance<DefaultDamage>();
    //    defaultDamage.Init(damage);
    //    enemy.GetDamage(defaultDamage);
    //    currentEnemy = enemy;
    //    if(currentEnemy.stateMachine.currentState != currentEnemy.stateMachine.deadState)
    //    currentEnemy.StartCoroutine(StunEnemy());
    //}

    //protected virtual IEnumerator StunEnemy()
    //{
    //    if (CanUseEffect())
    //    {
    //        Debug.Log("enemy is stunned!");
    //        currentEnemy.stateMachine.SwitchState(currentEnemy.stateMachine.stunedState);
    //        yield return new WaitForSeconds(stunTime);
    //        currentEnemy.stateMachine.SwitchState(currentEnemy.stateMachine.runState);
    //    }
    //    else
    //    {
    //        Debug.Log("enemy is not stunned!");
    //    }
    //}

    private bool CanUseEffect()
    {
        var chance = UnityEngine.Random.Range(1, 10);
        return effectChance >= chance;
    }

    public void StopUniqueDamage()
    {
        if (currentEnemy != null)
        {
            //currentEnemy.StopCoroutine(StunEnemy());
            currentEnemy = null;
        }
    }
}
