using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAbility : OnDeathEnemyAbility
{
    private int _amount;
    private Entity _entity, toSpawn;

    public SpawnAbility(Entity enemy, Entity toSpawn, int amount) : base(enemy)
    {
        _amount = amount;
        _entity = enemy;
        this.toSpawn = toSpawn;
    }

    public override void OnDeath()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        for (int i = 0; i < _amount; i++)
        {
            Entity spawnEnemy = ObjectPoolManager.GetObjectFromPool(toSpawn);
            if (spawnEnemy != null)
            {
                spawnEnemy.gameObject.SetActive(true);
                var randomYPositon = Random.Range(-1, 1);
                spawnEnemy.transform.position = new Vector3(_entity.transform.position.x, transform.position.y + randomYPositon, 0);
                spawnEnemy.Initiate();
            }
        }
    }
}
