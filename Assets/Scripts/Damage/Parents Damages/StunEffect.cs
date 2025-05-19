using System.Collections;
using UnityEngine;
[CreateAssetMenu(fileName = "New Stun Effect", menuName = "DamageEffect/StunEffect")]
public class StunEffect : EffectDamageDecorator
{
    [SerializeField] private int _effectDuration;
    public override DamageType damageType => DamageType.Stun;

    public override void ApplyEffect(Enemy enemy)
    {
        enemy.RequestStun(_effectDuration);
    }


    public override void MakeDamage(Enemy enemy)
    {
        defaultDamage?.MakeDamage(enemy);
        ApplyEffect(enemy);
    }
}
