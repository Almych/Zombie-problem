using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnAbility : Ability
{
    protected float horizontalSpawnSpace;
    protected Enemy spawnEnemy;

    protected SpawnAbility(int coolDownTicks, bool callOnce, Enemy enemy, float horizontalSpace, Enemy spawnEnemy) : base(coolDownTicks, callOnce, enemy)
    {
        horizontalSpawnSpace = horizontalSpace;
        this.spawnEnemy = spawnEnemy;
    }

    protected override void OnCall()
    {
        Spawn();
    }

    protected virtual void Spawn()
    {
        Enemy spawnedEnemy = ObjectPoolManager.GetObjectFromPool(spawnEnemy);
        Debug.Log(spawnedEnemy == null);
        if (spawnedEnemy != null)
        {
            spawnedEnemy.gameObject.SetActive(true);
            spawnedEnemy?.Initiate();
            SpawnAtPoint(spawnedEnemy.transform);
        }
    }

    protected abstract void SpawnAtPoint(Transform spawnEnemyTransform);
}
