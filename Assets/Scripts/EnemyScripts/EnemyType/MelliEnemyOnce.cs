using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneHitEnemy : MelliEnemyNone
{
    public override void AbilityAdd()
    {
    }
    public override void Initiate()
    {
        rb.velocity = -transform.right * enemyData.speed;
    }

    public new void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<HealthBar>() != null)
        {
            Attack(collision.collider.GetComponent<HealthBar>());
            Death();
        }
    }
}
