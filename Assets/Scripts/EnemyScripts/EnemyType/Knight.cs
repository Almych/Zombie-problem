using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Knight : MeleeEnemy
{
    public override void Attack()
    {
        barrier.ChangeHealthValue(-damage);
    }

    public override void Initiate()
    {
        moveWay = new MoveTowards(speed, rb, transform);
        Move();
    }

    public override void Move()
    {
       moveWay.Move();
    }

    protected override void OnColliderTrigger2D(Collider2D other)
    {
        barrier = other.GetComponent<HealthBar>();
        if (barrier != null)
        {
            Attack();
        }
    }
}
