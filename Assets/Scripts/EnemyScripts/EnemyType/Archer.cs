using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : RangedEnemy
{
    public override void Attack()
    {
        EnemyBulletBehaivior bullet = ObjectPoolManager.FindObject<EnemyBulletBehaivior>();

        if (bullet != null)
        {
            bullet.transform.position = transform.position;
            bullet.Activate(damage, bulletSprite, bulletSpeed);
        }
    }

    public override void Initiate()
    {
        moveWay = new ZigZagMove(transform, rb, speed);
        Move();
        StartCoroutine(DetectEnemy());
    }

    public override void Move()
    {
        moveWay.Move();
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
