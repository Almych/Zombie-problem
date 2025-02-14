using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New StunEffect Damage", menuName = "Damage/EffectDamage/StunEffect")]
public class StunEffect : EffectDamage
{
   

    protected override IEnumerator StunEnemy()
    {
        return base.StunEnemy();
    }
 
}
