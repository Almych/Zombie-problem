using System;
using System.Collections;
using UnityEngine;

public abstract class EffectDamage : Damage
{
    [SerializeField] protected float stunTime;
    [Range(1, 7)][SerializeField] protected float effectChange;
    public override void MakeDamage(Entity enemy)
    {
        enemy.StartCoroutine(StunEnemy(enemy));
    }

    protected virtual IEnumerator StunEnemy(Entity enemy)
    {
        enemy.GetDamage(damage, default);
        var change = UnityEngine.Random.Range(1, 10);
        if (change <= effectChange)
        {
            enemy.StopMove();
        }
        yield return new WaitForSeconds(stunTime);
        enemy.Initiate();
    }
}
