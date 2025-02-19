using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Knight : MeleeEnemy
{
    private bool isAttacking;
    public override void Attack()
    {
    }

    public override void Die()
    {
      
    }

    public override void Initiate()
    {
        moveWay = new MoveTowards(speed, rb, transform);
        attackDealer = new MeleeAttackDealer (damage);
        base.Initiate();
    }

    protected override void OnCollisionExit2D(Collision2D other)
    {
        if (barrier != null)
        {
            isAttacking = false;
        }
    }

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        barrier = other.collider.GetComponent<HealthBar>();
        if (barrier != null && !isAttacking)
        {
            isAttacking = true;
            StartCoroutine(ContinuesAttack());
        }
    }

    private IEnumerator ContinuesAttack()
    {
        while (isAttacking)
        {
            
            yield return new WaitForSeconds(2f);
        }
    }
}
