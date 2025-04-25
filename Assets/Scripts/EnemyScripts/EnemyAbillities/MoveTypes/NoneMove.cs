
using UnityEngine;

public class NoneMove : MoveProvider
{
    public NoneMove(Animator animator,Transform transform, Rigidbody2D rb, float speed) : base(animator,transform, rb, speed)
    {
    }

    public override void Move()
    {
        
    }
}
