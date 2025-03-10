using System;
using System.Collections;
using UnityEngine;


public abstract class ContinuesDamageDecorator : Damage, IDamageEffect
{
    [SerializeField] protected DefaultDamage strategy;
    [SerializeField] protected float _duration;
    [SerializeField] protected float _intervals = 1f;

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
