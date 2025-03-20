using UnityEngine;

public abstract class MeleeEnemy : Enemy
{
    [SerializeField] protected MeleeEnemyConfig meleeEnemyConfig;
    
    protected HealthBar healthBar;
    protected override BaseEnemyConfig enemyConfig  => meleeEnemyConfig;

    public override void TriggerAction()
    {
        attackDealer?.ExecuteAttack(healthBar);
    }
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        healthBar = collision.collider.GetComponent<HealthBar>();
        if (healthBar != null )
        {
            stateMachine?.SwitchState(attackState);
        }
    }
}
