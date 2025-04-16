using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnAbility : MonoBehaviour, IDeathAbility, IDamageAbility, IAttackAbility, IMoveAbility
{
    [Header("Check if there is the spawnEnemy in object pool manager!")]
    [SerializeField] protected Entity spawnEnemy;
    protected const float horizontalSpawnSpace = 0.5f;

    public virtual void onDeath()
    {
        Spawn();
    }

    protected void Spawn()
    {
        Entity enemy = ObjectPoolManager.GetObjectFromPool(spawnEnemy);
        if (enemy != null)
        {
            enemy.gameObject.SetActive(true);
            enemy?.Initiate();
            SpawnAtPoint(enemy.transform);
        }
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
