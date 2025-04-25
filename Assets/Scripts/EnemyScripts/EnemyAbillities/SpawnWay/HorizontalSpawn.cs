
using UnityEngine;

public class HorizontalSpawn : SpawnAbility
{
    private const int fixedAmount = 2; 
    private int lastSpawnedPosition;

    public HorizontalSpawn(int coolDownTicks, bool callOnce, Enemy enemy, float horizontalSpace, Enemy spawnEnemy) : base(coolDownTicks, callOnce, enemy, horizontalSpace, spawnEnemy)
    {
    }

    

    protected override void Spawn()
    {
        for (int i = 0; i < fixedAmount; i++)
        {
            base.Spawn();
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
