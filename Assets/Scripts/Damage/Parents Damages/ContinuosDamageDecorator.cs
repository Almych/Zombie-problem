using System;
using System.Collections;
using UnityEngine;


public abstract class ContinuesDamageDecorator : Damage, IDamageEffect
{
    protected IDamageStrategy strategy;
    protected float _duration;
    protected float _intervals;
    protected ContinuesDamageDecorator(float damage, IDamageStrategy damageStrategy, float duration, float intervals = 0.1f) : base(damage)
    {
        strategy = damageStrategy;
        _duration = duration;
        _intervals = intervals;
    }

    public IEnumerator ApplyEffect(Entity enemy)
    {
        float elapsed = 0f;
        while (elapsed < _duration)
        {
            enemy.TakeDamage(this);
            yield return new WaitForSeconds(_intervals);
            elapsed += _intervals;
        }

    }

    public override void MakeDamage(Entity enemy)
    {
        if (strategy == null)
            return;

        strategy.MakeDamage(enemy);
        enemy.StartCoroutine(ApplyEffect(enemy));
    }
}
