using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardSpawn : SpawnAbility
{

    public ForwardSpawn(Enemy enemy, float horizontalSpace, Enemy spawnEnemy) : base(enemy, horizontalSpace, spawnEnemy)
    {
    }

    public override void OnDeath()
    {
        base.OnDeath();
    }

    protected override void SpawnAtPoint(Transform spawnEnemyTransform)
    {
        spawnEnemyTransform.position = new Vector2(enemy.transform.position.x - horizontalSpawnSpace, enemy.transform.position.y);
    }
}
