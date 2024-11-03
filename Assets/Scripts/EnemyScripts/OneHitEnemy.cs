using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneHitEnemy : Enemy
{
    public override void Initiate()
    {
        rb.velocity = -transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<HealthBar>() != null)
        {
            isDead = true;
            Attack(collision.collider.GetComponent<HealthBar>());
            Death();
        }
    }
}
