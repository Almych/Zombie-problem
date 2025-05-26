using System;
using System.Collections;
using UnityEngine;


public abstract class ContinuesDamageDecorator : Damage, IDamageEffect
{
    [SerializeField] protected DefaultDamage strategy;
    [SerializeField] protected float _duration;
    [SerializeField] protected float _intervals = 1f;
    public abstract Color effectColor { get; }
    public void ApplyEffect(Enemy enemy)
    {
        enemy.StartCoroutine(ApplyContinuesDamage(enemy));
    }

    protected IEnumerator ApplyContinuesDamage(Enemy enemy)
    {
        float elapsed = 0f;
        while (elapsed < _duration)
        {
            enemy.TakeDamage(this);
            enemy.SetColor(effectColor);
            yield return new WaitForSeconds(_intervals);
            elapsed += _intervals;
        }
        enemy.SetColor(Color.white);
    }

    public override void MakeDamage(Enemy enemy)
    {
        if (strategy == null)
            return;
        strategy.MakeDamage(enemy);
        ApplyEffect(enemy);
    }
}
