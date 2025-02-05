using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyOnDeathAbility", menuName = "EnemyOnDeathAbility/SpawnAbility")]
public class SpawnAbilityConfig : EnemyOnDeathAbilityConfig
{
    protected readonly new OnDeathAbility OnDeathAbility = OnDeathAbility.Spawn;
    public Entity enemyToSpawn;
    public int amountToSpawn;
}
