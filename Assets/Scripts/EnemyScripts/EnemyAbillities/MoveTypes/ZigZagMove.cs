using UnityEngine;

public class ZigZagMove : MoveProvider
{
    private float _amplitude = 2f;

    public ZigZagMove(Rigidbody2D rb, Transform transform, float speed, float amplitude) : base(rb, transform, speed)
    {
        _amplitude = amplitude;
    }

    public override void Move()
    {
        float newX = Mathf.Sin(Time.time * _speed) * _amplitude;
        _rb.velocity = new Vector2(newX,_rb.velocity.y);
    }
}
