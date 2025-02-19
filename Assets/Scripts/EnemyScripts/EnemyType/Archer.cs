using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : RangedEnemy
{
    public override void Attack()
    {
       attackDealer.Attack();
    }

    public override void Die()
    {
       
    }

    public override void Initiate()
    {
        moveWay = new ZigZagMove(transform, rb, speed);
        attackDealer = new RangedAttackDealer(damage, bulletSprite, bulletSpeed, transform);
        base.Initiate();
        StartCoroutine(DetectEnemy());
    }

    

    protected override IEnumerator DetectEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(detectTime);
            hit = Physics2D.Raycast(transform.position, Vector2.left, attackDistance, triggerMask);
            if (hit.collider != null)
            {
                moveWay.StopMove();
                Attack();
            }
        }
    }
}
