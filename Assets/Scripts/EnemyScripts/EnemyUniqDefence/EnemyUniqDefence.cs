using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Defence", menuName = "Defence/DamageDefence")]
public class EnemyUniqDefence : ScriptableObject
{
    public Damage damageToDefence;
    public float GetDefence(float damage, Damage damageType)
    {
        if (damageType.GetDamage() != damageToDefence)
        {
            return damage;
        }
        else
        {
            return 0f;
        }
    }
}
