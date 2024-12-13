using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableEnemy : Entity
{
    public delegate void Spawn(int amount, Entity enemyType, Vector3 pos);
    public static Spawn OnSpawn;
    [SerializeField] private int amountSpawnEnemy;
    [SerializeField] private Entity enemyType;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<HealthBar>() != null && !isAttacking)
        {
            isDead = true;
            Death();
        }
    }

    private void OnEnable()
    {
        OnDeathAddition += SpawnRandomEnemy;
    }

    private void OnDisable()
    {
        OnDeathAddition -= SpawnRandomEnemy;
    }

    private void SpawnRandomEnemy()
    {
        OnSpawn?.Invoke(amountSpawnEnemy,enemyType,transform.position);
    }
    
    


    public override void Initiate()
    {
        rb.velocity = -transform.right;
    }
}
