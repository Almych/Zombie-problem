using System.Collections;
using UnityEngine;

public class FreezeEffect : EffectDamageDecorator
{
    private float _slowAmount;

    public FreezeEffect(float damage, IDamageStrategy damageStrategy, float effectDuration, float slowAmount) : base(damage, damageStrategy, effectDuration)
    {
        _slowAmount = slowAmount;
    }

    public override IEnumerator ApplyEffect(Entity enemy)
    {
        strategy?.MakeDamage(enemy);
        // make enemy move slower
        yield return new WaitForSeconds(_effectDuration);
        //make enemy move average
    }
}
