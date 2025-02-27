using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardSpawn : SpawnAbility
{
    private const int fixedAmount = 1;
    public override void onDeath()
    {
        base.onDeath();
    }

    protected override void SpawnAtPoint(Transform spawnEnemyTransform)
    {
        spawnEnemyTransform.position = new Vector2(transform.position.x - horizontalSpawnSpace,transform.position.y);
    }
}
