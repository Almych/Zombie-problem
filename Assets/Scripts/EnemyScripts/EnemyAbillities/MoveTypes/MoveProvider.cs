using UnityEngine;

public abstract class MoveProvider : IMovable, ISpeedProvider
{
    protected float _speed;
    protected float _baseSpeed;
    protected Rigidbody2D _rb;
    protected Transform _transform;
    protected MoveProvider(Rigidbody2D rb, Transform transform, float speed)
    {
        _baseSpeed = speed;
        _rb = rb;
        _transform = transform;
        _speed = _baseSpeed;
    }
    public abstract void Move();
    public void ReduceSpeed(float speedProcents = 0.1F)
    {
        _speed = _baseSpeed * speedProcents;
    }
    public void IncreaseSpeed(float speedProcents = 0.1f)
    {
        _speed = _baseSpeed / speedProcents;
    }
    public void StopMove()
    {
        _rb.velocity = Vector2.zero;
    }
}
