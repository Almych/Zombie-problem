using UnityEngine;

public class MoveTowards : MoveProvider
{
    public MoveTowards(Animator animator, Transform transform, Rigidbody2D rb, float speed) : base(animator, transform, rb, speed)
    {
    }

    public override void Move()
    {
        _rb.velocity = -_transform.right * _speed;
    } 
}
