using System.Collections;
using UnityEngine;
[CreateAssetMenu(fileName = "New Freeze Effect", menuName = "DamageEffect/FreezeEffect")]
public class FreezeEffect : EffectDamageDecorator
{
    [SerializeField, Range(0.1f, 1f)] private float _slowAmount;

   

    public override DamageType damageType => DamageType.Freeze;

    public override void ApplyEffect(Enemy enemy)
    {
        enemy.ReduceSpeed(_slowAmount);
    }

    public override void MakeDamage(Enemy enemy)
    {
        defaultDamage?.MakeDamage(enemy);
        ApplyEffect(enemy);
    }
}
