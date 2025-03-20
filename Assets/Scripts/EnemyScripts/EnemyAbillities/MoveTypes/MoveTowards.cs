using UnityEngine;

public class MoveTowards : MoveProvider
{
    public MoveTowards(Rigidbody2D rb, Transform transform, float speed) : base(rb, transform, speed)
    {
    }

    public override void Move()
    {
        _rb.velocity = -_transform.right * _speed;
    } 
}
