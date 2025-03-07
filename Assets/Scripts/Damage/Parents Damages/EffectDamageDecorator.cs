using System;
using System.Collections;
using UnityEngine;

public abstract class EffectDamageDecorator : Damage, IDamageEffect
{
    protected IDamageStrategy strategy;
    protected float _effectDuration;

    protected EffectDamageDecorator(float damage, IDamageStrategy damageStrategy, float effectDuration) : base(damage)
    {
        strategy = damageStrategy;
        _effectDuration = effectDuration;
    }

    public abstract IEnumerator ApplyEffect(Entity enemy);

    public override void MakeDamage(Entity enemy)
    {
        if (strategy == null)
            return;

        strategy.MakeDamage(enemy);
        enemy.StartCoroutine(ApplyEffect(enemy));
    }
}
