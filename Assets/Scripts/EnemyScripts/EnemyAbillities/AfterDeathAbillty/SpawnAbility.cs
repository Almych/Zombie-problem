using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnAbility :  IDeathAbility
{
    protected Enemy spawnEnemy, enemy;
    protected float horizontalSpawnSpace;

    protected SpawnAbility(Enemy enemy, float horizontalSpace, Enemy spawnEnemy)
    {
        this.enemy = enemy;
        horizontalSpawnSpace = horizontalSpace;
        this.spawnEnemy = spawnEnemy;
    }

    public virtual void OnDeath()
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

    protected void Spawn()
    {
       
    }
    protected abstract void SpawnAtPoint(Transform spawnEnemyTransform);

    public virtual void OnGetDamage()
    {
        Spawn();
    }

    public virtual void OnAttack()
    {
        Spawn();
    }

    public void OnMove()
    {
        Spawn();
    }
}
