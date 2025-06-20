using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

public abstract class Enemy : Entity, IEnemy, ISpeedProvider
{
    [SerializeField] AbilityConfig[] deathAbility, moveAbility, attackAbility, damageAbility, detectAbility;
    public AttackProvider attackDealer { get; private set; }
    public MoveProvider movable { get; private set; }
    public DeathProvider deathProvider { get; private set; }
    public StateMachine stateMachine { get; set; }
    public Vector2 desiredVelocity
    {
        get => _desiredVelocity;
        set
        {
            _desiredVelocity = value;
            movementDirty = true;
        }
    }
    public abstract Transform ShootPoint { get; }
    public abstract BaseEnemyConfig enemyConfig { get; }
    public void CallMoveAbility() => onMove?.Invoke();
    public void CallDetectAbility() => onDetect?.Invoke();
    public void CallDeathAbility() => onDeath?.Invoke();
    public void CallAttackAbility() => onAttack?.Invoke();

    protected float currHealth;
    protected event Action onDeath, onMove, onAttack, onGetDamage, onDetect;
    protected IdleState idleState;
    protected RunState runState;
    protected AttackState attackState;
    protected DieState dieState;
    protected int dieAnimation = Animator.StringToHash("Die");
    protected int attackAnimation = Animator.StringToHash("Attack");
    protected int runAnimation = Animator.StringToHash("Walk");
    protected int idleAnimation = Animator.StringToHash("Idle");
    protected float currentSpeed;
    protected const float animSpeed = 1f;
    private bool movementDirty;
    private Vector2 _desiredVelocity;
    //avoiding to die early after spawn!
    private bool hasShield;
    private const float shieldProtectTime = 4f;
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
    private IEnumerator ActivateShield()
    {
        hasShield = true;
        yield return new WaitForSeconds(shieldProtectTime);
        hasShield = false;
    }
    public void RequestStun(int duration, StunType stunType)
    {
        stateMachine?.StopState(duration, stunType);
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

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }

    public void SetNewMoveProvider(MoveProvider moveProvider)
    {
        movable = moveProvider;
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
        if (stateMachine != null)
            UpdateSystem.OnUpdate -= stateMachine.OnTick;
    }

    public virtual void Initiate(bool isSpawnedByEnemy = false)
    {
        currHealth = enemyConfig.maxHealth;
        enemyCollider.enabled = true;
        ResetSpeed();
        SetColor(Color.white);
        InitiateMachine();
        if(!isSpawnedByEnemy)
        StartCoroutine(ActivateShield());
    }

    public virtual void TakeDamage(Damage damage)
    {
        if (currHealth <= 0)
            return;
        ParticleSystem blood = ObjectPoolManager.FindObjectByName<ParticleSystem>("Blood");
        if (blood != null && enemyConfig.uniqDefense.Defense(damage) > 0 && !hasShield)
        {
            currHealth -= enemyConfig.uniqDefense.Defense(damage);
            onGetDamage?.Invoke();
            blood.gameObject.SetActive(true);
            blood.transform.position = transform.position;
        }
        if (currHealth <= 0)
        {
            enemyCollider.enabled = false;
            stateMachine?.SwitchState(dieState, true);
            OnDeathSpawnCollectables();
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
    }

    public void IncreaseSpeed(float speedProcents = 0.1F)
    {
        currentSpeed = enemyConfig.speed / speedProcents;
    }

    public void ResetSpeed()
    {
        currentSpeed = enemyConfig.speed;
    }
    
    public void SetColor(Color color)
    {
        spriteRenderer.color = color;
        if (bodySprite != null)
            bodySprite.color = color;
    }

    private void OnDeathSpawnCollectables()
    {
        CollectablesSpawn.SpawnRandomObject(transform.position);
    }
}