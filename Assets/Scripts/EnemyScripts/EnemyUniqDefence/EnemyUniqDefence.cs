using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Defense", menuName = "Defense/DamageDefense")]
public class EnemyUniqDefense : ScriptableObject
{
    public Damage damageToDefense;
    private Dictionary<Type, Action<Damage>> damageHandlers;

    private void OnEnable()
    {
        damageHandlers = new Dictionary<Type, Action<Damage>>
        {
            { typeof(DefaultDamage), HandleDefaultDamage },
            { typeof(ContinuesDamage), HandleContinuesDamage },
            { typeof(EffectDamage), HandleEffectDamage }
        };
    }

    public float GetDefense(Damage damageType)
    {
        if (damageType == null)
            return 0f;
        
        if (damageToDefense.GetType() == damageType.GetType() && damageHandlers.ContainsKey(damageType.GetType()))
        {
            damageHandlers[damageType.GetType()].Invoke(damageType);
            return 0f; 
        }

        return damageType.GetDamage();
    }

    private void HandleDefaultDamage(Damage damageType)
    {
       
    }

    // Handler for ContinuesDamage type.
    private void HandleContinuesDamage(Damage damageType)
    {
        ContinuesDamage continuesDamage = damageType as ContinuesDamage;
        continuesDamage?.StopUniqueDamage();
    }

    private void HandleEffectDamage(Damage damageType)
    {
        EffectDamage effectDamage = damageType as EffectDamage;
        effectDamage?.StopUniqueDamage();
    }
}
