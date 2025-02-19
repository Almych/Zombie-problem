using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagMove : IMovable
{
    private Rigidbody2D _rb;
    private Transform _transform;
    private float _speed;
    private const float amplitude = 2f;
    public ZigZagMove(Transform enemyTransform, Rigidbody2D rb, float speed)
    {
        _rb = rb;
        _transform = enemyTransform;
        _speed = speed;
    }

    public void Move()
    {
        float newX = Mathf.Sin(Time.time * _speed) * amplitude;
        _rb.velocity = new Vector2(newX, _rb.velocity.y);
    }

    public void StopMove()
    {
       _rb.velocity = Vector2.zero;
    }
}
