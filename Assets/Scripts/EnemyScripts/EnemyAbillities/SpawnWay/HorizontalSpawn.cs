using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalSpawn : SpawnAbility
{
    private const int fixedAmount = 2; 
    private int lastSpawnedPosition;

    public override void onDeath()
    {
        for (int i = 0; i < fixedAmount; i++)
        {
            base.onDeath();
        }
    }

    protected override void SpawnAtPoint(Transform spawnEnemyTransform)
    {
        if (lastSpawnedPosition >= 0)
        {
            if (BounceHandler.CheckOnYValidPosition(transform.position.y - 0.5f))
            {
                spawnEnemyTransform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
                lastSpawnedPosition = -1;
            }
            else
            {
                spawnEnemyTransform.position = transform.position;
            }
        }
        else
        {
            if (BounceHandler.CheckOnYValidPosition(transform.position.y + 0.5f))
            {
                spawnEnemyTransform.position = new Vector2(transform.position.x, transform.position.y + 0.5f);
                lastSpawnedPosition = 1;
            }
            else
            {
                spawnEnemyTransform.position = transform.position;
            }
        }
       
    }
}
