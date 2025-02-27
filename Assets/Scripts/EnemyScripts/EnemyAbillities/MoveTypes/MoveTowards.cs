using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MoveProvider
{
    public MoveTowards(MoveStats stats) : base(stats)
    {
    }

    public override void Move()
    {
        mStats._rb.velocity = -mStats._transform.right * mStats._speed;
    }

    public override void StopMove()
    {
        mStats._rb.velocity = Vector2.zero;
    }
}
