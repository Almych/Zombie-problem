
using UnityEngine;

public class HorizontalSpawn : SpawnAbility
{
    private const int fixedAmount = 2; 
    private int lastSpawnedPosition;

    public HorizontalSpawn(int coolDownTicks, bool callOnce, Enemy enemy, float horizontalSpace, Enemy spawnEnemy, ParticleSystem effect) : base(coolDownTicks, callOnce, enemy, horizontalSpace, spawnEnemy, effect)
    {
    }

    

    protected override void Spawn()
    {
        for (int i = 0; i < fixedAmount; i++)
        {
            base.Spawn();
        }
    }

    protected override void SpawnAtPoint(Enemy spawnEnemyTransform, ParticleSystem particle)
    {
        if (lastSpawnedPosition >= 0)
        {
            if (BounceHandler.CheckOnYValidPosition(enemy.transform.position.y - 0.5f))
            {
                desirePosition = new Vector2(enemy.transform.position.x, enemy.transform.position.y - 0.5f);
                lastSpawnedPosition = -1;
            }
            else
            {
                desirePosition = enemy.transform.position;
            }
        }
        else
        {
            if (BounceHandler.CheckOnYValidPosition(enemy.transform.position.y + 0.5f))
            {
                desirePosition = new Vector2(enemy.transform.position.x, enemy.transform.position.y + 0.5f);
                lastSpawnedPosition = 1;
            }
            else
            {
                desirePosition = enemy.transform.position;
            }
        }
       particle.transform.position = desirePosition;
        spawnEnemyTransform.transform.position = desirePosition;
        spawnEnemyTransform.gameObject.SetActive(true);
        particle.gameObject.SetActive(true);
        spawnEnemyTransform?.Initiate(true);
    }
}
