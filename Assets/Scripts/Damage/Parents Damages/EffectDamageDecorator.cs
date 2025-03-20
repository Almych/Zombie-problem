using System;
using System.Collections;
using UnityEngine;

public abstract class EffectDamageDecorator : Damage, IDamageEffect
{
    [SerializeField] protected DefaultDamage strategy;
    [SerializeField] protected float _effectDuration;

    

    public abstract IEnumerator ApplyEffect(Enemy enemy);

    public override void MakeDamage(Enemy enemy)
    {
        if (strategy == null)
            return;

        strategy.MakeDamage(enemy);
        enemy.StartCoroutine(ApplyEffect(enemy));
    }
}
