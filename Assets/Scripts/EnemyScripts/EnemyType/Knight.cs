using UnityEngine;

public class Knight : MeleeEnemy
{
    public override void Attack()
    {
       attackDealer?.Attack(healthBar);
    }
    public override void Init()
    {
        attackDealer = new MeleeDealer(damage);
        base.Init();
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        healthBar = collision.collider.GetComponent<HealthBar>();
        if (healthBar != null )
        {
            stateMachine.SwitchState(attackState);
        }
    }
}
