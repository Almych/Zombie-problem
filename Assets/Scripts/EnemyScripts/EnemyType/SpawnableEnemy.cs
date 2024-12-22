using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableEnemy : Entity
{
    [SerializeField] private int amountSpawnEnemy;
    [SerializeField] private Entity enemyType;
    [SerializeField] private float speed;
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
        OnDeath += enemyAbility.UniqAbillityUse;
    }

    private void OnDisable()
    {
        OnDeath -= enemyAbility.UniqAbillityUse;
    }

    public override void Initiate()
    {
        rb.velocity = -transform.right * speed;
    }

    public override void AbilityAdd()
    {
        enemyAbility = new SpawnAbility(transform, rb, amountSpawnEnemy, enemyType);
    }
}
