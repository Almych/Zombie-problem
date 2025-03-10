using UnityEngine;

public abstract class MoveProvider : MonoBehaviour, IMovable, ISpeedProvider
{
    [SerializeField] protected float _speed;
    protected float _baseSpeed => _speed;
    protected Rigidbody2D _rb => GetComponent<Rigidbody2D>();


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
