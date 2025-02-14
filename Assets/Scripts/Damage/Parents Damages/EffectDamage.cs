using System;
using System.Collections;
using UnityEngine;

public abstract class EffectDamage : Damage
{
    [SerializeField] protected float stunTime;
    [Range(1, 7)][SerializeField] protected float effectChance;
    private Entity currentEnemy;
    private DefaultDamage defaultDamage;

    public override void MakeDamage(Entity enemy)
    {
        enemy.GetDamage(defaultDamage);
        currentEnemy = enemy;
        currentEnemy.StartCoroutine(StunEnemy());
    }

    protected virtual IEnumerator StunEnemy()
    {
       
        if (CanUseEffect())
        {
            currentEnemy.stateMachine.SwitchState(currentEnemy.stateMachine.stunedState);
            yield return new WaitForSeconds(stunTime);
            currentEnemy.stateMachine.SwitchState(currentEnemy.stateMachine.runState);
        }
    }

    private bool CanUseEffect()
    {
        var chance = UnityEngine.Random.Range(1, 10);
        return effectChance >= chance;
    }

    public  void StopUniqueDamage()
    {
        if (currentEnemy != null)
        {
            currentEnemy.StopCoroutine(StunEnemy());
            currentEnemy = null;
        }
    }
}
