using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelliEnemyNone : Entity, IMelliEnemy
{
    public override void AbilityAdd()
    {
       // throw new System.NotImplementedException();
    }

    public override void Initiate()
    {
        rb.velocity = -transform.right * enemyData.speed;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Death();
    }


    protected void Attack(HealthBar barrier)
    {
        barrier.ChangeHealthValue(-enemyData.damage);
        animator.SetBool("isAttacking", isAttacking);
    }
}
