using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : IMovable
{
    private float _speed;
    private Rigidbody2D _rb;
    private Transform _transform;
    public MoveTowards(float speed, Rigidbody2D rb, Transform transform)
    {
        _speed = speed;
        _rb = rb;
        _transform = transform;
    }

    public void Move()
    {
       _rb.velocity = -_transform.right * _speed;
    }

    public void StopMove()
    {
        _rb.velocity = Vector2.zero;
    }
}
