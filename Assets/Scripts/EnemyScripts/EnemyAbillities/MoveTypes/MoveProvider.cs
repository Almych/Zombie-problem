using UnityEngine;

public abstract class MoveProvider : IMoveStrategy, ISpeedProvider
{
    protected float _speed;
    protected float _baseSpeed;
    protected Rigidbody2D _rb;
    protected Transform _transform;
    internal protected IMoveAbility moveAbility;
    internal protected int coolDownTicks;


    protected MoveProvider(Transform transform, Rigidbody2D rb, float speed, IMoveAbility moveAbility, int moveAbilityTicks)
    {
        _transform = transform;
        _rb = rb;
        _baseSpeed = speed;
        _speed = _baseSpeed;
        this.moveAbility = moveAbility;
        coolDownTicks = moveAbilityTicks;
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
