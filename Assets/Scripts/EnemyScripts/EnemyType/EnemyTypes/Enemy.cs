using UnityEngine;

public abstract class Enemy : Entity, IEnemy
{
    protected float currHealth;
    protected IAttackStrategy attackDealer;
    protected IDeathAbility deathAbility;
    protected IMoveAbility moveAbility;
    protected MoveProvider movable;
    protected StateMachine stateMachine;
    protected RunState runState;
    protected AttackState attackState;
    protected DieState dieState;

    protected abstract BaseEnemyConfig enemyConfig { get; }


    public void SetStateMachine()
    {
        runState = new RunState(animator, movable);
        attackState = new AttackState(animator);
        dieState = new DieState(animator);
        stateMachine = new StateMachine(runState, attackState, dieState);
    }

    protected void OnEnable()
    {
        if (stateMachine != null) 
        UpdateSystem.OnUpdate += stateMachine.OnTick;
    }


    protected void OnDisable()
    {
        UpdateSystem.OnUpdate -= stateMachine.OnTick;
    }

    public override void Initiate()
    {
        currHealth = enemyConfig.maxHealth;
        stateMachine?.SwitchState(runState);
    }

    public virtual void TakeDamage(Damage damage)
    {
        currHealth -= enemyConfig.uniqDefense.Defense(damage);
        ParticleSystem blood = ObjectPoolManager.FindObjectByName<ParticleSystem>("EnemyHitParticle");
        if (blood != null)
        {
            blood.gameObject.SetActive(true);
            blood.transform.position = transform.position;
        }
        if (currHealth <= 0)
        {
            stateMachine?.SwitchState(dieState);
        } 
    }

    public override void Die()
    {
        deathAbility?.onDeath();
        base.Die();
    }

    public virtual void TriggerAction()
    {
        attackDealer?.ExecuteAttack();
    }
}
