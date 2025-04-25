using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardSpawn : SpawnAbility
{
    public ForwardSpawn(int coolDownTicks, bool callOnce, Enemy enemy, float horizontalSpace, Enemy spawnEnemy) : base(coolDownTicks, callOnce, enemy, horizontalSpace, spawnEnemy)
    {
    }

    protected override void Spawn()
    {
        base.Spawn();
    }

    protected override void SpawnAtPoint(Transform spawnEnemyTransform)
    {
        spawnEnemyTransform.position = new Vector2(enemy.transform.position.x - horizontalSpawnSpace, enemy.transform.position.y);
    }
}
