using System.Collections;
using UnityEngine;
[CreateAssetMenu(fileName = "New Freeze Effect", menuName = "DamageEffect/FreezeEffect")]
public class FreezeEffect : EffectDamageDecorator
{
    [SerializeField] private float _slowAmount;

   

    public override DamageType damageType => DamageType.Freeze;

    public override IEnumerator ApplyEffect(Entity enemy)
    {
        strategy?.MakeDamage(enemy);
        // make enemy move slower
        yield return new WaitForSeconds(_effectDuration);
        //make enemy move average
    }
}
