using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyOnDeathAbillity", menuName = "EnemyOnDeathAbillity/SpawnAbillity")]
public class SpawnAbillityConfig : EnemyOnDeathAbillityConfig
{
    public new readonly OnDeathAbillity OnDeathAbillity = OnDeathAbillity.Spawn;
    public Entity enemyToSpawn;
    public int amountToSpawn;
}
