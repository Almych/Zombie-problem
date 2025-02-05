using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyOnDamageAbility", menuName = "EnemyOnDamageAbility/MoveDiagonalAbility")]
public class MoveDiagonalConfig : EnemyOnDamageAbilityConfig
{
    protected readonly new OnDamageAbility onDamageAbility = OnDamageAbility.MoveDiagonal;
    
}
