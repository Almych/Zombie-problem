using System.Collections;
using UnityEngine;

public class StunEffect : EffectDamageDecorator
{
    public StunEffect(float damage, IDamageStrategy damageStrategy, float effectDuration) : base(damage, damageStrategy, effectDuration)
    {
    }

    public override IEnumerator ApplyEffect(Entity enemy)
    {
        strategy?.MakeDamage(enemy);
        //can move
        yield return new WaitForSeconds(_effectDuration);
        //can move
    }
}
