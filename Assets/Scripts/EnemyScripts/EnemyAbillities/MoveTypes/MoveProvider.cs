using System;
using UnityEngine;

public abstract class MoveProvider : IMoveStrategy
{
    protected Enemy _enemy;
    protected MoveProvider(Enemy enemy)
    {
        _enemy = enemy;
    }


    public abstract void Move();
    public void StopMove()
    {
        _enemy.desiredVelocity = Vector2.zero;
    }

    
}
