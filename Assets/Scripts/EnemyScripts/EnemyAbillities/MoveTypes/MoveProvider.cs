using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveProvider : IMovable
{
    protected MoveStats mStats;
    public MoveProvider(MoveStats stats)
    {
       mStats = stats;
    }

    public abstract void Move();
    public abstract void StopMove();

    public MoveStats GetStats()
    {
        return mStats;
    }
}
