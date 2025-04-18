using System;
using UnityEngine;

public class MoveTowards : MoveProvider
{
    public MoveTowards(Transform transform, Rigidbody2D rb, float speed, int moveAbilityTicks) : base(transform, rb, speed, moveAbilityTicks)
    {
    }

    public override void Move()
    {
        _rb.velocity = -_transform.right * _speed;
    } 
}
