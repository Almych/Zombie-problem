using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeEnemy : Entity
{
    private HealthBar barrier;
    public override void Activate()
    {
        gameObject.SetActive(true);
        Move();
    }

    public override void Attack()
    {
        if (barrier != null)
        {
            barrier.ChangeHealthValue(-enemyData.damage);
        }
    }

   

    public override void Move()
    {
        rb.velocity = -Vector2.right * enemyData.speed;
    }
}
