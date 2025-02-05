using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Defense", menuName = "Defense/DamageDefense")]
public class EnemyUniqDefense : ScriptableObject
{
    public Damage damageToDefense;
    public float GetDefense(float damage, Damage damageType)
    {
        if (damageType.GetDamage() != damageToDefense)
        {
            return damage;
        }
        else
        {
            return 0f;
        }
    }
}
