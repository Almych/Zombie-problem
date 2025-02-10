using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyOnDeathAbility", menuName = "EnemyOnDeathAbility/None")]
public class EnemyOnDeathAbilityConfig : ScriptableObject
{
   [SerializeField] protected OnDeathAbility OnDeathAbility;

    public OnDeathAbility GetOnDeathAbility() { return OnDeathAbility; }
}
