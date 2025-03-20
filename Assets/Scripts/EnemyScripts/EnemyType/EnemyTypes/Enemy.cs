using UnityEngine;

public abstract class Enemy : Entity, IEnemy
{
   
    protected float currHealth;
    protected IAttackDealer attackDealer;
    protected IDeathAbility deathAbility;
    protected IMovable movable;
    protected StateMachine stateMachine;
    protected RunState runState;
    protected AttackState attackState;
    protected DieState dieState;

    protected abstract BaseEnemyConfig enemyConfig { get; }

    public override void Init()
    {
        base.Init();
        movable = SetMove();
        attackDealer = SetAttack();
        deathAbility = GetComponent<IDeathAbility>();
        runState = new RunState(animator, movable);
        attackState = new AttackState(animator);
        dieState = new DieState(animator);
        stateMachine = new StateMachine(runState, attackState, dieState);
        UpdateSystem.OnUpdate += stateMachine.OnTick;
    }


    protected virtual void OnDestroy()
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

    protected abstract IMovable SetMove();
    protected abstract IAttackDealer SetAttack();
}
