using UnityEngine;

public class MoveTowards : MoveProvider
{
    public MoveTowards(Transform transform, Rigidbody2D rb, float speed, IMoveAbility moveAbility, int moveAbilityTicks) : base(transform, rb, speed, moveAbility, moveAbilityTicks)
    {
    }

    public override void Move()
    {
        _rb.velocity = -_transform.right * _speed;
    } 
}
