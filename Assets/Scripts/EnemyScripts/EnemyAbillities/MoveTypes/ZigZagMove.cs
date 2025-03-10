using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagMove : MoveProvider
{
    private const float amplitude = 2f;

    public override void Move()
    {
        float newX = Mathf.Sin(Time.time * _speed) * amplitude;
        _rb.velocity = new Vector2(newX,_rb.velocity.y);
    }
}
