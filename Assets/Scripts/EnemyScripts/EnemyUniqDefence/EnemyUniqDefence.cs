using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[Serializable]
public class DamageResistances
{
    [Range(0, 1)] public float Flame;
    [Range(0, 1)] public float Freeze;
    [Range(0, 1)] public float Stun;
    [Range(0, 1)] public float Poison;
    [Range(0, 1)] public float Default;
    [Range(0, 1)] public float Crit;

    public float GetResistance(DamageType type)
    {
        return type switch
        {
            DamageType.Default => Default,
            DamageType.Freeze => Freeze,
            DamageType.Poison => Poison,
            DamageType.Crit => Crit,
            DamageType.Stun => Stun,
            _ => 0f
        };
    }
}

[CreateAssetMenu(fileName = "New DamageDefense", menuName = "DamageDefense")]
public class EnemyUniqDefense : ScriptableObject
{
    [SerializeField] private DamageResistances damageResistances;

    public float Defense(Damage damage)
    {
        return damage.GetDamage() * (1-damageResistances.GetResistance(damage.damageType));
    }

   
}
