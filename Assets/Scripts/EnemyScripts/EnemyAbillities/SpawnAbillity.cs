using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAbillity : OnDeathEnemyAbillity
{
    private int _amount;
    private Entity _entity;

    public SpawnAbillity(Transform unit, Rigidbody2D unitRb, int amount, Entity spawnEnemy) : base(unit, unitRb)
    {
        _amount = amount;
        _entity = spawnEnemy;   
    }

    public override void OnDeath()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        for (int i = 0; i < _amount; i++)
        {
            Entity spawnEnemy = EnemyPool.Instance.GetZombie(_entity);
            if (spawnEnemy != null)
            {
                var randomYPositon = UnityEngine.Random.Range(-1, 1);
                spawnEnemy.transform.position = new Vector3(_unit.position.x, _unit.transform.position.y + randomYPositon, 0);
                spawnEnemy.Initiate();
            }
        }
    }
}
