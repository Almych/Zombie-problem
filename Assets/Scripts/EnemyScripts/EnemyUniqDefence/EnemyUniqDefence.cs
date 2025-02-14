using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Defense", menuName = "Defense/DamageDefense")]
public class EnemyUniqDefense : ScriptableObject
{
    public Damage damageToDefense;
    public float GetDefense(Damage damageType)
    {
        if (damageType != damageToDefense || damageType == default)
        { 
            return damageType.GetDamage();
        }
        
        if (damageType is ContinuesDamage continuesDamage)
        {
            continuesDamage.StopUniqueDamage();
        }
        else if (damageType is EffectDamage effectDamage)
        {
            effectDamage.StopUniqueDamage();
        }

        return 0f;
    }
}
