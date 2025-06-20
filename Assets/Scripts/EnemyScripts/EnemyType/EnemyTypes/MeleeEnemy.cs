using UnityEngine;

public abstract class MeleeEnemy : Enemy
{
    [SerializeField] protected MeleeEnemyConfig meleeEnemyConfig;
    
    protected HealthBar healthBar;
    public override BaseEnemyConfig enemyConfig  => meleeEnemyConfig;
    public override Transform ShootPoint => null;

    public override void TriggerAction()
    {
        attackDealer?.ExecuteAttack(healthBar);
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        healthBar = collision.collider.GetComponent<HealthBar>();
        if (healthBar != null )
        {
            CallDetectAbility();
            stateMachine?.SwitchState(attackState);
        }
    }
}
