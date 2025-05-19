using UnityEngine;

public class MoveTowards : MoveProvider
{
    public MoveTowards(Enemy enemy) : base(enemy)
    {
    }

    public override void Move()
    {
        _enemy.desiredVelocity = -_enemy.transform.right * _enemy.currentSpeed;

    } 
}
