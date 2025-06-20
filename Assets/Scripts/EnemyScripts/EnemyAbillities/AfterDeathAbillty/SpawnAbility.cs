using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnAbility : Ability
{
    protected float horizontalSpawnSpace;
    protected Enemy spawnEnemy;
    protected ParticleSystem effect;
    protected Vector2 desirePosition;
    protected SpawnAbility(int coolDownTicks, bool callOnce, Enemy enemy, float horizontalSpace, Enemy spawnEnemy, ParticleSystem effect) : base(coolDownTicks, callOnce, enemy)
    {
        horizontalSpawnSpace = horizontalSpace;
        this.spawnEnemy = spawnEnemy;
        this.effect = effect;
        ObjectPoolManager.CreateObjectPool(effect, 3);
    }

    protected override void OnCall()
    {
        Spawn();
    }

    protected virtual void Spawn()
    {
        Enemy spawnedEnemy =ObjectPoolManager.GetObjectFromPool(spawnEnemy);
        var particle = ObjectPoolManager.GetObjectFromPool(effect);
        if (spawnedEnemy != null && particle != null)
        {
            SpawnAtPoint(spawnedEnemy, particle);
        }
    }

    protected abstract void SpawnAtPoint(Enemy spawnEnemyTransform, ParticleSystem particle);
}
