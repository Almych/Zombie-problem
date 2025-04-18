using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalSpawn : SpawnAbility
{
    private const int fixedAmount = 2; 
    private int lastSpawnedPosition;

    public HorizontalSpawn(Enemy enemy, float horizontalSpace, Enemy spawnEnemy) : base(enemy, horizontalSpace, spawnEnemy)
    {
    }

    public override void OnDeath()
    {
        for (int i = 0; i < fixedAmount; i++)
        {
            base.OnDeath();
        }
    }

    protected override void SpawnAtPoint(Transform spawnEnemyTransform)
    {
        if (lastSpawnedPosition >= 0)
        {
            if (BounceHandler.CheckOnYValidPosition(enemy.transform.position.y - 0.5f))
            {
                spawnEnemyTransform.position = new Vector2(enemy.transform.position.x, enemy.transform.position.y - 0.5f);
                lastSpawnedPosition = -1;
            }
            else
            {
                spawnEnemyTransform.position = enemy.transform.position;
            }
        }
        else
        {
            if (BounceHandler.CheckOnYValidPosition(enemy.transform.position.y + 0.5f))
            {
                spawnEnemyTransform.position = new Vector2(enemy.transform.position.x, enemy.transform.position.y + 0.5f);
                lastSpawnedPosition = 1;
            }
            else
            {
                spawnEnemyTransform.position = enemy.transform.position;
            }
        }
       
    }
}
