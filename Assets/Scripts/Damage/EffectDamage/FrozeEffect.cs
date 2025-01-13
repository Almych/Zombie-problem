using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Froze Damage", menuName = "Damage/EffectDamage/FrozeEffect")]
public class FrozeEffect : EffectDamage
{
    protected override IEnumerator StunEnemy(Entity enemy)
    {
        return base.StunEnemy(enemy);
    }
}
