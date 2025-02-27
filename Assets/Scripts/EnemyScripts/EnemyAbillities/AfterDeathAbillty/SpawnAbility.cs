using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnAbility : MonoBehaviour, IDeathAbility
{
    [Header("Check if there is the spawnEnemy in object pool manager!")]
    [SerializeField] protected Entity spawnEnemy;
    protected const float horizontalSpawnSpace = 0.5f;

    public virtual void onDeath()
    {
        Entity enemy = ObjectPoolManager.GetObjectFromPool(spawnEnemy);
        enemy?.Initiate();
        SpawnAtPoint(enemy.transform);
    }
    protected abstract void SpawnAtPoint(Transform spawnEnemyTransform);

}
