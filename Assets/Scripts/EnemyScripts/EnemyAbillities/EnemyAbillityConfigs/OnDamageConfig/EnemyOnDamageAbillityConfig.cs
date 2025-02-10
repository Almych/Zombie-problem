using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyOnDamageAbility", menuName = "EnemyOnDamageAbility/None")]
public class EnemyOnDamageAbilityConfig : ScriptableObject
{
    [SerializeField] protected OnDamageAbility onDamageAbility;

    public OnDamageAbility GetOnDamageAbility() { return onDamageAbility; }
}
