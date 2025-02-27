using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagMove : MoveProvider
{
    private const float amplitude = 2f;

    public ZigZagMove(MoveStats stats) : base(stats)
    {
    }

    public override void Move()
    {
        float newX = Mathf.Sin(Time.time * mStats._speed) * amplitude;
        mStats._rb.velocity = new Vector2(newX, mStats._rb.velocity.y);
    }

    public override void StopMove()
    {
        mStats._rb.velocity = Vector2.zero;
    }
}
