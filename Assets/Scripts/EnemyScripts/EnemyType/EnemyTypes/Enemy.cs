using System;
using UnityEngine;

public abstract class Enemy : Entity, IEnemy
{
    [SerializeField] AbilityConfig[] deathAbility, moveAbility, attackAbility, damageAbility, detectAbility;
    protected float currHealth;
    internal protected AttackProvider attackDealer;
    internal protected MoveProvider movable;
    internal protected StateMachine stateMachine;
    protected event Action onDeath, onMove, onAttack, onGetDamage, onDetect;
    protected RunState runState;
    protected AttackState attackState;
    protected DieState dieState;
    protected int dieAnimation = Animator.StringToHash("Die");
    protected int attackAnimation = Animator.StringToHash("Attack");
    protected int runAnimation = Animator.StringToHash("Walk");

    internal protected abstract Transform ShootPoint { get; }
    internal protected abstract BaseEnemyConfig enemyConfig { get; }

    public void CallMoveAbility() => onMove?.Invoke();
    public void CallDetectAbility() => onDetect?.Invoke();
    public void CallDeathAbility() => onDeath?.Invoke();
    public void CallAttackAbility() => onAttack?.Invoke();


    protected void SetAbilities()
    {
        foreach (var ability in deathAbility)
        {
            onDeath += ability.ApplyAbilities(this);
        }

        foreach (var ability in moveAbility)
        {
            onMove += ability.ApplyAbilities(this);
        }

        foreach (var ability in attackAbility)
        {
            onAttack += ability.ApplyAbilities(this);
        }

        foreach (var ability in damageAbility)
        {
            onGetDamage += ability.ApplyAbilities(this);
        }

        foreach (var ability in detectAbility)
        {
            onDetect += ability.ApplyAbilities(this);
        }
    }

    public virtual void SetStateMachine()
    {
        SetAbilities();
        runState = new RunState(animator, runAnimation, this);
        attackState = new AttackState(animator, attackAnimation, this);
        dieState = new DieState(animator, dieAnimation, this);
        stateMachine = new StateMachine(runState, attackState, dieState);
    }

    public override void Init()
    {
        base.Init();
        attackDealer = enemyConfig.attackType.SetAttack(this);
        movable = enemyConfig.moveType.SetMove(this);
        SetStateMachine();
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
        onGetDamage?.Invoke();
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
        base.Die();
    }

    public virtual void TriggerAction()
    {
        attackDealer?.ExecuteAttack();
    }
}
