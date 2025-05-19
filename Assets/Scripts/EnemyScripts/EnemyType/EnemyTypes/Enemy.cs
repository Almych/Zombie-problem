using System;
using UnityEditor;
using UnityEngine;

public abstract class Enemy : Entity, IEnemy, ISpeedProvider
{
    [SerializeField] AbilityConfig[] deathAbility, moveAbility, attackAbility, damageAbility, detectAbility;
    protected float currHealth;
    internal protected AttackProvider attackDealer;
    internal protected MoveProvider movable;
    internal protected DeathProvider deathProvider;
    internal protected StateMachine stateMachine;
    protected event Action onDeath, onMove, onAttack, onGetDamage, onDetect;
    protected IdleState idleState;
    protected RunState runState;
    protected AttackState attackState;
    protected DieState dieState;
    protected int dieAnimation = Animator.StringToHash("Die");
    protected int attackAnimation = Animator.StringToHash("Attack");
    protected int runAnimation = Animator.StringToHash("Walk");
    protected int idleAnimation = Animator.StringToHash("Idle");
    protected const float animSpeed = 1f;
    private bool movementDirty;

    public Vector2 desiredVelocity
    {
        get => _desiredVelocity;
        set
        {
                _desiredVelocity = value;
                movementDirty = true;
        }
    }

    private Vector2 _desiredVelocity;
    internal protected abstract Transform ShootPoint { get; }
    internal protected abstract BaseEnemyConfig enemyConfig { get; }
    internal protected float currentSpeed;
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
    public virtual void InitiateMachine()
    {
        stateMachine?.SwitchState(runState, true);
    }
    public void RequestStun(int duration, StunType stunType = StunType.Stun)
    {
        stateMachine?.StopState(duration);
    }
    public virtual void SetStateMachine()
    {
        SetAbilities();
        idleState = new IdleState(animator, idleAnimation, this, () => stateMachine?.SwitchState(stateMachine.lastState));
        runState = new RunState(animator, runAnimation, this);
        attackState = new AttackState(animator, attackAnimation, this);
        dieState = new DieState(animator, dieAnimation, this, deathProvider);
        stateMachine = new StateMachine(idleState, runState, attackState, dieState);
    }

    public override void Init()
    {
        base.Init();
        attackDealer = enemyConfig.attackType.SetAttack(this);
        movable = enemyConfig.moveType.SetMove(this);
        deathProvider = enemyConfig.deathType.SetDeath(this);
        SetStateMachine();
        currentSpeed = enemyConfig.speed;
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
        ResetSpeed();
        InitiateMachine();
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


    void FixedUpdate()
    {
        if (movementDirty)
        {
            rb.linearVelocity = _desiredVelocity;
            movementDirty = false;
        }
    }

    public override void Die()
    {
        deathProvider?.Die();
    }

    public virtual void TriggerAction()
    {
        attackDealer?.ExecuteAttack();
    }

    public void ReduceSpeed(float speedProcents = 0.1F)
    {
        currentSpeed = enemyConfig.speed * speedProcents;
        movable.Move();
    }

    public void IncreaseSpeed(float speedProcents = 0.1F)
    {
        currentSpeed = enemyConfig.speed / speedProcents;
        movable.Move();
    }

    public void ResetSpeed()
    {
        currentSpeed = enemyConfig.speed;
    }
}