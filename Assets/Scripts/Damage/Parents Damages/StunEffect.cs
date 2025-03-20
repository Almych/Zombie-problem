using System.Collections;
using UnityEngine;
[CreateAssetMenu(fileName = "New Stun Effect", menuName = "DamageEffect/StunEffect")]
public class StunEffect : EffectDamageDecorator
{
    public override DamageType damageType => DamageType.Stun;

    public override IEnumerator ApplyEffect(Enemy enemy)
    {
        strategy?.MakeDamage(enemy);
        //can move
        yield return new WaitForSeconds(_effectDuration);
        //can move
    }
}
