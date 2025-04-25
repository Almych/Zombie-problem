using System;
using UnityEngine;

public abstract class MoveProvider : IMoveStrategy, ISpeedProvider
{
    protected float _speed;
    protected float _baseSpeed;
    protected Rigidbody2D _rb;
    protected Transform _transform;
    protected Animator _animator;
    internal protected bool boosted;
    protected MoveProvider(Animator animator, Transform transform, Rigidbody2D rb, float speed)
    {
        _transform = transform;
        _rb = rb;
        _baseSpeed = speed;
        _speed = _baseSpeed;
        _animator = animator;
    }


    public abstract void Move();
    public void ReduceSpeed(float speedProcents = 0.1F)
    {
        _animator.speed = _baseSpeed / speedProcents;
        _speed = _baseSpeed * speedProcents;
        boosted = true;
        Move();
    }
    public void IncreaseSpeed(float speedProcents = 0.1f)
    {
        _animator.speed = _baseSpeed / speedProcents;
        _speed = _baseSpeed / speedProcents;
        boosted = true;
        //calling to set speed;
        Move();
    }
    public void StopMove()
    {
        _rb.velocity = Vector2.zero;
    }
    public void ResetSpeed()
    {
        _animator.speed = 1;
        _speed = _baseSpeed;
        boosted = false;
    }
}
